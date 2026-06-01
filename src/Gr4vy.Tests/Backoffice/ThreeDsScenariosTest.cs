using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Backoffice
{
    /// <summary>
    /// 3DS scenario endpoints. List is a happy path; create/update/delete require
    /// a fully specified scenario (conditions + outcome) and are reached at the
    /// request level.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class ThreeDsScenariosTest
    {
        private const string MissingId = "11111111-1111-1111-1111-111111111111";

        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task List_And_Reached()
        {
            var list = await Client.ThreeDsScenarios.ListAsync();
            Assert.That(list.Result, Is.Not.Null);

            await Reach.ReachesAsync(
                () =>
                    Client.ThreeDsScenarios.CreateAsync(
                        new ThreeDSecureScenarioCreate
                        {
                            Conditions = new ThreeDSecureScenarioConditions(),
                            Outcome = new ThreeDSecureScenarioOutcome
                            {
                                Authentication = new ThreeDSecureScenarioOutcomeAuthentication
                                {
                                    TransactionStatus = "authorized",
                                },
                            },
                        }
                    ),
                "three-ds-scenarios.create"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.ThreeDsScenarios.UpdateAsync(
                        MissingId,
                        new ThreeDSecureScenarioUpdate()
                    ),
                "three-ds-scenarios.update"
            );
            await Reach.ReachesAsync(
                () => Client.ThreeDsScenarios.DeleteAsync(MissingId),
                "three-ds-scenarios.delete"
            );
        }
    }
}
