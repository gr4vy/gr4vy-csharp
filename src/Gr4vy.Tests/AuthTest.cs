using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using NUnit.Framework;

[TestFixture]
public class AuthTests
{
    private const string PrivateKey = @"-----BEGIN PRIVATE KEY-----
MIHuAgEAMBAGByqGSM49AgEGBSuBBAAjBIHWMIHTAgEBBEIBABM9jQu+HT87oIik
O6DiJjYeghr3V+VMBVNU2hCM3X/OAS6TUTylMbnjDnwWdmu7anVSnjvEY1a4KxQ9
WZ8E/PKhgYkDgYYABABRdv5VAtOsGb6THxeK/p7RAARPm6Zwb7FF4sZAYkkSB7h0
2jpj3UHSpyl92BQkiF/xakz7hMMD1A0ZTn5SuXWp3AG9qPHO3eB9WrZhPGYixwyo
XNjhnPEDhmkItKXteke9iBOTOOXB7AFQSh7EXRBmhBs4u3ZlTmrl+8VdBc3+jwAY
rw==
-----END PRIVATE KEY-----";

    private const string Thumbprint = "va-SLs5AxJNfqKXD8LI5Y38BflpNvjZjY4RSWz66U1w";

    // private readonly Dictionary<string, object> _embedParams = new Dictionary
    // {
    //     Amount = 9000,
    //     Currency = "USD",
    //     BuyerExternalIdentifier = "user-123",
    //     ConnectionOptions = new Dictionary<string, object>
    //     {
    //         { "stripe-card", new { stripe_connect = new { key = "value" } } }
    //     },
    //     Metadata = new Dictionary<string, string>
    //     {
    //         { "camelCaseKey", "value1" },
    //         { "snake_case_key", "value2" }
    //     },
    //     CartItems = new List<CartItem>
    //     {
    //         new CartItem
    //         {
    //             Name = "Joust Duffle Bag",
    //             Quantity = 1,
    //             UnitAmount = 9000,
    //             TaxAmount = 0,
    //             Categories = new List<string> { "Gear", "Bags", "Test" }
    //         }
    //     }
    // };

    private const string CheckoutSessionId = "0ebde6a1-f66c-43ea-bb8b-73751864c604";

    [Test]
    public void GetToken_ShouldCreateValidSignedJwtToken()
    {
        var token = Auth.GetToken(
            privateKey: PrivateKey
        );

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        Assert.That(jwtToken.Header["alg"], Is.EqualTo("ES512"));
        Assert.That(jwtToken.Header["typ"], Is.EqualTo("JWT"));
        Console.Write(jwtToken);

        Assert.That(jwtToken.Header["kid"], Is.EqualTo(Thumbprint));
        Assert.Contains("*.read", jwtToken.Claims.FirstOrDefault(c => c.Type == "scopes").Value.Split(','));
        Assert.Contains("*.write", jwtToken.Claims.FirstOrDefault(c => c.Type == "scopes").Value.Split(','));
        Assert.NotNull(jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Iat));
        Assert.NotNull(jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nbf));
        Assert.NotNull(jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp));
        Assert.That(jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Iss).Value, Is.EqualTo("Gr4vy C# SDK"));
    }

    // [Test]
    // public void GetToken_ShouldAcceptOptionalEmbedData()
    // {
    //     var token = Auth.GetToken(new TokenOptions
    //     {
    //         PrivateKey = PrivateKey,
    //         Scopes = new List<string> { string.Embed },
    //         EmbedParams = _embedParams
    //     });

    //     var handler = new JwtSecurityTokenHandler();
    //     var jwtToken = handler.ReadJwtToken(token);

    //     var embedClaim = jwtToken.Claims.First(c => c.Type == "embed").Value;
    //     var embedData = JsonSerializer.Deserialize<Dictionary<string, object>>(embedClaim);

    //     Assert.Contains("embed", jwtToken.Claims.Select(c => c.Type).ToList());
    //     Assert.NotNull(embedData);
    //     Assert.AreEqual("USD", embedData["currency"]);
    // }

    // [Test]
    // public void GetToken_ShouldIgnoreEmbedDataIfEmbedScopeNotSet()
    // {
    //     var token = Auth.GetToken(new TokenOptions
    //     {
    //         PrivateKey = PrivateKey,
    //         Scopes = new List<string> { string.ReadAll },
    //         EmbedParams = _embedParams
    //     });

    //     var handler = new JwtSecurityTokenHandler();
    //     var jwtToken = handler.ReadJwtToken(token);

    //     Assert.IsFalse(jwtToken.Claims.Any(c => c.Type == "embed"));
    // }

    // [Test]
    // public void GetEmbedToken_ShouldCreateJwtTokenForEmbed()
    // {
    //     var token = Auth.GetEmbedToken(new EmbedTokenOptions
    //     {
    //         PrivateKey = PrivateKey,
    //         EmbedParams = _embedParams
    //     });

    //     var handler = new JwtSecurityTokenHandler();
    //     var jwtToken = handler.ReadJwtToken(token);

    //     var embedClaim = jwtToken.Claims.First(c => c.Type == "embed").Value;
    //     var embedData = JsonSerializer.Deserialize<Dictionary<string, object>>(embedClaim);

    //     Assert.Contains("embed", jwtToken.Claims.Select(c => c.Type).ToList());
    //     Assert.NotNull(embedData);
    //     Assert.AreEqual("USD", embedData["currency"]);
    // }

    // [Test]
    // public void GetEmbedToken_ShouldTakeOptionalCheckoutSessionId()
    // {
    //     var token = Auth.GetEmbedToken(new EmbedTokenOptions
    //     {
    //         PrivateKey = PrivateKey,
    //         EmbedParams = _embedParams,
    //         CheckoutSessionId = CheckoutSessionId
    //     });

    //     var handler = new JwtSecurityTokenHandler();
    //     var jwtToken = handler.ReadJwtToken(token);

    //     Assert.AreEqual(CheckoutSessionId, jwtToken.Claims.First(c => c.Type == "checkout_session_id").Value);
    // }

    // [Test]
    // public void UpdateToken_ShouldResignTokenWithNewSignatureAndExpiration()
    // {
    //     var originalToken = Auth.GetToken(new TokenOptions
    //     {
    //         PrivateKey = PrivateKey,
    //         ExpiresIn = TimeSpan.FromMinutes(1)
    //     });

    //     var newToken = Auth.UpdateToken(new TokenOptions
    //     {
    //         PrivateKey = PrivateKey,
    //         Token = originalToken,
    //         ExpiresIn = TimeSpan.FromMinutes(1)
    //     });

    //     var handler = new JwtSecurityTokenHandler();
    //     var originalJwt = handler.ReadJwtToken(originalToken);
    //     var newJwt = handler.ReadJwtToken(newToken);

    //     Assert.AreEqual(originalJwt.Header, newJwt.Header);
    //     Assert.AreEqual(originalJwt.Claims.First(c => c.Type == "scopes").Value, newJwt.Claims.First(c => c.Type == "scopes").Value);
    //     Assert.AreNotEqual(originalJwt.Claims.First(c => c.Type == JwtRegisteredClaimNames.Iat).Value, newJwt.Claims.First(c => c.Type == JwtRegisteredClaimNames.Iat).Value);
    // }
}