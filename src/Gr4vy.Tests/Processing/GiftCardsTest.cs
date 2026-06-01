using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Processing
{
    /// <summary>
    /// Gift card endpoints. The mock environment has no gift-card service, so
    /// create/get/delete/balances are exercised at the request level (a real
    /// request is sent and a documented API error is accepted) while list is a
    /// happy path. This keeps every gift-card operation reached, never skipped.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class GiftCardsTest
    {
        private const string MissingId = "11111111-1111-1111-1111-111111111111";

        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task GiftCardEndpoints_AreReached()
        {
            var list = await Client.GiftCards.ListAsync();
            Assert.That(list.Result, Is.Not.Null);

            await Reach.ReachesAsync(
                () =>
                    Client.GiftCards.CreateAsync(
                        new GiftCardCreate { Number = "4111111111111111", Pin = "1234" }
                    ),
                "gift-cards.create"
            );

            await Reach.ReachesAsync(() => Client.GiftCards.GetAsync(MissingId), "gift-cards.get");
            await Reach.ReachesAsync(
                () =>
                    Client.GiftCards.Balances.ListAsync(
                        new GiftCardBalanceRequest { Items = new List<Item>() }
                    ),
                "gift-cards.balances.list"
            );
            await Reach.ReachesAsync(
                () => Client.GiftCards.DeleteAsync(MissingId),
                "gift-cards.delete"
            );
        }
    }
}
