using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;
using NUnit.Framework;

namespace Gr4vy.Tests
{
    [TestFixture]
    public class CheckoutSessionsTest
    {
        private Gr4vySDK _client;

        [SetUp]
        public async Task Setup()
        {
            var privateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY");
            if (privateKey == null)
            {
                privateKey = File.ReadAllText("../../../../../private_key.pem");
            }
            var gr4vy = new Gr4vySDK(
                id: "e2e",
                server: "sandbox",
                bearerAuthSource: Auth.WithToken(privateKey)
            );

            var merchantAccountId = BitConverter
                .ToString(RandomNumberGenerator.GetBytes(8))
                .Replace("-", "")
                .ToLower();

            var response = await gr4vy.MerchantAccounts.CreateAsync(
                merchantAccountCreate: new MerchantAccountCreate()
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

            await _client.PaymentServices.CreateAsync(
                paymentServiceCreate: new PaymentServiceCreate()
                {
                    AcceptedCurrencies = new List<string>() { "USD" },
                    AcceptedCountries = new List<string>() { "US" },
                    DisplayName = "Payment service",
                    PaymentServiceDefinitionId = "mock-card",
                    Fields = new List<Field>()
                    {
                        new Field() { Key = "merchant_id", Value = "test" },
                    },
                }
            );
        }

        [Test]
        public async Task ProcessPaymentWithCheckoutSession()
        {
            // Create checkout session
            var checkoutSession = await _client.CheckoutSessions.CreateAsync();
            Assert.IsNotNull(checkoutSession.Id);

            // Direct API call to update checkout session fields
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync(
                    $"https://api.sandbox.e2e.gr4vy.app/checkout/sessions/{checkoutSession.Id}/fields",
                    new
                    {
                        payment_method = new
                        {
                            method = "card",
                            number = "4111111111111111",
                            expiration_date = "11/25",
                            security_code = "123",
                        },
                    }
                );
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));
            }

            // Create a transaction using the checkout session
            var transaction = await _client.Transactions.CreateAsync(
                transactionCreate: new TransactionCreate()
                {
                    Amount = 1299,
                    Currency = "USD",
                    Country = "US",
                    PaymentMethod =
                        TransactionCreatePaymentMethod.CreateCheckoutSessionWithUrlPaymentMethodCreate(
                            new CheckoutSessionWithUrlPaymentMethodCreate()
                            {
                                Id = checkoutSession.Id,
                            }
                        ),
                }
            );

            Assert.IsNotNull(transaction.Id);
            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.AuthorizationSucceeded));
            Assert.That(transaction.Amount, Is.EqualTo(1299));
        }

        [Test]
        public async Task HandleErrorOnMissingCardData()
        {
            // Create a checkout session
            var checkoutSession = await _client.CheckoutSessions.CreateAsync();
            Assert.IsNotNull(checkoutSession.Id);

            // Attempt to create a transaction with missing card data
            var ex = Assert.ThrowsAsync<Gr4vy.Models.Errors.Error400>(async () =>
            {
                await _client.Transactions.CreateAsync(
                    transactionCreate: new TransactionCreate()
                    {
                        Amount = 1299,
                        Currency = "USD",
                        PaymentMethod =
                            TransactionCreatePaymentMethod.CreateCheckoutSessionWithUrlPaymentMethodCreate(
                                new CheckoutSessionWithUrlPaymentMethodCreate()
                                {
                                    Id = checkoutSession.Id,
                                }
                            ),
                    }
                );
            });
            Assert.That(ex.Message, Does.Contain("Request failed validation"));
        }

        [Test]
        public async Task HandleStoredPaymentMethod()
        {
            // Create a card payment method
            var request = Body.CreateCardPaymentMethodCreate(
                new CardPaymentMethodCreate
                {
                    Number = "4111111111111111",
                    ExpirationDate = "11/25",
                    SecurityCode = "123",
                }
            );
            var paymentMethod = await _client.PaymentMethods.CreateAsync(requestBody: request);
            Assert.IsNotNull(paymentMethod.Id);

            // Create a checkout session
            var checkoutSession = await _client.CheckoutSessions.CreateAsync();
            Assert.IsNotNull(checkoutSession.Id);

            // Direct API call to update checkout session fields
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync(
                    $"https://api.sandbox.e2e.gr4vy.app/checkout/sessions/{checkoutSession.Id}/fields",
                    new
                    {
                        payment_method = new
                        {
                            method = "id",
                            id = paymentMethod.Id,
                            security_code = "123",
                        },
                    }
                );
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));
            }

            // Create a transaction using the checkout session
            var transaction = await _client.Transactions.CreateAsync(
                transactionCreate: new TransactionCreate()
                {
                    Amount = 1299,
                    Currency = "USD",
                    Country = "US",
                    PaymentMethod =
                        TransactionCreatePaymentMethod.CreateCheckoutSessionWithUrlPaymentMethodCreate(
                            new CheckoutSessionWithUrlPaymentMethodCreate()
                            {
                                Id = checkoutSession.Id,
                            }
                        ),
                }
            );

            Assert.IsNotNull(transaction.Id);
            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.AuthorizationSucceeded));
            Assert.That(transaction.Amount, Is.EqualTo(1299));
        }
    }
}
