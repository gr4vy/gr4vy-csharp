using System.Collections.Generic;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Backoffice
{
    /// <summary>
    /// Remaining back-office endpoints: audit logs, payment options, the
    /// account-updater job, and the merchant-account 3DS configuration CRUD.
    /// Config/job creates need real provider data, so they are reached at the
    /// request level.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class BackofficeMiscTest
    {
        private const string MissingId = "11111111-1111-1111-1111-111111111111";

        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task AuditLogs_List()
        {
            var list = await Client.AuditLogs.ListAsync();
            Assert.That(list.Result, Is.Not.Null);
        }

        [Test]
        public async Task PaymentOptions_List()
        {
            var options = await Client.PaymentOptions.ListAsync(
                new PaymentOptionRequest { Country = "US", Currency = "USD", Amount = 1299 }
            );
            Assert.That(options, Is.Not.Null);
        }

        [Test]
        public async Task AccountUpdater_Job_IsReached()
        {
            await Reach.ReachesAsync(
                () =>
                    Client.AccountUpdater.Jobs.CreateAsync(
                        new AccountUpdaterJobCreate
                        {
                            PaymentMethodIds = new List<string> { MissingId },
                        }
                    ),
                "account-updater.jobs.create"
            );
        }

        [Test]
        public async Task ThreeDsConfiguration_Crud_IsReached()
        {
            await Reach.ReachesAsync(
                () =>
                    Client.MerchantAccounts.ThreeDsConfiguration.CreateAsync(
                        _m.MerchantAccountId,
                        new MerchantAccountThreeDSConfigurationCreate
                        {
                            MerchantAcquirerBin = "123456",
                            MerchantAcquirerId = "acq-1",
                            MerchantName = "Gr4vy Test",
                            MerchantCountryCode = "US",
                            MerchantCategoryCode = "5411",
                            MerchantUrl = "https://example.com",
                            Scheme = "visa",
                        }
                    ),
                "three-ds-configuration.create"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.MerchantAccounts.ThreeDsConfiguration.UpdateAsync(
                        _m.MerchantAccountId,
                        MissingId,
                        new MerchantAccountThreeDSConfigurationUpdate()
                    ),
                "three-ds-configuration.update"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.MerchantAccounts.ThreeDsConfiguration.DeleteAsync(
                        _m.MerchantAccountId,
                        MissingId
                    ),
                "three-ds-configuration.delete"
            );
        }
    }
}
