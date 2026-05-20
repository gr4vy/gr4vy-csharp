#!/usr/bin/env python3
"""
Post-generation patch for *Update.cs models.

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

import re
import sys
from pathlib import Path

PROP_RE = re.compile(
    r"(?P<indent>[ \t]*)"
    r"(?P<attr>\[JsonProperty\([^\]]*\)\])\s*\n"
    r"[ \t]*public\s+(?P<type_and_name>.+?)\s*\{\s*get;\s*set;\s*\}\s*=\s*(?P<default>[^;]+);",
    re.MULTILINE,
)


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

        if "NullValueHandling" in attr:
            new_attr = attr
        else:
            new_attr = attr[:-2] + ", NullValueHandling = NullValueHandling.Include)]"

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


def is_update_request_model(path: Path) -> bool:
    """Filter for files matching *Update.cs but excluding noun-form 'Updater' names."""
    name = path.name
    if not name.endswith("Update.cs"):
        return False
    if name.startswith("AccountUpdater"):
        return False
    return True


def main(argv: list[str]) -> int:
    repo_root = Path(__file__).resolve().parents[2]
    components = repo_root / "src" / "Gr4vy" / "Models" / "Components"
    if not components.is_dir():
        print(f"error: components directory not found: {components}", file=sys.stderr)
        return 1

    patched = 0
    skipped = 0
    native = 0
    for path in sorted(components.glob("*Update.cs")):
        if not is_update_request_model(path):
            continue
        original = path.read_text()
        if "ShouldSerialize" in original:
            # The generator (or a previous run) has already emitted tri-state
            # for this model. Leave it alone so this patch retires cleanly
            # once Speakeasy ships native support.
            print(f"native tri-state, leaving alone: {path.relative_to(repo_root)}")
            native += 1
            continue
        result = patch_source(original)
        if result is None or result == original:
            print(f"skipped (no auto-property matches): {path.relative_to(repo_root)}")
            skipped += 1
            continue
        path.write_text(result)
        print(f"patched: {path.relative_to(repo_root)}")
        patched += 1

    print(
        f"\n{patched} file(s) patched, {native} already tri-state, {skipped} skipped."
    )
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
