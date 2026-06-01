# Generic plan: full-lifecycle E2E test suite for a Speakeasy-generated Gr4vy SDK

This is a **language-agnostic playbook**, distilled from the work done on the
Gr4vy **TypeScript** SDK, for bringing any Gr4vy SDK's test suite up to:

- the **full merchant transaction lifecycle** (processing + back-office), with
- **every API operation exercised at least once** against the real E2E sandbox,
- **partial-update invariants** verified explicitly,
- **property-based ("uncertainty") testing** — the local analog of Python's
  `hypothesis` / TS's `fast-check`,
- a suite that stays **fast and parallel** so it never bottlenecks the
  auto-merge SDK-regen pipeline, and
- a **PR comment reporting endpoint reach**, so newly generated (but untested)
  operations surface on every regen PR and can be backfilled over time.

It is written so it can be re-applied to the C#, Java, Go, PHP, Python, etc.
SDKs — each one is Speakeasy-generated from the same OpenAPI spec and starts
from the same tiny test surface (auth + webhook offline tests + one checkout
flow).

---

## 0. Principles that carry across every language

1. **Generated code is never edited.** All work lives in the test project plus a
   test-runner config, a coverage script, and CI. Confirm the generator's ignore
   rules (`.genignore` / `gen.yaml`) leave the test directory untouched, and
   **pin test-only dependencies in `gen.yaml`** (Speakeasy regenerates the
   package manifest, so deps added only to the manifest are lost on regen).
2. **Per-file (or per-fixture) merchant-account isolation is the parallelism
   primitive.** Each test file/fixture creates its *own* merchant account with a
   random id and provisions a `mock-card` payment service on it. No shared state
   → files run concurrently and shard cleanly.
3. **The `mock-card` connector is the deterministic "test mode."** Approving card
   `4111 1111 1111 1111`, a future expiry, CVV `123`. Document which inputs the
   mock connector declines/errors and assert those paths too.
4. **Keep the forward-compatibility interceptor.** The existing suites wrap the
   HTTP client to inject a random `unexpected_field_*` into every JSON response,
   proving the SDK tolerates unknown fields. Reuse it everywhere.
5. **Endpoint reach is measured from real HTTP calls, not statement coverage.**
   Instrument the test HTTP client to log `method + path` of every request;
   match those against the generated operation catalogue. An operation only
   counts as "reached" if a request was actually sent.
6. **Bounded everything.** Property tests use a small run count and a fixed seed;
   eventually-consistent reads use a `pollUntil` helper with a hard timeout;
   network blips are absorbed with a small retry count. The suite must finish
   well within the per-shard CI timeout.
7. **Open PRs as drafts** (per repo/global convention); let a human mark ready.

---

## 1. Map the starting point (per SDK)

Before writing code, inventory:

- **Operation surface:** one generated artifact per API operation (TS:
  `src/funcs/*.ts`; C#: one method per resource class; Go: per-op files; etc.).
  Count them — this is the denominator for endpoint reach (~107 for Gr4vy today).
- **Existing tests:** typically `auth` (offline JWT), `webhook` (offline
  signature), and a single `checkout-sessions` E2E flow. Keep them.
- **Isolation helper:** how the existing checkout test bootstraps a merchant +
  `mock-card` service — generalize this into a shared factory.
- **Forward-compat interceptor:** find it in the existing checkout test and lift
  it into shared setup.
- **CI workflow:** matrix, timeout, `PRIVATE_KEY` secret, auto-approve +
  auto-merge of `github-actions[bot]` regen PRs, Slack-on-failure, daily cron.
- **Branch protection / rulesets:** note which named status-check contexts are
  *required* — sharding renames matrix jobs and will silently break a ruleset
  that pins the old names (see §7).

---

## 2. Shared test infrastructure

Create a `utils`/helpers layer in the test project:

- **`setup` / `TestEnvironment`** — `setupMerchant()` returning a
  merchant-scoped client + the merchant id + the signing key. Reads the key from
  the `PRIVATE_KEY` env var first, then a git-ignored `private_key.pem`. Wraps
  the HTTP client with the forward-compat interceptor **and** the HTTP-call
  recorder (gated on an env flag, e.g. `GR4VY_TRACK_HTTP`).
- **`fixtures`** — canonical inputs: approving card (future expiry), decline/
  error inputs, reusable address, billing details, cart items, buyer payloads,
  a `uniqueId(prefix)` namespaced by merchant id + index (no wall-clock / RNG
  collisions across shards), and an `unwrap` helper for polymorphic
  transaction/union responses.
- **`poll`** — `pollUntil(fetch, predicate, {timeout, interval})` for
  eventually-consistent states (capture settling, report execution, payout
  status, settlements appearing). Hard-capped so a stuck state fails fast.
- **`fields`** — the raw `PUT /checkout/sessions/{id}/fields` call (a non-public
  endpoint, intentionally raw HTTP, kept out of the SDK), plus a
  `authorizeViaCheckoutSession` helper used by the lifecycle flows.
- **`arbitraries`** — property-test generators (see §4).

## 3. Test suites (one file per resource group → parallel workers)

Organize by story, not just by endpoint:

- **`flows/`** — the headline narratives:
  - `transaction-lifecycle`: checkout → authorize → capture → refund → void →
    sync, asserting status transitions and amounts.
  - `buyer-lifecycle`: buyer → stored payment method → shipping details → reuse
    in a transaction.
- **`processing/`** — per-resource CRUD + actions: transactions (+ actions,
  events, settlements), refunds, checkout-sessions, payment-methods (+ network
  tokens, payment-service tokens), buyers (+ shipping details, gift cards,
  payment methods), gift-cards (+ balances), digital-wallets (+ domains,
  sessions), payment-links.
- **`backoffice/`** — merchant-accounts (+ 3DS config), payment-services
  (+ definitions, options, card-scheme definitions, verify, session),
  three-ds-scenarios, reports (+ executions, url), payouts, audit-logs,
  account-updater jobs.

Every generated operation gets a home. Operations that need real external state
(live wallet provisioning, real network tokens) are exercised at the
**request/validation level** — assert the call shape and that a sane
`4xx`/error comes back — and each such case is **explicitly commented** so the
gap is visible, never silently skipped.

## 4. Partial-update + property-based testing

**Partial-update invariant** — for every resource with an update/PATCH op:
create with a known full payload → update **only a subset** of fields → get →
assert changed fields took effect *and* untouched fields are unchanged. Where
the model supports tri-state nullability, also assert explicit-null **clears**
server-side and an omitted field is **not sent**.

**Property-based ("uncertainty") tests** — use the language's QuickCheck-family
library with a small run count and a fixed seed:

| SDK | Library |
| --- | --- |
| TypeScript | `fast-check` |
| Python | `hypothesis` |
| C# / .NET | `FsCheck` (or `CsCheck`) |
| Java | `jqwik` |
| Go | `testing/quick` or `gopter` |
| PHP | `eris` |

Candidate properties: amount/currency echo on `transactions.create`; metadata
round-trip (mixed camel/snake-case keys survive create→get); the partial-update
invariant parameterized over an arbitrary field subset; external-identifier
uniqueness. Pair them with the forward-compat injector.

## 5. Parallelism & sharding

- Configure the runner for **file-level parallelism** with generous timeouts and
  a small retry count (network resilience). Set a fixed property-test seed.
- **Shard across CI** so each shard owns a few files and wall-clock stays low:
  - vitest: `--shard=$i/$n` (splits files).
  - .NET/NUnit: `[Parallelizable(ParallelScope.Fixtures)]` + `dotnet test
    --filter` ranges, or split by test project / `NUnit.NumberOfTestWorkers`.
  - Java/JUnit5: `junit.jupiter.execution.parallel.enabled` + Surefire forks.
  - Go: native `t.Parallel()` + `-shard`-style `-run` partitioning.

## 6. Endpoint-reach coverage report

- A small script builds the operation catalogue from the generated sources
  (extract each op's method + path template), loads the per-worker HTTP-call
  logs, and matches calls to operations — **most-specific template wins**
  (fewest path params, then longest template), so `/buyers/gift-cards` is not
  miscredited to `/buyers/{id}`.
- Renders a markdown table (endpoints reached `N/M`, plus language coverage %
  as a secondary signal) and the explicit list of **not-reached** operations.
- A CI job runs the suite once un-sharded with the HTTP-tracking flag on, builds
  the report, and posts it as a **sticky PR comment**. This job is **not** a
  merge dependency (it must never block auto-merge). Gate it to same-repo PRs
  (it uses the secret + checks out PR head). Purpose: regen PRs add new
  operations with no tests → they show as "not reached" → backfill over time.

## 7. CI wiring & the auto-merge gate (lesson learned)

- Add the `PRIVATE_KEY` secret to the test job; restrict the secret-backed
  matrix to **same-repo** PRs so forked PRs can't spin up secret-backed sandbox
  calls. Under `pull_request_target`, check out PR head only for trusted
  same-repo PRs; fork PRs fall back to base.
- **Sharding renames matrix jobs**, which breaks any branch ruleset that
  requires the old per-job names. Fix: add a single stable **aggregator job**
  (e.g. `ci-complete`) that `needs` the whole matrix, succeeds only if every
  shard passed, performs the one-time auto-approve, and is the **only** required
  status check + the sole `needs` of the merge job. Point the ruleset at
  `ci-complete`.
- Caveat: under `pull_request_target` the **base** branch's workflow runs, so a
  PR that introduces `ci-complete` can't display its own new check — it needs a
  one-time merge to base before the ruleset can require it.

## 8. Documentation

A `TESTING.md` (linked from the README's preserved/non-generated section)
covering: prerequisites (the key), how to run everything / a single suite / the
lifecycle story / watch mode, how sharding works, how the coverage comment
works, and the note that the test dir + config + this doc are **not**
regenerated and that test deps live in `gen.yaml`.

## 9. Suggested rollout

Either one comprehensive PR (as done for TS) or phased: (1) infra + helpers +
property dep + CI sharding + coverage report; (2) processing flows; (3)
back-office; (4) long-tail (wallets, gift cards, links, tokens). Verify locally
against the sandbox, then open a **draft** PR and let CI's matrix×shard stay
green under timeout.

---

### Per-language adaptation notes

| Concern | TypeScript (done) | C# / .NET (this repo) |
| --- | --- | --- |
| Runner | vitest | NUnit + `dotnet test` |
| Parallelism | `fileParallelism` + `--shard` | `[Parallelizable]` fixtures + filter sharding |
| Forward-compat hook | custom `fetcher` | `SpeakeasyHttpClient` subclass (already present) |
| Property lib | `fast-check` | `FsCheck` |
| HTTP-call recording | fetcher writes JSONL | interceptor `SendAsync` writes JSONL |
| Coverage % | vitest v8 | coverlet (already referenced) |
| Op catalogue source | `src/funcs/*.ts` | `src/Gr4vy/*.cs` resource methods |
| Dep persistence | `gen.yaml` devDependencies | `gen.yaml csharp.additionalDependencies` |
