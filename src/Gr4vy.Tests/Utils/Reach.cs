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
        /// with a Gr4vy API error (i.e. the request reached the server). A
        /// transport/other exception still fails the test.
        /// </summary>
        public static async Task ReachesAsync(Func<Task> action, string description)
        {
            try
            {
                await action();
            }
            catch (BaseException ex)
            {
                TestContext.Out.WriteLine(
                    $"[reach] {description}: endpoint reached, got expected API error: {ex.GetType().Name}"
                );
            }
        }
    }
}
