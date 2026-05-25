#!/usr/bin/env python3
"""
Post-generation patch for *Update.cs models and the component types they embed.

Speakeasy emits update-request models with auto-properties like:

    [JsonProperty("display_name")]
    public string? DisplayName { get; set; } = null;

Combined with the global `NullValueHandling.Ignore` setting, this gives a
two-state field: "unset" and "value", but no way to send an explicit `null`
to clear a stored field. Setting `DisplayName = null` is indistinguishable
from leaving it untouched, and both result in the key being omitted.

Customers doing partial updates rely on the "unset means omit" behavior, so
we cannot flip the global serializer to `Include`. Instead, this script
rewrites each auto-property to a backing-field + `ShouldSerialize<X>()`
pattern that gives three states:

    * never assigned  -> key omitted (unchanged behavior)
    * assigned null   -> key sent as null (new: clear-via-null)
    * assigned value  -> key sent as value (unchanged behavior)

The `ShouldSerialize<X>()` method is honored by Newtonsoft.Json and takes
precedence over the global `NullValueHandling.Ignore`, so we also flip the
attribute to `NullValueHandling.Include` on each touched property.

Properties whose generated default is a non-null literal (e.g. `= false`)
are initialized with `_xSet = true` to preserve today's behavior of sending
that default value on the wire.

The patch covers two layers:

1. The `*Update.cs` request models themselves.
2. Every component type transitively reachable through the properties of
   those update models (e.g. `BuyerUpdate.BillingDetails` is typed as the
   shared `BillingDetails` class, which in turn embeds `Address`). Without
   patching the nested types, callers can only clear top-level fields:
   `BuyerUpdate.BillingDetails.Address.State = null` would be dropped by
   the global `NullValueHandling.Ignore` setting before reaching the wire.

The script is idempotent: re-running on already-patched code is a no-op
(the auto-property regex no longer matches the rewritten form).

Forward-compatibility: if Speakeasy's C# generator ever ships tri-state
nullable natively, the generated file is expected to expose
`ShouldSerialize*` methods (the only way Newtonsoft.Json honors per-field
omission while keeping `NullValueHandling.Include`). When this script
detects `ShouldSerialize` in a candidate file it treats that file as
already tri-stateful and leaves it alone. The patch can then be retired
file-by-file as the generator catches up, and removed entirely once no
file needs it.
"""
from __future__ import annotations

import argparse
import re
import sys
from pathlib import Path

PROP_RE = re.compile(
    r"(?P<indent>[ \t]*)"
    r"(?P<attr>\[JsonProperty\([^\]]*\)\])\s*\n"
    r"[ \t]*public\s+(?P<type_and_name>.+?)\s*\{\s*get;\s*set;\s*\}\s*=\s*(?P<default>[^;]+);",
    re.MULTILINE,
)

NULL_VALUE_HANDLING_RE = re.compile(
    r",?\s*NullValueHandling\s*=\s*NullValueHandling\.\w+"
)

# Matches any `[JsonProperty(...)]`-decorated property declaration, whether
# it's still an auto-property or has already been rewritten to the
# backing-field form. Used only to extract referenced type names for the
# transitive walk — not for rewriting.
TYPE_REF_RE = re.compile(
    r"\[JsonProperty\([^\]]*\)\]\s*\n"
    r"[ \t]*public\s+(?P<type_and_name>[^\n{=;]+)",
    re.MULTILINE,
)

# C# / framework types that never resolve to a component file. Anything else
# is checked against the components directory; if `{name}.cs` doesn't exist
# the reference is silently dropped (covers nested generic args like enum
# value types that happen to share a name).
_PRIMITIVE_TYPES = frozenset({
    "string", "int", "long", "short", "byte", "sbyte", "uint", "ulong",
    "ushort", "bool", "double", "float", "decimal", "char", "object",
    "DateTime", "DateTimeOffset", "TimeSpan", "Guid", "Uri", "Stream",
    "List", "IList", "ICollection", "IEnumerable", "IReadOnlyList",
    "IReadOnlyCollection", "Dictionary", "IDictionary",
    "IReadOnlyDictionary", "Nullable", "Task", "HashSet", "ISet",
})


def force_null_value_handling_include(attr: str) -> str:
    """Ensure the [JsonProperty(...)] attribute has NullValueHandling.Include.

    Replaces any existing `NullValueHandling = NullValueHandling.X` (Ignore,
    Default, etc.) with `Include`, and appends the argument if absent. We do
    this unconditionally rather than only when the argument is missing so the
    patch stays correct if Speakeasy ever starts emitting a different value.
    """
    if "NullValueHandling.Include" in attr:
        return attr
    stripped = NULL_VALUE_HANDLING_RE.sub("", attr)
    return stripped[:-2] + ", NullValueHandling = NullValueHandling.Include)]"


def patch_source(source: str) -> str | None:
    matches = list(PROP_RE.finditer(source))
    if not matches:
        return None

    out: list[str] = []
    last_end = 0
    for m in matches:
        indent = m.group("indent")
        attr = m.group("attr")
        type_and_name = m.group("type_and_name").strip()
        default = m.group("default").strip()

        space_idx = type_and_name.rfind(" ")
        type_str = type_and_name[:space_idx].strip()
        name = type_and_name[space_idx + 1 :].strip()

        new_attr = force_null_value_handling_include(attr)

        backing = "_" + name[0].lower() + name[1:]
        set_flag = backing + "Set"
        initial_set = "true" if default != "null" else "false"

        replacement = (
            f"{indent}{new_attr}\n"
            f"{indent}public {type_str} {name}\n"
            f"{indent}{{\n"
            f"{indent}    get => {backing};\n"
            f"{indent}    set\n"
            f"{indent}    {{\n"
            f"{indent}        {backing} = value;\n"
            f"{indent}        {set_flag} = true;\n"
            f"{indent}    }}\n"
            f"{indent}}}\n"
            f"\n"
            f"{indent}private {type_str} {backing} = {default};\n"
            f"\n"
            f"{indent}private bool {set_flag} = {initial_set};\n"
            f"\n"
            f"{indent}public bool ShouldSerialize{name}() => {set_flag};"
        )

        out.append(source[last_end : m.start()])
        out.append(replacement)
        last_end = m.end()

    out.append(source[last_end:])
    return "".join(out)


def extract_referenced_type_names(source: str) -> set[str]:
    """Return component type names referenced by `[JsonProperty]` properties.

    Walks every property declaration regardless of whether the file has
    already been patched. Generic wrappers are split apart so `List<Foo>`
    yields `Foo`, `Dictionary<string, Bar>` yields `Bar`, etc.
    """
    refs: set[str] = set()
    for m in TYPE_REF_RE.finditer(source):
        type_and_name = m.group("type_and_name").strip()
        space_idx = type_and_name.rfind(" ")
        if space_idx < 0:
            continue
        type_str = type_and_name[:space_idx].strip()
        for token in re.split(r"[<>,\s]+", type_str):
            token = token.strip().rstrip("?")
            if not token or token in _PRIMITIVE_TYPES:
                continue
            refs.add(token)
    return refs


def build_reachable_set(roots: list[Path], components: Path) -> set[Path]:
    """BFS over property type references starting from each root file.

    A type `Foo` is considered reachable iff `{components}/Foo.cs` exists.
    Anonymous / union helper types (e.g. Speakeasy's `OneOf` files) that
    don't have a matching component file are simply not visited.
    """
    visited: set[Path] = set()
    queue: list[Path] = []
    for root in roots:
        if root not in visited:
            visited.add(root)
            queue.append(root)

    while queue:
        path = queue.pop()
        try:
            source = path.read_text()
        except OSError:
            continue
        for type_name in extract_referenced_type_names(source):
            candidate = components / f"{type_name}.cs"
            if candidate.is_file() and candidate not in visited:
                visited.add(candidate)
                queue.append(candidate)
    return visited


def is_update_request_model(path: Path) -> bool:
    """Filter for files matching *Update.cs.

    The `*Update.cs` glob in `main()` already excludes the only known
    noun-form `Updater` files in this codebase (AccountUpdaterJob.cs,
    AccountUpdaterOptions.cs, etc.) because they don't end in `Update.cs`.
    The AccountUpdater* guard is a belt-and-suspenders check in case a
    future schema introduces e.g. `AccountUpdaterUpdate.cs`, which would
    be ambiguous; broaden it if/when such cases appear.
    """
    name = path.name
    if not name.endswith("Update.cs"):
        return False
    if name.startswith("AccountUpdater"):
        return False
    return True


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser(
        prog=Path(argv[0]).name,
        description="Apply tri-state nullable patch to *Update.cs models.",
    )
    parser.add_argument(
        "repo_root",
        nargs="?",
        type=Path,
        help=(
            "Path to the SDK repo root. Defaults to the repo containing this "
            "script. Used by CI when the script lives in a different checkout "
            "(trusted base) than the files being patched (untrusted PR head); "
            "see .github/workflows/patch_speakeasy_regen.yaml."
        ),
    )
    args = parser.parse_args(argv[1:])

    if args.repo_root is not None:
        repo_root = args.repo_root.resolve()
    else:
        repo_root = Path(__file__).resolve().parents[2]
    components = repo_root / "src" / "Gr4vy" / "Models" / "Components"
    if not components.is_dir():
        print(f"error: components directory not found: {components}", file=sys.stderr)
        return 1

    roots = [
        p for p in sorted(components.glob("*Update.cs")) if is_update_request_model(p)
    ]
    reachable = build_reachable_set(roots, components)

    patched = 0
    skipped = 0
    native = 0
    for path in sorted(reachable):
        rel = path.relative_to(repo_root)
        original = path.read_text()
        if "ShouldSerialize" in original:
            # The generator (or a previous run) has already emitted tri-state
            # for this model. Leave it alone so this patch retires cleanly
            # once Speakeasy ships native support.
            print(f"native tri-state, leaving alone: {rel}")
            native += 1
            continue
        result = patch_source(original)
        if result is None or result == original:
            print(f"skipped (no auto-property matches): {rel}")
            skipped += 1
            continue
        path.write_text(result)
        print(f"patched: {rel}")
        patched += 1

    print(
        f"\n{patched} file(s) patched, {native} already tri-state, "
        f"{skipped} skipped (across {len(reachable)} reachable file(s) "
        f"from {len(roots)} *Update.cs root(s))."
    )
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
