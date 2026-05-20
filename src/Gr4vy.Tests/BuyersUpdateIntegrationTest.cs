using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using NUnit.Framework;

namespace Gr4vy.Tests
{
    /// <summary>
    /// End-to-end tests against the e2e sandbox proving that the tri-state
    /// nullable patch on *Update request models behaves correctly on the wire:
    /// explicit null actually clears a field on the server, and an untouched
    /// property leaves the existing value alone (the partial-update path).
    /// </summary>
    [TestFixture]
    public class BuyersUpdateIntegrationTests
    {
        private Gr4vySDK _client = null!;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            var privateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY");
            if (privateKey == null)
            {
                privateKey = File.ReadAllText("../../../../../private_key.pem");
            }

            var bootstrap = new Gr4vySDK(
                id: "e2e",
                server: SDKConfig.Server.Sandbox,
                bearerAuthSource: Auth.WithToken(privateKey)
            );

            var merchantAccountId = BitConverter
                .ToString(RandomNumberGenerator.GetBytes(8))
                .Replace("-", "")
                .ToLower();

            await bootstrap.MerchantAccounts.CreateAsync(
                new MerchantAccountCreate()
                {
                    Id = merchantAccountId,
                    DisplayName = merchantAccountId,
                }
            );

            _client = new Gr4vySDK(
                id: "e2e",
                server: SDKConfig.Server.Sandbox,
                bearerAuthSource: Auth.WithToken(privateKey),
                merchantAccountId: merchantAccountId
            );
        }

        [Test]
        public async Task ExplicitNull_ClearsField_OnServer()
        {
            var created = await _client.Buyers.CreateAsync(
                new BuyerCreate
                {
                    DisplayName = "Original Name",
                    ExternalIdentifier = "ext-to-clear",
                }
            );
            Assert.That(created.Id, Is.Not.Null);
            Assert.That(created.ExternalIdentifier, Is.EqualTo("ext-to-clear"));

            await _client.Buyers.UpdateAsync(
                created.Id!,
                new BuyerUpdate { ExternalIdentifier = null }
            );

            var fetched = await _client.Buyers.GetAsync(created.Id!);
            Assert.That(fetched.ExternalIdentifier, Is.Null);
            Assert.That(
                fetched.DisplayName,
                Is.EqualTo("Original Name"),
                "Untouched fields must not be modified when clearing another field."
            );
        }

        [Test]
        public async Task UntouchedField_IsPreserved_OnServer()
        {
            var created = await _client.Buyers.CreateAsync(
                new BuyerCreate
                {
                    DisplayName = "Original Name",
                    ExternalIdentifier = "ext-preserve",
                }
            );
            Assert.That(created.Id, Is.Not.Null);

            await _client.Buyers.UpdateAsync(
                created.Id!,
                new BuyerUpdate { DisplayName = "Updated Name" }
            );

            var fetched = await _client.Buyers.GetAsync(created.Id!);
            Assert.That(fetched.DisplayName, Is.EqualTo("Updated Name"));
            Assert.That(
                fetched.ExternalIdentifier,
                Is.EqualTo("ext-preserve"),
                "Properties not assigned on the update must not be sent on the wire."
            );
        }

        [Test]
        public async Task ExplicitValue_OverwritesField_OnServer()
        {
            var created = await _client.Buyers.CreateAsync(
                new BuyerCreate
                {
                    DisplayName = "Original Name",
                    ExternalIdentifier = "ext-overwrite-a",
                }
            );

            await _client.Buyers.UpdateAsync(
                created.Id!,
                new BuyerUpdate { ExternalIdentifier = "ext-overwrite-b" }
            );

            var fetched = await _client.Buyers.GetAsync(created.Id!);
            Assert.That(fetched.ExternalIdentifier, Is.EqualTo("ext-overwrite-b"));
        }
    }
}
