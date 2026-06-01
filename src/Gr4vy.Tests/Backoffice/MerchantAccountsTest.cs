using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Backoffice
{
    /// <summary>
    /// Merchant account CRUD + partial update, plus the 3DS configuration
    /// sub-resource (reached at the request level — it requires real 3DS provider
    /// credentials the sandbox cannot validate).
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class MerchantAccountsTest
    {
        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task Get_List_Update()
        {
            // The fixture's merchant account already exists (created in setup).
            var fetched = await Client.MerchantAccounts.GetAsync(_m.MerchantAccountId);
            Assert.That(fetched.Id, Is.EqualTo(_m.MerchantAccountId));

            var list = await Client.MerchantAccounts.ListAsync();
            Assert.That(list.Result, Is.Not.Null);

            // Partial update: change only the over-capture amount.
            var updated = await Client.MerchantAccounts.UpdateAsync(
                _m.MerchantAccountId,
                new MerchantAccountUpdate { OverCaptureAmount = 100 }
            );
            Assert.That(updated.Id, Is.EqualTo(_m.MerchantAccountId));
        }

        [Test]
        public async Task ThreeDsConfiguration_IsReached()
        {
            await Reach.ReachesAsync(
                () => Client.MerchantAccounts.ThreeDsConfiguration.ListAsync(_m.MerchantAccountId),
                "three-ds-configuration.list"
            );
        }
    }
}
