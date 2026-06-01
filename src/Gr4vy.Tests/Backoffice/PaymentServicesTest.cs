using System.Collections.Generic;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Backoffice
{
    /// <summary>
    /// Payment service CRUD + partial update, plus the read-only catalogue
    /// endpoints (definitions, options, card-scheme definitions). Verify/session
    /// need real provider credentials, so they are reached at the request level.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class PaymentServicesTest
    {
        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task Create_Get_Update_List_Delete()
        {
            var created = await Client.PaymentServices.CreateAsync(
                new PaymentServiceCreate
                {
                    AcceptedCurrencies = new List<string> { "USD" },
                    AcceptedCountries = new List<string> { "US" },
                    DisplayName = "Secondary service",
                    PaymentServiceDefinitionId = "mock-card",
                    Fields = new List<Field> { new Field { Key = "merchant_id", Value = "test" } },
                }
            );
            Assert.That(created.Id, Is.Not.Null);

            var fetched = await Client.PaymentServices.GetAsync(created.Id!);
            Assert.That(fetched.Id, Is.EqualTo(created.Id));

            var updated = await Client.PaymentServices.UpdateAsync(
                created.Id!,
                new PaymentServiceUpdate { DisplayName = "Renamed service" }
            );
            Assert.That(updated.DisplayName, Is.EqualTo("Renamed service"));

            var list = await Client.PaymentServices.ListAsync();
            Assert.That(list.Result, Is.Not.Null);

            await Client.PaymentServices.DeleteAsync(created.Id!);
        }

        [Test]
        public async Task Catalogue_Endpoints()
        {
            var defs = await Client.PaymentServiceDefinitions.ListAsync();
            Assert.That(defs.Result, Is.Not.Null);

            var def = await Client.PaymentServiceDefinitions.GetAsync("mock-card");
            Assert.That(def.Id, Is.EqualTo("mock-card"));

            var cardSchemes = await Client.CardSchemeDefinitions.ListAsync();
            Assert.That(cardSchemes, Is.Not.Null);
        }

        [Test]
        public async Task Verify_Session_Definitions_AreReached()
        {
            await Reach.ReachesAsync(
                () =>
                    Client.PaymentServices.VerifyAsync(
                        new VerifyCredentials
                        {
                            PaymentServiceDefinitionId = "mock-card",
                            Fields = new List<Field>
                            {
                                new Field { Key = "merchant_id", Value = "test" },
                            },
                        }
                    ),
                "payment-services.verify"
            );

            await Reach.ReachesAsync(
                () =>
                    Client.PaymentServiceDefinitions.SessionAsync(
                        "mock-card",
                        new Dictionary<string, object>()
                    ),
                "payment-service-definitions.session"
            );

            await Reach.ReachesAsync(
                () =>
                    Client.PaymentServices.SessionAsync(
                        "11111111-1111-1111-1111-111111111111",
                        new Dictionary<string, object>()
                    ),
                "payment-services.session"
            );
        }
    }
}
