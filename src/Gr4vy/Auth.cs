using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class Auth
{
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

        var kid = GenerateThumbprint(privateKey); 
        Console.Write(kid);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = now.AddSeconds(expiresIn),
            SigningCredentials = credentials,
            // AdditionalHeaderClaims = new Dictionary<string, object>
            // {
            //     { "kid", GenerateThumbprint(privateKey) }
            // }
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
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