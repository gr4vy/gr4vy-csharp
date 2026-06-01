using System;
using System.Threading.Tasks;

namespace Gr4vy.Tests.Utils
{
    /// <summary>
    /// Bounded polling for eventually-consistent reads (capture settling, report
    /// execution finishing, payout/settlement appearing). Hard-capped so a stuck
    /// state fails fast rather than hanging a worker.
    /// </summary>
    public static class Poll
    {
        public static async Task<T> UntilAsync<T>(
            Func<Task<T>> fetch,
            Func<T, bool> predicate,
            int timeoutMs = 20000,
            int intervalMs = 1000,
            string? description = null
        )
        {
            var deadline = DateTime.UtcNow.AddMilliseconds(timeoutMs);
            T last = default!;
            while (DateTime.UtcNow < deadline)
            {
                last = await fetch();
                if (predicate(last))
                    return last;
                await Task.Delay(intervalMs);
            }
            throw new TimeoutException(
                $"pollUntil timed out after {timeoutMs}ms"
                    + (description != null ? $" waiting for: {description}" : "")
            );
        }
    }
}
