using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using NUnit.Framework;

[TestFixture]
public class AuthTests
{
    private const string PrivateKey =
        @"-----BEGIN PRIVATE KEY-----
MIHuAgEAMBAGByqGSM49AgEGBSuBBAAjBIHWMIHTAgEBBEIBABM9jQu+HT87oIik
O6DiJjYeghr3V+VMBVNU2hCM3X/OAS6TUTylMbnjDnwWdmu7anVSnjvEY1a4KxQ9
WZ8E/PKhgYkDgYYABABRdv5VAtOsGb6THxeK/p7RAARPm6Zwb7FF4sZAYkkSB7h0
2jpj3UHSpyl92BQkiF/xakz7hMMD1A0ZTn5SuXWp3AG9qPHO3eB9WrZhPGYixwyo
XNjhnPEDhmkItKXteke9iBOTOOXB7AFQSh7EXRBmhBs4u3ZlTmrl+8VdBc3+jwAY
rw==
-----END PRIVATE KEY-----";

    private const string Thumbprint = "va-SLs5AxJNfqKXD8LI5Y38BflpNvjZjY4RSWz66U1w";

    private Dictionary<string, object> _embedParams = new Dictionary<string, object>
    {
        ["amount"] = 9000,
        ["currency"] = "USD",
        ["buyer_external_identifier"] = "user-123",
        ["connection_options"] = new Dictionary<string, object>
        {
            ["stripe-card"] = new Dictionary<string, object>
            {
                ["stripe_connect"] = new Dictionary<string, object> { ["key"] = "value" },
            },
        },
        ["metadata"] = new Dictionary<string, object>
        {
            ["camelCaseKey"] = "value1",
            ["snake_case_key"] = "value2",
        },
        ["cart_items"] = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object>
            {
                ["name"] = "Joust Duffle Bag",
                ["quantity"] = 1,
                ["unit_amount"] = 9000,
                ["tax_amount"] = 0,
                ["categories"] = new List<string> { "Gear", "Bags", "Test" },
            },
        },
    };

    private const string CheckoutSessionId = "0ebde6a1-f66c-43ea-bb8b-73751864c604";

    [Test]
    public void GetToken_ShouldCreateValidSignedJwtToken()
    {
        var token = Auth.GetToken(privateKey: PrivateKey);

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        Assert.NotNull(jwtToken);

        Assert.That(jwtToken.Header["alg"], Is.EqualTo("ES512"));
        Assert.That(jwtToken.Header["typ"], Is.EqualTo("JWT"));

        var scopes = jwtToken.Claims.Where(c => c.Type == "scopes");
        var headers = jwtToken.Header;

        Assert.That(headers["kid"], Is.EqualTo(Thumbprint));
        Assert.That(scopes.Count(s => s.Value == "*.read"), Is.EqualTo(1));
        Assert.That(scopes.Count(s => s.Value == "*.write"), Is.EqualTo(1));
        Assert.NotNull(jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Iat));
        Assert.NotNull(jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nbf));
        Assert.NotNull(jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp));
        Assert.That(
            jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Iss).Value,
            Is.EqualTo("Gr4vy C# SDK")
        );
    }

    [Test]
    public void GetToken_ShouldAcceptOptionalEmbedData()
    {
        var token = Auth.GetToken(
            privateKey: PrivateKey,
            scopes: new List<string> { JWTScope.Embed },
            embedParams: _embedParams
        );

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var embedClaim = jwtToken.Claims.First(c => c.Type == JWTScope.Embed).Value;
        var embedData = JsonSerializer.Deserialize<Dictionary<string, object>>(embedClaim);

        Assert.Contains(JWTScope.Embed, jwtToken.Claims.Select(c => c.Type).ToList());
        Assert.NotNull(embedData);
        Assert.That(embedData["currency"].ToString(), Is.EqualTo("USD"));
    }

    [Test]
    public void GetToken_ShouldIgnoreEmbedDataIfEmbedScopeNotSet()
    {
        var token = Auth.GetToken(
            privateKey: PrivateKey,
            scopes: new List<string> { JWTScope.ReadAll },
            embedParams: _embedParams
        );

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        Assert.IsFalse(jwtToken.Claims.Any(c => c.Type == JWTScope.Embed));
    }

    [Test]
    public void GetEmbedToken_ShouldCreateJwtTokenForEmbed()
    {
        var token = Auth.GetEmbedToken(privateKey: PrivateKey, embedParams: _embedParams);

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var embedClaim = jwtToken.Claims.First(c => c.Type == JWTScope.Embed).Value;
        var embedData = JsonSerializer.Deserialize<Dictionary<string, object>>(embedClaim);

        Assert.Contains(JWTScope.Embed, jwtToken.Claims.Select(c => c.Type).ToList());
        Assert.NotNull(embedData);
        Assert.That(embedData["currency"].ToString(), Is.EqualTo("USD"));
    }

    [Test]
    public void GetEmbedToken_ShouldTakeOptionalCheckoutSessionId()
    {
        var token = Auth.GetEmbedToken(
            privateKey: PrivateKey,
            embedParams: _embedParams,
            checkoutSessionId: CheckoutSessionId
        );

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        Assert.That(
            jwtToken.Claims.First(c => c.Type == "checkout_session_id").Value,
            Is.EqualTo(CheckoutSessionId)
        );
    }

    [Test]
    public void UpdateToken_ShouldResignTokenWithNewSignatureAndExpiration()
    {
        var originalToken = Auth.GetToken(privateKey: PrivateKey, expiresIn: 5, scopes: new List<string> { JWTScope.Embed });

        System.Threading.Thread.Sleep(1000);

        var newToken = Auth.UpdateToken(
            token: originalToken,
            privateKey: PrivateKey,
            expiresIn: 60
        );

        var handler = new JwtSecurityTokenHandler();
        var originalJwt = handler.ReadJwtToken(originalToken);
        var newJwt = handler.ReadJwtToken(newToken);

        Assert.That(originalJwt.Header, Is.EqualTo(newJwt.Header));

        var newScopes = newJwt.Claims.Where(c => c.Type == "scopes");

        Assert.That(newScopes.First().Value, Is.EqualTo("embed"));

        Assert.That(
            originalJwt.Claims.First(c => c.Type == JwtRegisteredClaimNames.Iat).Value,
            Is.Not.EqualTo(newJwt.Claims.First(c => c.Type == JwtRegisteredClaimNames.Iat).Value)
        );
    }
}
