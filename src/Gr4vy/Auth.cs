using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public static class JWTScope
{
    public const string ReadAll = "*.read";
    public const string WriteAll = "*.write";
    public const string Embed = "embed";
    public const string AntiFraudServiceDefinitionsRead = "anti-fraud-service-definitions.read";
    public const string AntiFraudServiceDefinitionsWrite = "anti-fraud-service-definitions.write";
    public const string AntiFraudServicesRead = "anti-fraud-services.read";
    public const string AntiFraudServicesWrite = "anti-fraud-services.write";
    public const string AuditLogsRead = "audit-logs.read";
    public const string BuyersRead = "buyers.read";
    public const string BuyersWrite = "buyers.write";
    public const string BuyersBillingDetailsRead = "buyers.billing-details.read";
    public const string BuyersBillingDetailsWrite = "buyers.billing-details.write";
    public const string CardSchemeDefinitionsRead = "card-scheme-definitions.read";
    public const string CheckoutSessionsRead = "checkout-sessions.read";
    public const string CheckoutSessionsWrite = "checkout-sessions.write";
    public const string ConnectionsRead = "connections.read";
    public const string ConnectionsWrite = "connections.write";
    public const string DigitalWalletsRead = "digital-wallets.read";
    public const string DigitalWalletsWrite = "digital-wallets.write";
    public const string FlowsRead = "flows.read";
    public const string FlowsWrite = "flows.write";
    public const string GiftCardServiceDefinitionsRead = "gift-card-service-definitions.read";
    public const string GiftCardServicesRead = "gift-card-services.read";
    public const string GiftCardServicesWrite = "gift-card-services.write";
    public const string GiftCardsRead = "gift-cards.read";
    public const string GiftCardsWrite = "gift-cards.write";
    public const string MerchantAccountRead = "merchant-accounts.reads";
    public const string MerchantAccountWrite = "merchant-accounts.write";
    public const string PaymentMethodDefinitionsRead = "payment-method-definitions.read";
    public const string PaymentMethodRead = "payment-methods.read";
    public const string PaymentMethodWrite = "payment-methods.write";
    public const string PaymentOptionsRead = "payment-options.read";
    public const string PaymentServiceDefinitionsRead = "payment-service-definitions.read";
    public const string PaymentServicesRead = "payment-services.read";
    public const string PaymentServicesWrite = "payment-services.write";
    public const string ReportsRead = "reports.read";
    public const string ReportsWrite = "reports.write";
    public const string TransactionsRead = "transactions.read";
    public const string TransactionsWrite = "transactions.write";
    public const string VaultForwardWrite = "vault-forward.write";
}
public class Auth
{
    private static string GenerateThumbprint(ECDsa privateKey)
    {
        var parameters = privateKey.ExportParameters(true);
        var jwk = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "kty", "EC" },
            { "crv", "P-521" },
            { "x", Base64UrlEncoder.Encode(parameters.Q.X) },
            { "y", Base64UrlEncoder.Encode(parameters.Q.Y) }
        };

        var sortedKeys = new SortedDictionary<string, string>(jwk);
        var sb = new StringBuilder();
        sb.Append('{');
        var index = 0;
        foreach (var kvp in sortedKeys)
        {
            string key = kvp.Key;
            string value = kvp.Value;
            sb.Append($"\"{key}\":\"{value}\"");
            if (index < sortedKeys.Count - 1)
            {
                sb.Append(',');
            }
            index++;
        }
        sb.Append('}');

        string json = sb.ToString();

        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(json));
        return Base64UrlEncoder.Encode(hash);
    }
    public static string GetToken(
        string privateKey,
        List<string>? scopes = null,
        int expiresIn = 3600,
        Dictionary<string, object>? embedParams = null,
        string? checkoutSessionId = null)
    {
        if (scopes == null)
        {
            scopes = new List<string> { JWTScope.ReadAll, JWTScope.WriteAll };
        }

        var now = DateTime.UtcNow;
        var claims = new List<Claim>
        {
            new Claim("scopes", string.Join(",", scopes)),
            new Claim("iss", "Gr4vy C# SDK"),
            new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString()),
            new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(now).ToUnixTimeSeconds().ToString()),
            new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(now.AddSeconds(expiresIn)).ToUnixTimeSeconds().ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        if (!string.IsNullOrEmpty(checkoutSessionId))
        {
            claims.Add(new Claim("checkout_session_id", checkoutSessionId));
        }

        if (scopes.Contains(JWTScope.Embed) && embedParams != null)
        {
            claims.Add(new Claim(JWTScope.Embed, System.Text.Json.JsonSerializer.Serialize(embedParams)));
        }

        var key = new ECDsaSecurityKey(ECDsa.Create());
        key.ECDsa.ImportFromPem(privateKey);

        var credentials = new SigningCredentials(key, SecurityAlgorithms.EcdsaSha512)
        {
            CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
        };

        var securityKey = GetECDsaSecurityKey(privateKey);
        var kid = GenerateThumbprint(securityKey.ECDsa);

        var header = new JwtHeader(credentials);
        header.Add("kid", kid);

        var token = new JwtSecurityToken(
            header: header,
            payload: new JwtPayload(claims)
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    private static ECDsaSecurityKey GetECDsaSecurityKey(string pem)
    {
        var ecdsa = ECDsa.Create();
        ecdsa.ImportFromPem(pem);
        return new ECDsaSecurityKey(ecdsa);
    }

    public static string UpdateToken(
        string token,
        string privateKey,
        List<string>? scopes = null,
        int expiresIn = 3600,
        Dictionary<string, object>? embedParams = null,
        string? checkoutSessionId = null)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        var previousScopes = jwtToken.Payload["scopes"]?.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return GetToken(
            privateKey,
            scopes ?? new List<string>(previousScopes),
            expiresIn,
            embedParams,
            checkoutSessionId
        );
    }

    public static string GetEmbedToken(
        string privateKey,
        Dictionary<string, object>? embedParams = null,
        string? checkoutSessionId = null)
    {
        return GetToken(
            privateKey,
            new List<string> { JWTScope.Embed },
            3600,
            embedParams,
            checkoutSessionId
        );
    }
}