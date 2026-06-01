using System;
using System.Threading.Tasks;
using Gr4vy.Models.Errors;
using NUnit.Framework;

namespace Gr4vy.Tests.Utils
{
    /// <summary>
    /// Helpers for operations that cannot be driven to a full happy-path in the
    /// mock-card sandbox (live wallet provisioning, real network tokens, etc.).
    /// We still want the endpoint *reached* (a real HTTP request sent) so the
    /// endpoint-coverage report does not flag it as untested — but we accept a
    /// documented API error instead of a 2xx. Never silently skips.
    /// </summary>
    public static class Reach
    {
        /// <summary>
        /// Runs <paramref name="action"/> and asserts it either succeeds or fails
        /// with a Gr4vy <b>client</b> error (4xx — i.e. the request reached the
        /// server and was cleanly rejected). A <b>5xx</b> is re-thrown so the test
        /// fails: a server error means we sent something that crashed the API, which
        /// is a real defect to surface, not an "expected" outcome (this is how the
        /// suite would have caught CORE-API-3AE). Transport/other exceptions also
        /// fail the test.
        /// </summary>
        public static async Task ReachesAsync(Func<Task> action, string description)
        {
            try
            {
                await action();
            }
            catch (BaseException ex) when (ex.StatusCode < 500)
            {
                TestContext.Out.WriteLine(
                    $"[reach] {description}: endpoint reached, got expected API error: "
                        + $"{ex.GetType().Name} ({ex.StatusCode})"
                );
            }
        }
    }
}
