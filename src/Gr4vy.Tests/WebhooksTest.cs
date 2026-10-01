using System;
using NUnit.Framework;

public class WebhookVerifierTests
{
    private const string Secret = "Ik4L-8FH0ihWczctcIPXZRR_8F0fPNgmhEfVBbZ3zNwqQVa1Or4tBz4Pgw2eNaVDod7H56Y268h_wohEUaWbUg";
    private const string ValidSignature = "78aca0c78005107a654a957b8566fa6e0e5e06aea92d7da72a6da9e5a690d013,other";
    private const string Payload = "payload";

    [Test]
    public void VerifyWebhook_ValidSignature_ShouldNotThrow()
    {
        var timestamp = "1744018920";
        Assert.DoesNotThrow(() => Webhooks.VerifyWebhook(Payload, Secret, ValidSignature, timestamp, 0));
    }

    [Test]
    public void VerifyWebhook_TimestampTooOld_ShouldThrow()
    {
        var timestamp = "1744018920";
        var ex = Assert.Throws<ArgumentException>(() =>
            Webhooks.VerifyWebhook(Payload, Secret, ValidSignature, timestamp, 60));
        StringAssert.Contains("Timestamp too old", ex.Message);
    }

    [Test]
    public void VerifyWebhook_InvalidSignature_ShouldThrow()
    {
        var timestamp = "1744018920";
        var invalidSignature = "invalid_signature";
        var ex = Assert.Throws<ArgumentException>(() =>
            Webhooks.VerifyWebhook(Payload, Secret, invalidSignature, timestamp, 0));
        StringAssert.Contains("No matching signature found", ex.Message);
    }

    [Test]
    public void VerifyWebhook_InvalidTimestamp_ShouldThrow()
    {
        var invalidTimestamp = "not_a_timestamp";
        var ex = Assert.Throws<ArgumentException>(() =>
            Webhooks.VerifyWebhook(Payload, Secret, ValidSignature, invalidTimestamp, 0));
        StringAssert.Contains("Invalid header timestamp", ex.Message);
    }

    [Test]
    public void VerifyWebhook_MissingSignatureHeader_ShouldThrow()
    {
        var timestamp = "1744018920";
        var ex = Assert.Throws<ArgumentException>(() =>
            Webhooks.VerifyWebhook(Payload, Secret, null, timestamp, 0));
        StringAssert.Contains("Missing header values", ex.Message);
    }

    [Test]
    public void VerifyWebhook_MissingTimestampHeader_ShouldThrow()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            Webhooks.VerifyWebhook(Payload, Secret, ValidSignature, null, 0));
        StringAssert.Contains("Missing header values", ex.Message);
    }

    [Test]
    public void VerifyWebhook_ValidSignatureInAnyPosition_ShouldNotThrow()
    {
        var header = "other,78aca0c78005107a654a957b8566fa6e0e5e06aea92d7da72a6da9e5a690d013";
        Assert.DoesNotThrow(() => Webhooks.VerifyWebhook(Payload, Secret, header, "1744018920", 0));
    }

    [Test]
    public void VerifyWebhook_UpperCaseSignature_ShouldNotThrow()
    {
        var header = "78ACA0C78005107A654A957B8566FA6E0E5E06AEA92D7DA72A6DA9E5A690D013";
        Assert.DoesNotThrow(() => Webhooks.VerifyWebhook(Payload, Secret, header, "1744018920", 0));
    }

    [Test]
    public void VerifyWebhook_NearlyMatchingSignature_ShouldThrow()
    {
        var header = "78aca0c78005107a654a957b8566fa6e0e5e06aea92d7da72a6da9e5a690d014";
        var ex = Assert.Throws<ArgumentException>(() =>
            Webhooks.VerifyWebhook(Payload, Secret, header, "1744018920", 0));
        StringAssert.Contains("No matching signature found", ex.Message);
    }
}
