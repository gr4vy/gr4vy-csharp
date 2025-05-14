using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public enum JWTScope
{
    ReadAll,
    WriteAll,
    Embed,
    // Add other scope enums similarly...
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
        List<string> scopes = null,
        int expiresIn = 3600,
        Dictionary<string, object> embedParams = null,
        string checkoutSessionId = null)
    {
        if (scopes == null)
        {
            scopes = new List<string> { "*.read", "*.write" };
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

        if (scopes.Contains("embed") && embedParams != null)
        {
            claims.Add(new Claim("embed", System.Text.Json.JsonSerializer.Serialize(embedParams)));
        }

        var key = new ECDsaSecurityKey(ECDsa.Create());
        key.ECDsa.ImportFromPem(privateKey);

        var credentials = new SigningCredentials(key, SecurityAlgorithms.EcdsaSha512)
        {
            CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
        };

        var securityKey = GetECDsaSecurityKey(privateKey);
        var kid = GenerateThumbprint(securityKey.ECDsa); 
        Console.Write(kid);

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

    // public static string UpdateToken(
    //     string token,
    //     string privateKey,
    //     List<string> scopes = null,
    //     int expiresIn = 3600,
    //     Dictionary<string, object> embedParams = null,
    //     string checkoutSessionId = null)
    // {
    //     var tokenHandler = new JwtSecurityTokenHandler();
    //     var jwtToken = tokenHandler.ReadJwtToken(token);

    //     var previousScopes = jwtToken.Claims.FirstOrDefault(c => c.Type == "scopes")?.Value?.Split(',') ?? Array.Empty<string>();

    //     return GetToken(
    //         privateKey,
    //         scopes ?? new List<string>(previousScopes.Select(s => Enum.Parse<string>(s))),
    //         expiresIn,
    //         embedParams ?? System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jwtToken.Claims.FirstOrDefault(c => c.Type == "embed")?.Value ?? "{}"),
    //         checkoutSessionId ?? jwtToken.Claims.FirstOrDefault(c => c.Type == "checkout_session_id")?.Value
    //     );
    // }

    // public static string GetEmbedToken(
    //     string privateKey,
    //     Dictionary<string, object> embedParams = null,
    //     string checkoutSessionId = null)
    // {
    //     return GetToken(
    //         privateKey,
    //         new List<string> { string.EMBED },
    //         3600,
    //         embedParams,
    //         checkoutSessionId
    //     );
    // }
}