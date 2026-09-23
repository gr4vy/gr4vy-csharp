using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Backoffice
{
    /// <summary>
    /// Roles are an instance-level catalogue (like merchant accounts), so the
    /// fixture's scoped client is fine. The list is not asserted non-empty: an
    /// instance may define no roles.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class RolesTest
    {
        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task Roles_List()
        {
            var list = await Client.Roles.ListAsync();
            Assert.That(list.Result, Is.Not.Null);
            Assert.That(list.Result.Items, Is.Not.Null);
            foreach (var role in list.Result.Items)
            {
                Assert.That(role.Type, Is.EqualTo("role"));
                Assert.That(role.Id, Is.Not.Empty);
                Assert.That(role.Slug, Is.Not.Empty);
            }
        }
    }
}
