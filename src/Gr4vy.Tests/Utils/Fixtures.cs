using System.Threading;
using Gr4vy.Models.Components;

namespace Gr4vy.Tests.Utils
{
    /// <summary>
    /// Canonical inputs for the mock-card connector and reusable request shapes.
    /// The mock connector approves 4111&#8230; and a future expiry; other inputs
    /// (documented inline where used) drive decline/error paths.
    /// </summary>
    public static class Fixtures
    {
        // Approving test card for the mock-card service. Far-future expiry so the
        // suite does not start failing once a year ticks over.
        public const string ApprovingCardNumber = "4111111111111111";
        public const string CardExpirationDate = "12/35";
        public const string CardSecurityCode = "123";

        private static int _counter;

        /// <summary>
        /// Collision-free identifier namespaced by a caller-supplied scope (pass the
        /// merchant id) plus a process-wide counter — no wall-clock / RNG so parallel
        /// shards never collide.
        /// </summary>
        public static string UniqueId(string prefix, string scope)
        {
            var n = Interlocked.Increment(ref _counter);
            var shortScope = scope.Length > 8 ? scope.Substring(0, 8) : scope;
            return $"{prefix}-{shortScope}-{n}";
        }

        public static CardPaymentMethodCreate ApprovingCard(
            string? externalIdentifier = null,
            string? buyerId = null
        ) =>
            new CardPaymentMethodCreate
            {
                Number = ApprovingCardNumber,
                ExpirationDate = CardExpirationDate,
                SecurityCode = CardSecurityCode,
                ExternalIdentifier = externalIdentifier,
                BuyerId = buyerId,
            };

        public static Address SampleAddress() =>
            new Address
            {
                City = "London",
                Country = "GB",
                PostalCode = "789",
                State = "London",
                HouseNumberOrName = "10",
            };

        public static BillingDetails SampleBillingDetails() =>
            new BillingDetails
            {
                FirstName = "John",
                LastName = "Lunn",
                EmailAddress = "john@example.com",
                Address = SampleAddress(),
            };

        public static CartItem SampleCartItem(string name = "T-Shirt") =>
            new CartItem
            {
                Name = name,
                Quantity = 1,
                UnitAmount = 1299,
            };
    }
}
