using System.Collections.Generic;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Flows
{
    /// <summary>
    /// The headline merchant story: authorize a card transaction directly against
    /// POST /transactions (the non-checkout-session path), then exercise the
    /// processing lifecycle — capture, refund, sync, list, update, and the
    /// transaction sub-resources (actions, events, settlements). A separate
    /// transaction is authorized then voided.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class TransactionLifecycleTest
    {
        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        private TransactionCreate AuthorizeRequest(long amount = 1299, string intent = "authorize") =>
            new TransactionCreate
            {
                Amount = amount,
                Currency = "USD",
                Country = "US",
                Intent = intent,
                PaymentMethod = TransactionCreatePaymentMethod.CreateCardWithUrlPaymentMethodCreate(
                    new CardWithUrlPaymentMethodCreate
                    {
                        Number = Fixtures.ApprovingCardNumber,
                        ExpirationDate = Fixtures.CardExpirationDate,
                        SecurityCode = Fixtures.CardSecurityCode,
                    }
                ),
            };

        [Test]
        public async Task AuthorizeCaptureRefund_FullLifecycle()
        {
            // 1. Authorize
            var txn = await Client.Transactions.CreateAsync(AuthorizeRequest());
            Assert.That(txn.Id, Is.Not.Null);
            Assert.That(txn.Status, Is.EqualTo("authorization_succeeded"));
            Assert.That(txn.Amount, Is.EqualTo(1299));

            // 2. Get + list
            var fetched = await Client.Transactions.GetAsync(txn.Id);
            Assert.That(fetched.Id, Is.EqualTo(txn.Id));

            var list = await Client.Transactions.ListAsync();
            Assert.That(list.Result, Is.Not.Null);

            // 3. Capture (full)
            var captured = await Client.Transactions.CaptureAsync(
                new CaptureTransactionRequest
                {
                    TransactionId = txn.Id,
                    TransactionCaptureCreate = new TransactionCaptureCreate { Amount = txn.Amount },
                }
            );
            Assert.That(captured, Is.Not.Null);

            // 4. Sub-resources: actions, events, settlements list
            var actions = await Client.Transactions.Actions.ListAsync(txn.Id);
            Assert.That(actions, Is.Not.Null);

            var events = await Client.Transactions.Events.ListAsync(txn.Id);
            Assert.That(events.Result, Is.Not.Null);

            var settlements = await Client.Transactions.Settlements.ListAsync(txn.Id);
            Assert.That(settlements, Is.Not.Null);

            // 5. Refund the captured transaction (+ list + get)
            var refund = await Client.Transactions.Refunds.CreateAsync(
                txn.Id,
                new TransactionRefundCreate { Amount = 100 }
            );
            Assert.That(refund.Id, Is.Not.Null);

            var refundList = await Client.Transactions.Refunds.ListAsync(txn.Id);
            Assert.That(refundList.Items, Is.Not.Null);

            var refundGet = await Client.Transactions.Refunds.GetAsync(txn.Id, refund.Id!);
            Assert.That(refundGet.Id, Is.EqualTo(refund.Id));

            // 6. Top-level refunds.get
            var topRefund = await Client.Refunds.GetAsync(refund.Id!);
            Assert.That(topRefund.Id, Is.EqualTo(refund.Id));

            // 7. Refund-all + settlement get (reached at the request level — the
            // remaining balance may be zero after the partial refund above, and the
            // mock connector produces no settlement record to fetch by id).
            await Reach.ReachesAsync(
                () => Client.Transactions.Refunds.All.CreateAsync(txn.Id),
                "transactions.refunds.all.create"
            );
            await Reach.ReachesAsync(
                () => Client.Transactions.Settlements.GetAsync(txn.Id, "11111111-1111-1111-1111-111111111111"),
                "transactions.settlements.get"
            );
        }

        [Test]
        public async Task Sync_IsRejectedForMockCard()
        {
            // The mock-card connector does not support sync. Exercise the endpoint
            // at the request level and assert the documented 400 so the operation is
            // still reached by the suite.
            var txn = await Client.Transactions.CreateAsync(AuthorizeRequest());
            var ex = Assert.ThrowsAsync<Gr4vy.Models.Errors.Error400>(
                async () => await Client.Transactions.SyncAsync(txn.Id)
            );
            Assert.That(ex!.Message, Does.Contain("sync is not supported"));
        }

        [Test]
        public async Task Authorize_ThenVoid()
        {
            var txn = await Client.Transactions.CreateAsync(AuthorizeRequest());
            Assert.That(txn.Status, Is.EqualTo("authorization_succeeded"));

            var voided = await Client.Transactions.VoidAsync(txn.Id);
            Assert.That(voided, Is.Not.Null);
        }
    }
}
