using System.Collections.Generic;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Backoffice
{
    /// <summary>
    /// Reporting endpoints. List + the top-level executions list are happy paths;
    /// create/get/put and per-report executions need a configured report
    /// definition (complex Spec), so they are reached at the request level.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class ReportsTest
    {
        private const string MissingId = "11111111-1111-1111-1111-111111111111";

        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task List_Endpoints()
        {
            var reports = await Client.Reports.ListAsync();
            Assert.That(reports.Result, Is.Not.Null);

            var allExecutions = await Client.ReportExecutions.ListAsync();
            Assert.That(allExecutions.Result, Is.Not.Null);
        }

        [Test]
        public async Task Report_And_Execution_Endpoints_AreReached()
        {
            await Reach.ReachesAsync(
                () =>
                    Client.Reports.CreateAsync(
                        new ReportCreate
                        {
                            Name = "Daily transactions",
                            Schedule = "0 0 * * *",
                            ScheduleEnabled = false,
                            // `spec` was flattened from a union to a plain object
                            // (overlay fix-report-spec-union.yaml, #212) so it can no
                            // longer serialize to null — `model` is required, which
                            // prevents the CORE-API-3AE crash.
                            Spec = new Spec
                            {
                                Model = "transactions",
                                Params = new Dictionary<string, object>(),
                            },
                        }
                    ),
                "reports.create"
            );
            await Reach.ReachesAsync(
                () => Client.Reports.PutAsync(MissingId, new ReportUpdate { Name = "Renamed" }),
                "reports.put"
            );
            await Reach.ReachesAsync(() => Client.Reports.GetAsync(MissingId), "reports.get");
            await Reach.ReachesAsync(
                () => Client.Reports.Executions.ListAsync(MissingId),
                "reports.executions.list"
            );
            await Reach.ReachesAsync(
                () => Client.Reports.Executions.GetAsync(MissingId, MissingId),
                "reports.executions.get"
            );
            await Reach.ReachesAsync(
                () => Client.Reports.Executions.UrlAsync(MissingId, MissingId),
                "reports.executions.url"
            );
        }
    }
}
