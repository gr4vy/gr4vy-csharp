using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Backoffice
{
    /// <summary>
    /// Payout endpoints. List is a happy path; create/get need a payout-capable
    /// payment service the mock environment does not provide, so they are reached
    /// at the request level.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class PayoutsTest
    {
        private const string MissingId = "11111111-1111-1111-1111-111111111111";

        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task List_And_Reached()
        {
            var list = await Client.Payouts.ListAsync();
            Assert.That(list.Result, Is.Not.Null);

            await Reach.ReachesAsync(() => Client.Payouts.GetAsync(MissingId), "payouts.get");

            await Reach.ReachesAsync(
                () =>
                    Client.Payouts.CreateAsync(
                        new PayoutCreate
                        {
                            Amount = 1299,
                            Currency = "USD",
                            PaymentServiceId = MissingId,
                            PaymentMethod = PayoutCreatePaymentMethod.CreatePaymentMethodStoredCard(
                                new PaymentMethodStoredCard { Id = MissingId }
                            ),
                        }
                    ),
                "payouts.create"
            );
        }
    }
}
