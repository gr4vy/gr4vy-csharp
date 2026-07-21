using System.Collections.Generic;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Backoffice
{
    /// <summary>
    /// API key pair endpoints. List is a happy path; create/get/update/delete are
    /// reached at the request level. API key pairs are an ACCOUNT-LEVEL resource
    /// (like merchant_accounts): they are not scoped to a single merchant account,
    /// so — mirroring <see cref="MerchantAccountsTest"/> — the fixture's client is
    /// fine (an account-level endpoint ignores the merchant-account header the
    /// scoped client carries). Create requires a real role id and get/update/delete
    /// require a real key-pair id, neither of which the isolated mock fixture
    /// provisions, so those are driven to a clean 4xx instead of a 2xx.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class ApiKeyPairsTest
    {
        private const string MissingId = "11111111-1111-1111-1111-111111111111";

        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task List_And_Reached()
        {
            var list = await Client.ApiKeyPairs.ListAsync();
            Assert.That(list.Result, Is.Not.Null);

            // Create references a nonexistent role id, so the request reaches the
            // server and is cleanly rejected (no valid role to assign here).
            await Reach.ReachesAsync(
                () =>
                    Client.ApiKeyPairs.CreateAsync(
                        new APIKeyPairCreate
                        {
                            DisplayName = "SDK test key pair",
                            RoleIds = new List<string> { MissingId },
                        }
                    ),
                "api-key-pairs.create"
            );

            await Reach.ReachesAsync(
                () => Client.ApiKeyPairs.GetAsync(MissingId),
                "api-key-pairs.get"
            );

            await Reach.ReachesAsync(
                () =>
                    Client.ApiKeyPairs.UpdateAsync(
                        MissingId,
                        new APIKeyPairUpdate { DisplayName = "SDK test key pair (updated)" }
                    ),
                "api-key-pairs.update"
            );

            await Reach.ReachesAsync(
                () => Client.ApiKeyPairs.DeleteAsync(MissingId),
                "api-key-pairs.delete"
            );
        }
    }
}
