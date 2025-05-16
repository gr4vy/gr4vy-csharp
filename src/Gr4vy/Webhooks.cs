using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public static class Webhooks
{
    public static void VerifyWebhook(
        string payload,
        string secret,
        string? signatureHeader,
        string? timestampHeader,
        int? timestampToleranceSeconds
    )
    {
        if (string.IsNullOrEmpty(signatureHeader) || string.IsNullOrEmpty(timestampHeader))
        {
            throw new ArgumentException("Missing header values");
        }

        if (!long.TryParse(timestampHeader, out long timestamp))
        {
            throw new ArgumentException("Invalid header timestamp");
        }

        var signatures = signatureHeader.Split(',');

        var dataToSign = $"{timestamp}.{payload}";
        var keyBytes = Encoding.UTF8.GetBytes(secret);
        var dataBytes = Encoding.UTF8.GetBytes(dataToSign);

        using var hmac = new HMACSHA256(keyBytes);
        var expectedSignatureBytes = hmac.ComputeHash(dataBytes);
        var expectedSignature = BitConverter.ToString(expectedSignatureBytes).Replace("-", "").ToLowerInvariant();

        if (!signatures.Contains(expectedSignature, StringComparer.OrdinalIgnoreCase))
        {
            throw new ArgumentException("No matching signature found");
        }

        var currentUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if (timestampToleranceSeconds > 0 && timestamp < (currentUnixTimestamp - timestampToleranceSeconds))
        {
            throw new ArgumentException("Timestamp too old");
        }
    }
}