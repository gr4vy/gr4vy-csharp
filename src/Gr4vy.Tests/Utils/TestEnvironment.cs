using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gr4vy.Tests.Utils
{
    /// <summary>
    /// Shared E2E harness. Every test fixture provisions its OWN merchant account
    /// (random id) with a <c>mock-card</c> payment service, so fixtures are fully
    /// isolated and safe to run in parallel across NUnit workers / CI shards.
    ///
    /// The merchant-scoped client is wrapped with <see cref="JsonInterceptorHttpClient"/>,
    /// which (a) injects a random unknown field into every JSON response to prove the
    /// SDK tolerates forward-compatible payloads, and (b) when GR4VY_TRACK_HTTP is set,
    /// records the method + path of every outgoing request so the endpoint-coverage
    /// report can measure reach from real HTTP calls (see scripts/endpoint-coverage.*).
    /// </summary>
    public static class TestEnvironment
    {
        public const string ApiBaseUrl = "https://api.sandbox.e2e.gr4vy.app";

        public static string LoadPrivateKey()
        {
            var privateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY");
            if (string.IsNullOrEmpty(privateKey))
            {
                // tests run from src/Gr4vy.Tests/bin/Debug/net8.0 → repo root is 5 up.
                privateKey = File.ReadAllText("../../../../../private_key.pem");
            }
            return privateKey;
        }

        public static Gr4vySDK CreateClient(string privateKey, string? merchantAccountId = null)
        {
            return new Gr4vySDK(
                client: new JsonInterceptorHttpClient(),
                id: "e2e",
                server: SDKConfig.Server.Sandbox,
                bearerAuthSource: Auth.WithToken(privateKey),
                merchantAccountId: merchantAccountId
            );
        }

        /// <summary>
        /// Provisions an isolated merchant account + a mock-card payment service and
        /// returns a merchant-scoped client and identifiers. Call once per fixture in
        /// <c>[OneTimeSetUp]</c>.
        /// </summary>
        public static async Task<TestMerchant> SetupMerchantAsync()
        {
            var privateKey = LoadPrivateKey();
            var adminClient = CreateClient(privateKey);

            var merchantAccountId = BitConverter
                .ToString(RandomNumberGenerator.GetBytes(8))
                .Replace("-", "")
                .ToLowerInvariant();

            var merchantAccount = await adminClient.MerchantAccounts.CreateAsync(
                new MerchantAccountCreate { Id = merchantAccountId, DisplayName = merchantAccountId }
            );

            var client = CreateClient(privateKey, merchantAccount.Id);

            await client.PaymentServices.CreateAsync(
                new PaymentServiceCreate
                {
                    AcceptedCurrencies = new List<string> { "USD" },
                    AcceptedCountries = new List<string> { "US" },
                    DisplayName = "Payment service",
                    PaymentServiceDefinitionId = "mock-card",
                    Fields = new List<Field> { new Field { Key = "merchant_id", Value = "test" } },
                }
            );

            return new TestMerchant(client, merchantAccount.Id!, privateKey);
        }
    }

    /// <summary>Merchant-scoped client plus the identifiers a suite may need.</summary>
    public sealed class TestMerchant
    {
        public Gr4vySDK Client { get; }
        public string MerchantAccountId { get; }
        public string PrivateKey { get; }

        public TestMerchant(Gr4vySDK client, string merchantAccountId, string privateKey)
        {
            Client = client;
            MerchantAccountId = merchantAccountId;
            PrivateKey = privateKey;
        }
    }

    /// <summary>
    /// HTTP client that injects a random unknown field into every JSON response
    /// (forward-compat assertion) and, when GR4VY_TRACK_HTTP is set, records the
    /// method + path of every outgoing request to coverage/http/*.jsonl.
    /// </summary>
    public class JsonInterceptorHttpClient : SpeakeasyHttpClient
    {
        private static readonly bool TrackHttp =
            !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GR4VY_TRACK_HTTP"));

        // Escape hatch to disable the forward-compat field injection (diagnostics only).
        private static readonly bool NoInject =
            !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GR4VY_NO_INJECT"));

        // One file per process avoids cross-worker write races. Resolved lazily.
        private static readonly Lazy<string?> LogFile = new(() =>
        {
            if (!TrackHttp)
                return null;
            try
            {
                // repo-root/coverage/http (tests run 5 levels deep under bin/).
                var dir = Path.GetFullPath(
                    Path.Combine(AppContext.BaseDirectory, "../../../../../coverage/http")
                );
                Directory.CreateDirectory(dir);
                var suffix = BitConverter
                    .ToString(RandomNumberGenerator.GetBytes(4))
                    .Replace("-", "")
                    .ToLowerInvariant();
                return Path.Combine(
                    dir,
                    $"calls-{Environment.ProcessId}-{suffix}.jsonl"
                );
            }
            catch
            {
                return null;
            }
        });

        private static readonly object WriteLock = new();

        private static void RecordHttpCall(HttpRequestMessage request)
        {
            var file = LogFile.Value;
            if (file == null || request.RequestUri == null)
                return;
            try
            {
                var line =
                    JsonConvert.SerializeObject(
                        new
                        {
                            method = request.Method.Method,
                            pathname = request.RequestUri.AbsolutePath,
                        }
                    ) + "\n";
                // Best-effort: never fail a test because of instrumentation I/O.
                lock (WriteLock)
                {
                    File.AppendAllText(file, line);
                }
            }
            catch
            {
                // ignore — best-effort tracking
            }
        }

        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            if (TrackHttp)
                RecordHttpCall(request);

            HttpResponseMessage originalResponse = await base.SendAsync(request);

            if (
                NoInject
                || originalResponse.Content?.Headers?.ContentType?.MediaType != "application/json"
            )
            {
                return originalResponse;
            }

            string originalContent = await originalResponse.Content.ReadAsStringAsync();
            try
            {
                JObject data = JObject.Parse(originalContent);
                string randomKey = $"unexpected_field_{new Random().Next(0, 999)}";
                data[randomKey] = "this is an injected test value";
                originalResponse.Content = new StringContent(
                    data.ToString(Formatting.None),
                    Encoding.UTF8,
                    "application/json"
                );
                return originalResponse;
            }
            catch (JsonReaderException)
            {
                originalResponse.Content = new StringContent(
                    originalContent,
                    Encoding.UTF8,
                    "application/json"
                );
                return originalResponse;
            }
        }
    }
}
