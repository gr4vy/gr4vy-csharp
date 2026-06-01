using NUnit.Framework;

// Run test fixtures concurrently. Each fixture provisions its own isolated
// merchant account (see Utils/TestEnvironment.cs), so fixtures never share state
// and are safe to parallelize. Tests *within* a fixture stay sequential, which
// keeps each merchant-scoped flow ordered. CI additionally shards fixtures across
// jobs (see .github/workflows/ci.yaml).
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(8)]
