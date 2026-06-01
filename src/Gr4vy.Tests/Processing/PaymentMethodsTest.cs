using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Processing
{
    /// <summary>
    /// Stored payment method CRUD + partial update, plus the network-token and
    /// payment-service-token sub-resources (reached at the request level — the
    /// mock-card connector does not provision real tokens).
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class PaymentMethodsTest
    {
        private const string MissingId = "11111111-1111-1111-1111-111111111111";

        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        private Task<PaymentMethod> StoreCardAsync() =>
            Client.PaymentMethods.CreateAsync(
                Body.CreateCardPaymentMethodCreate(
                    new CardPaymentMethodCreate
                    {
                        Number = Fixtures.ApprovingCardNumber,
                        ExpirationDate = Fixtures.CardExpirationDate,
                        SecurityCode = Fixtures.CardSecurityCode,
                    }
                )
            );

        [Test]
        public async Task Crud_And_PartialUpdate()
        {
            var pm = await StoreCardAsync();
            Assert.That(pm.Id, Is.Not.Null);

            var fetched = await Client.PaymentMethods.GetAsync(pm.Id);
            Assert.That(fetched.Id, Is.EqualTo(pm.Id));

            var list = await Client.PaymentMethods.ListAsync();
            Assert.That(list.Result, Is.Not.Null);

            // Partial update: change only the expiration date.
            var updated = await Client.PaymentMethods.UpdateAsync(
                pm.Id,
                new PaymentMethodUpdate { ExpirationDate = "12/40" }
            );
            Assert.That(updated.Id, Is.EqualTo(pm.Id));

            await Client.PaymentMethods.DeleteAsync(pm.Id);
        }

        [Test]
        public async Task NetworkTokens_And_ServiceTokens_AreReached()
        {
            var pm = await StoreCardAsync();

            // List network tokens (empty is fine).
            var tokens = await Client.PaymentMethods.NetworkTokens.ListAsync(pm.Id);
            Assert.That(tokens, Is.Not.Null);

            // Provisioning a real network token is not supported by mock-card;
            // exercise the endpoint at the request level.
            await Reach.ReachesAsync(
                () =>
                    Client.PaymentMethods.NetworkTokens.CreateAsync(
                        pm.Id,
                        new NetworkTokenCreate { MerchantInitiated = false, IsSubsequentPayment = false }
                    ),
                "network-tokens.create"
            );

            await Reach.ReachesAsync(
                () => Client.PaymentMethods.PaymentServiceTokens.ListAsync(pm.Id),
                "payment-service-tokens.list"
            );

            // The remaining network-token + payment-service-token operations need a
            // provisioned token id the mock connector does not produce; reach them
            // with a placeholder id so the endpoints are still exercised.
            await Reach.ReachesAsync(
                () => Client.PaymentMethods.NetworkTokens.SuspendAsync(pm.Id, MissingId),
                "network-tokens.suspend"
            );
            await Reach.ReachesAsync(
                () => Client.PaymentMethods.NetworkTokens.ResumeAsync(pm.Id, MissingId),
                "network-tokens.resume"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.PaymentMethods.NetworkTokens.Cryptogram.CreateAsync(
                        pm.Id,
                        MissingId,
                        new CryptogramCreate { MerchantInitiated = false }
                    ),
                "network-tokens.cryptogram.create"
            );
            await Reach.ReachesAsync(
                () => Client.PaymentMethods.NetworkTokens.DeleteAsync(pm.Id, MissingId),
                "network-tokens.delete"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.PaymentMethods.PaymentServiceTokens.CreateAsync(
                        pm.Id,
                        new PaymentServiceTokenCreate
                        {
                            PaymentServiceId = MissingId,
                            RedirectUrl = "https://example.com/return",
                        }
                    ),
                "payment-service-tokens.create"
            );
            await Reach.ReachesAsync(
                () => Client.PaymentMethods.PaymentServiceTokens.DeleteAsync(pm.Id, MissingId),
                "payment-service-tokens.delete"
            );
        }
    }
}
