using System.Collections.Generic;
using System.Threading.Tasks;
using FsCheck;
using FsCheck.NUnit;
using FsProperty = FsCheck.NUnit.PropertyAttribute;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

// FsCheck.NUnit supplies the generated arguments at run time; the NUnit analyzer
// does not understand this and would flag the parameters as unsupplied.
#pragma warning disable NUnit1027 // The test method has parameters supplied by FsCheck

namespace Gr4vy.Tests
{
    /// <summary>
    /// Property-based ("uncertainty") tests — the .NET analog of fast-check /
    /// hypothesis. Bounded <c>MaxTest</c> + a fixed <c>Replay</c> seed keep the E2E
    /// cost low and the runs reproducible. FsCheck generates the inputs; each
    /// property asserts an invariant against the live sandbox.
    /// </summary>
    [TestFixture]
    public class PropertyTests
    {
        // Fixed seed so the generated cases are identical run-to-run / across shards.
        private const string Seed = "42,1337";

        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        private async Task<Transaction> AuthorizeAsync(long amount)
        {
            return await Client.Transactions.CreateAsync(
                new TransactionCreate
                {
                    Amount = amount,
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
        }

        /// <summary>
        /// For any accepted amount, authorizing echoes the amount and currency back.
        /// </summary>
        [FsProperty(MaxTest = 5, Replay = Seed, Arbitrary = new[] { typeof(GravyArbitraries) })]
        public bool Authorize_EchoesAmountAndCurrency(SafeAmount amount)
        {
            var txn = AuthorizeAsync(amount.Value).GetAwaiter().GetResult();
            return txn.Status == "authorization_succeeded"
                && txn.Amount == amount.Value
                && txn.Currency == "USD";
        }

        /// <summary>
        /// Partial-update invariant: updating only a buyer's display name leaves its
        /// external identifier untouched, for any generated pair of names.
        /// </summary>
        [FsProperty(MaxTest = 5, Replay = Seed, Arbitrary = new[] { typeof(GravyArbitraries) })]
        public bool BuyerUpdate_PreservesUntouchedFields(SafeName initial, SafeName next)
        {
            var ext = Fixtures.UniqueId("prop", _m.MerchantAccountId);
            var created = Client
                .Buyers.CreateAsync(
                    new BuyerCreate { DisplayName = initial.Value, ExternalIdentifier = ext }
                )
                .GetAwaiter()
                .GetResult();

            Client
                .Buyers.UpdateAsync(created.Id!, new BuyerUpdate { DisplayName = next.Value })
                .GetAwaiter()
                .GetResult();

            var fetched = Client.Buyers.GetAsync(created.Id!).GetAwaiter().GetResult();
            return fetched.DisplayName == next.Value && fetched.ExternalIdentifier == ext;
        }
    }

    /// <summary>Domain-aware FsCheck generators, bounded to values mock-card accepts.</summary>
    public static class GravyArbitraries
    {
        public static Arbitrary<SafeAmount> SafeAmount() =>
            Arb.From(Gen.Choose(50, 100000).Select(i => new SafeAmount(i)));

        public static Arbitrary<SafeName> SafeName() =>
            Arb.From(
                Gen.Elements(new[] { "Ada", "Grace", "Linus", "Margaret", "Alan", "Katherine" })
                    .Select(s => new SafeName(s))
            );
    }

    public sealed record SafeAmount(long Value);

    public sealed record SafeName(string Value);
}
