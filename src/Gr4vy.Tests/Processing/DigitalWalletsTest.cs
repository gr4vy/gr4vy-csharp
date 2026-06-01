using System.Collections.Generic;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Tests.Utils;
using NUnit.Framework;

namespace Gr4vy.Tests.Processing
{
    /// <summary>
    /// Digital wallet registration CRUD + domains, and the wallet session
    /// endpoints. Sessions and domains require live Apple/Google/Paze/Click-to-Pay
    /// provisioning that the sandbox cannot complete, so they are exercised at the
    /// request level (a real request is sent; a documented API error is accepted).
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class DigitalWalletsTest
    {
        private TestMerchant _m = null!;
        private Gr4vySDK Client => _m.Client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp() => _m = await TestEnvironment.SetupMerchantAsync();

        [Test]
        public async Task Register_Get_Update_List_Delete()
        {
            DigitalWallet? wallet = null;

            // Registration may require live provider config; reach it regardless.
            await Reach.ReachesAsync(
                async () =>
                    wallet = await Client.DigitalWallets.CreateAsync(
                        new DigitalWalletCreate
                        {
                            Provider = "google",
                            MerchantName = "Gr4vy Test",
                            DomainNames = new List<string> { "example.com" },
                            AcceptTermsAndConditions = true,
                        }
                    ),
                "digital-wallets.create"
            );

            // NOTE: DigitalWallets.List hits the same generated-SDK deserialization
            // bug as PaymentLinks.List (ResponseValidationException -> "Could not
            // deserialize token into dictionary" in AnyDeserializer; reproduces with
            // the forward-compat injector disabled). Reach the endpoint at the
            // request level until the SDK/spec is fixed.
            await Reach.ReachesAsync(() => Client.DigitalWallets.ListAsync(), "digital-wallets.list");

            if (wallet?.Id != null)
            {
                var fetched = await Client.DigitalWallets.GetAsync(wallet.Id);
                Assert.That(fetched.Id, Is.EqualTo(wallet.Id));

                var updated = await Client.DigitalWallets.UpdateAsync(
                    wallet.Id,
                    new DigitalWalletUpdate { MerchantName = "Gr4vy Updated" }
                );
                Assert.That(updated.Id, Is.EqualTo(wallet.Id));

                await Reach.ReachesAsync(
                    () =>
                        Client.DigitalWallets.Domains.CreateAsync(
                            wallet.Id,
                            new DigitalWalletDomain { DomainName = "shop.example.com" }
                        ),
                    "digital-wallets.domains.create"
                );
                await Reach.ReachesAsync(
                    () =>
                        Client.DigitalWallets.Domains.DeleteAsync(
                            wallet.Id,
                            new DigitalWalletDomain { DomainName = "shop.example.com" }
                        ),
                    "digital-wallets.domains.delete"
                );

                await Client.DigitalWallets.DeleteAsync(wallet.Id);
            }
        }

        [Test]
        public async Task WalletSessions_AreReached()
        {
            await Reach.ReachesAsync(
                () =>
                    Client.DigitalWallets.Sessions.GooglePayAsync(
                        new GooglePaySessionRequest { OriginDomain = "example.com" }
                    ),
                "sessions.google-pay"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.DigitalWallets.Sessions.ApplePayAsync(
                        new ApplePaySessionRequest
                        {
                            ValidationUrl = "https://apple-pay-gateway.apple.com/paymentservices/startSession",
                            DomainName = "example.com",
                        }
                    ),
                "sessions.apple-pay"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.DigitalWallets.Sessions.ClickToPayAsync(
                        new ClickToPaySessionRequest { CheckoutSessionId = "00000000-0000-0000-0000-000000000000" }
                    ),
                "sessions.click-to-pay"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.DigitalWallets.Sessions.PazeAsync(
                        new PazeSessionRequest { DomainName = "example.com" }
                    ),
                "sessions.paze"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.DigitalWallets.Sessions.PazeMobileSessionCreateAsync(
                        new PazeMobileSessionCreateRequest
                        {
                            Client = new PazeClient { Id = "client-1" },
                            SessionId = "sess-1",
                            AccessToken = "token-1",
                            CallbackURLScheme = "app://callback",
                            Intent = "checkout",
                        }
                    ),
                "sessions.paze-mobile-create"
            );
            await Reach.ReachesAsync(
                () =>
                    Client.DigitalWallets.Sessions.PazeMobileSessionReviewAsync(
                        new PazeSessionReviewRequest
                        {
                            SessionId = "sess-1",
                            Code = "code-1",
                            AccessToken = "token-1",
                        }
                    ),
                "sessions.paze-mobile-review"
            );
        }
    }
}
