using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Processing
{
    /// <summary>
    /// Checkout-session lifecycle beyond the headline flow: create, get, update,
    /// delete. (The card-fields PUT + authorize path is covered in CheckoutSessionsTest.)
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class CheckoutSessionsExtraTest
    {
        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task Create_Get_Update_Delete()
        {
            var session = await Client.CheckoutSessions.CreateAsync();
            Assert.That(session.Id, Is.Not.Null);

            var fetched = await Client.CheckoutSessions.GetAsync(session.Id);
            Assert.That(fetched.Id, Is.EqualTo(session.Id));

            var updated = await Client.CheckoutSessions.UpdateAsync(
                session.Id,
                new CheckoutSessionCreate()
            );
            Assert.That(updated.Id, Is.EqualTo(session.Id));

            await Client.CheckoutSessions.DeleteAsync(session.Id);
        }
    }
}
