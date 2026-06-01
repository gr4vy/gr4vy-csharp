using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Flows
{
    /// <summary>
    /// Buyer story: create a buyer, store a card payment method against it, attach
    /// shipping details, list the buyer's sub-resources, then reuse the buyer in a
    /// transaction.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class BuyerLifecycleTest
    {
        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task Buyer_StoredMethod_Shipping_Transaction()
        {
            // 1. Create + update a buyer
            var buyer = await Client.Buyers.CreateAsync(
                new BuyerCreate
                {
                    DisplayName = "Jane Doe",
                    ExternalIdentifier = Fixtures.UniqueId("buyer", _m.MerchantAccountId),
                }
            );
            Assert.That(buyer.Id, Is.Not.Null);

            var updated = await Client.Buyers.UpdateAsync(
                buyer.Id!,
                new BuyerUpdate { DisplayName = "Jane Updated" }
            );
            Assert.That(updated.DisplayName, Is.EqualTo("Jane Updated"));

            // 2. Store a card payment method against the buyer
            var pm = await Client.PaymentMethods.CreateAsync(
                Body.CreateCardPaymentMethodCreate(
                    new CardPaymentMethodCreate
                    {
                        Number = Fixtures.ApprovingCardNumber,
                        ExpirationDate = Fixtures.CardExpirationDate,
                        SecurityCode = Fixtures.CardSecurityCode,
                        BuyerId = buyer.Id,
                    }
                )
            );
            Assert.That(pm.Id, Is.Not.Null);

            // 3. List the buyer's payment methods + gift cards
            var buyerPms = await Client.Buyers.PaymentMethods.ListAsync(
                new ListBuyerPaymentMethodsRequest { BuyerId = buyer.Id }
            );
            Assert.That(buyerPms.Items, Is.Not.Null);

            var buyerGiftCards = await Client.Buyers.GiftCards.ListAsync(
                new ListBuyerGiftCardsRequest { BuyerId = buyer.Id }
            );
            Assert.That(buyerGiftCards.Items, Is.Not.Null);

            // 4. Shipping details CRUD
            var shipping = await Client.Buyers.ShippingDetails.CreateAsync(
                buyer.Id!,
                new ShippingDetailsCreate
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = Fixtures.SampleAddress(),
                }
            );
            Assert.That(shipping.Id, Is.Not.Null);

            var shippingList = await Client.Buyers.ShippingDetails.ListAsync(buyer.Id!);
            Assert.That(shippingList.Items, Is.Not.Null);

            var shippingGet = await Client.Buyers.ShippingDetails.GetAsync(buyer.Id!, shipping.Id!);
            Assert.That(shippingGet.Id, Is.EqualTo(shipping.Id));

            var shippingUpdated = await Client.Buyers.ShippingDetails.UpdateAsync(
                buyer.Id!,
                shipping.Id!,
                new ShippingDetailsUpdate { LastName = "Updated" }
            );
            Assert.That(shippingUpdated.LastName, Is.EqualTo("Updated"));

            // 5. Use the stored method in a transaction via the buyer
            var txn = await Client.Transactions.CreateAsync(
                new TransactionCreate
                {
                    Amount = 1299,
                    Currency = "USD",
                    Country = "US",
                    BuyerId = buyer.Id,
                    PaymentMethod =
                        TransactionCreatePaymentMethod.CreateTokenPaymentMethodCreate(
                            new TokenPaymentMethodCreate { Id = pm.Id }
                        ),
                }
            );
            Assert.That(txn.Status, Is.EqualTo("authorization_succeeded"));

            // 6. Buyer get + list
            var buyerGet = await Client.Buyers.GetAsync(buyer.Id!);
            Assert.That(buyerGet.Id, Is.EqualTo(buyer.Id));

            var buyerList = await Client.Buyers.ListAsync();
            Assert.That(buyerList.Result, Is.Not.Null);

            // 7. Clean up shipping + buyer (delete endpoints)
            await Client.Buyers.ShippingDetails.DeleteAsync(buyer.Id!, shipping.Id!);
            await Client.Buyers.DeleteAsync(buyer.Id!);
        }
    }
}
