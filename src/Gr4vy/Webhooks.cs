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

        // Compare in constant time, so the check doesn't leak how much of one matched.
        // Signatures are hex, so they're compared lower-cased, as before.
        var expected = Encoding.ASCII.GetBytes(expectedSignature);
        if (!signatures.Any(signature => CryptographicOperations.FixedTimeEquals(
                Encoding.ASCII.GetBytes(signature.ToLowerInvariant()), expected)))
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