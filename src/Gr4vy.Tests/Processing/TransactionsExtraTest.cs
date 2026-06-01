using System.Collections.Generic;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Processing
{
    /// <summary>
    /// Transaction operations not covered by the lifecycle flow: manual update
    /// (metadata round-trip) and cancel (reached at the request level — an already
    /// authorized mock transaction cannot be cancelled).
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class TransactionsExtraTest
    {
        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        private Task<Transaction> AuthorizeAsync() =>
            Client.Transactions.CreateAsync(
                new TransactionCreate
                {
                    Amount = 1299,
                    Currency = "USD",
                    Country = "US",
                    Intent = "authorize",
                    PaymentMethod = TransactionCreatePaymentMethod.CreateCardWithUrlPaymentMethodCreate(
                        new CardWithUrlPaymentMethodCreate
                        {
                            Number = Fixtures.ApprovingCardNumber,
                            ExpirationDate = Fixtures.CardExpirationDate,
                            SecurityCode = Fixtures.CardSecurityCode,
                        }
                    ),
                }
            );

        [Test]
        public async Task Update_MetadataRoundTrips()
        {
            var txn = await AuthorizeAsync();

            var updated = await Client.Transactions.UpdateAsync(
                txn.Id,
                new TransactionUpdate
                {
                    Metadata = new Dictionary<string, string> { ["order_id"] = "abc-123" },
                }
            );
            Assert.That(updated.Id, Is.EqualTo(txn.Id));

            var fetched = await Client.Transactions.GetAsync(txn.Id);
            Assert.That(fetched.Metadata, Is.Not.Null);
            Assert.That(fetched.Metadata!["order_id"], Is.EqualTo("abc-123"));
        }

        [Test]
        public async Task Cancel_IsReached()
        {
            var txn = await AuthorizeAsync();
            await Reach.ReachesAsync(
                () => Client.Transactions.CancelAsync(txn.Id),
                "transactions.cancel"
            );
        }
    }
}
