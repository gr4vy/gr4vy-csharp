namespace Gr4vy.Tests
{
    /// <summary>
    /// Runs once after every fixture under Gr4vy.Tests and deletes the merchant
    /// accounts the run created.
    /// </summary>
    [SetUpFixture]
    public class MerchantAccountCleanup
    {
        [OneTimeTearDown]
        public Task DeleteMerchantAccounts() => Utils.TestEnvironment.DeleteCreatedMerchantAccountsAsync();
    }
}
