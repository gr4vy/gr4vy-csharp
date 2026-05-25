using System.Collections.Generic;
using Gr4vy.Models.Components;
using Gr4vy.Utils;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

[TestFixture]
public class UpdateModelSerializationTests
{
    private static JObject SerializeToJObject(object value) =>
        JObject.Parse(Utilities.SerializeJSON(value));

    [Test]
    public void BuyerUpdate_UnsetField_IsOmitted()
    {
        var update = new BuyerUpdate();
        var json = SerializeToJObject(update);
        Assert.That(json.ContainsKey("display_name"), Is.False);
        Assert.That(json.ContainsKey("external_identifier"), Is.False);
        Assert.That(json.ContainsKey("account_number"), Is.False);
        Assert.That(json.ContainsKey("billing_details"), Is.False);
    }

    [Test]
    public void BuyerUpdate_ExplicitNullString_IsSentAsNull()
    {
        var update = new BuyerUpdate { DisplayName = null };
        var json = SerializeToJObject(update);
        Assert.That(json.ContainsKey("display_name"), Is.True);
        Assert.That(json["display_name"]!.Type, Is.EqualTo(JTokenType.Null));
    }

    [Test]
    public void BuyerUpdate_ValueString_IsSerialized()
    {
        var update = new BuyerUpdate { DisplayName = "Alice" };
        var json = SerializeToJObject(update);
        Assert.That(json["display_name"]!.Value<string>(), Is.EqualTo("Alice"));
    }

    [Test]
    public void BuyerUpdate_ExplicitNullObject_IsSentAsNull()
    {
        var update = new BuyerUpdate { BillingDetails = null };
        var json = SerializeToJObject(update);
        Assert.That(json.ContainsKey("billing_details"), Is.True);
        Assert.That(json["billing_details"]!.Type, Is.EqualTo(JTokenType.Null));
    }

    [Test]
    public void BuyerUpdate_MixedSetAndUnset_OnlyEmitsTouchedFields()
    {
        var update = new BuyerUpdate
        {
            DisplayName = "Alice",
            ExternalIdentifier = null,
        };
        var json = SerializeToJObject(update);

        Assert.That(json["display_name"]!.Value<string>(), Is.EqualTo("Alice"));
        Assert.That(json.ContainsKey("external_identifier"), Is.True);
        Assert.That(json["external_identifier"]!.Type, Is.EqualTo(JTokenType.Null));
        Assert.That(json.ContainsKey("account_number"), Is.False);
        Assert.That(json.ContainsKey("billing_details"), Is.False);
    }

    [Test]
    public void MerchantAccountUpdate_NullableLong_TriState()
    {
        var unset = new MerchantAccountUpdate();
        var asNull = new MerchantAccountUpdate { OverCaptureAmount = null };
        var asValue = new MerchantAccountUpdate { OverCaptureAmount = 1299L };

        var unsetJson = SerializeToJObject(unset);
        var nullJson = SerializeToJObject(asNull);
        var valueJson = SerializeToJObject(asValue);

        Assert.That(unsetJson.ContainsKey("over_capture_amount"), Is.False);
        Assert.That(nullJson["over_capture_amount"]!.Type, Is.EqualTo(JTokenType.Null));
        Assert.That(valueJson["over_capture_amount"]!.Value<long>(), Is.EqualTo(1299L));
    }

    [Test]
    public void MerchantAccountUpdate_NullableListString_TriState()
    {
        var unset = new MerchantAccountUpdate();
        var asNull = new MerchantAccountUpdate { LoonAcceptedSchemes = null };
        var asValue = new MerchantAccountUpdate
        {
            LoonAcceptedSchemes = new List<string> { "visa", "mastercard" },
        };

        Assert.That(SerializeToJObject(unset).ContainsKey("loon_accepted_schemes"), Is.False);
        Assert.That(SerializeToJObject(asNull)["loon_accepted_schemes"]!.Type, Is.EqualTo(JTokenType.Null));
        var arr = SerializeToJObject(asValue)["loon_accepted_schemes"]!;
        Assert.That(arr.Type, Is.EqualTo(JTokenType.Array));
        Assert.That(arr.ToObject<List<string>>(), Is.EqualTo(new[] { "visa", "mastercard" }));
    }

    [Test]
    public void MerchantAccountUpdate_NonNullDefault_IsStillSerializedWhenUntouched()
    {
        // AccountUpdaterEnabled is generated with `= false` default; the patch
        // preserves the pre-patch behavior of always emitting it.
        var update = new MerchantAccountUpdate();
        var json = SerializeToJObject(update);
        Assert.That(json.ContainsKey("account_updater_enabled"), Is.True);
        Assert.That(json["account_updater_enabled"]!.Value<bool>(), Is.False);
    }

    [Test]
    public void TransactionUpdate_NullableDictionary_TriState()
    {
        var unset = new TransactionUpdate();
        var asNull = new TransactionUpdate { Metadata = null };
        var asValue = new TransactionUpdate
        {
            Metadata = new Dictionary<string, string> { ["k"] = "v" },
        };

        Assert.That(SerializeToJObject(unset).ContainsKey("metadata"), Is.False);
        Assert.That(SerializeToJObject(asNull)["metadata"]!.Type, Is.EqualTo(JTokenType.Null));
        Assert.That(SerializeToJObject(asValue)["metadata"]!["k"]!.Value<string>(), Is.EqualTo("v"));
    }

    [Test]
    public void ReportUpdate_NullableBool_TriState()
    {
        var unset = new ReportUpdate();
        var asNull = new ReportUpdate { ScheduleEnabled = null };
        var asTrue = new ReportUpdate { ScheduleEnabled = true };

        Assert.That(SerializeToJObject(unset).ContainsKey("schedule_enabled"), Is.False);
        Assert.That(SerializeToJObject(asNull)["schedule_enabled"]!.Type, Is.EqualTo(JTokenType.Null));
        Assert.That(SerializeToJObject(asTrue)["schedule_enabled"]!.Value<bool>(), Is.True);
    }

    [Test]
    public void PaymentMethodUpdate_ClearSchemeTransactionId_SendsNull()
    {
        // This mirrors the documented use case where clearing
        // scheme_transaction_id also clears scheme_transaction_id_scheme.
        var update = new PaymentMethodUpdate { SchemeTransactionId = null };
        var json = SerializeToJObject(update);
        Assert.That(json["scheme_transaction_id"]!.Type, Is.EqualTo(JTokenType.Null));
        Assert.That(json.ContainsKey("scheme_transaction_id_scheme"), Is.False);
    }

    [Test]
    public void BuyerUpdate_NestedAddressField_ExplicitNullIsSentAsNull()
    {
        // Mirrors the Wpay repro: clearing a field on a nested object
        // (BillingDetails.Address.HouseNumberOrName) must produce an
        // explicit JSON null rather than omitting the key.
        var update = new BuyerUpdate
        {
            BillingDetails = new BillingDetails
            {
                Address = new Address
                {
                    HouseNumberOrName = null,
                    Line2 = null,
                    State = null,
                    Organization = null,
                },
            },
        };
        var json = SerializeToJObject(update);

        var address = json["billing_details"]!["address"]!;
        Assert.That(address["house_number_or_name"]!.Type, Is.EqualTo(JTokenType.Null));
        Assert.That(address["line2"]!.Type, Is.EqualTo(JTokenType.Null));
        Assert.That(address["state"]!.Type, Is.EqualTo(JTokenType.Null));
        Assert.That(address["organization"]!.Type, Is.EqualTo(JTokenType.Null));
        Assert.That(address.ToObject<JObject>()!.ContainsKey("city"), Is.False,
            "Unset nested fields must still be omitted.");
    }

    [Test]
    public void BuyerUpdate_NestedAddressField_UnsetIsOmitted()
    {
        var update = new BuyerUpdate
        {
            BillingDetails = new BillingDetails { Address = new Address() },
        };
        var json = SerializeToJObject(update);
        var address = json["billing_details"]!["address"]!.ToObject<JObject>()!;
        Assert.That(address.Count, Is.EqualTo(0),
            "An untouched nested Address must serialize as {}.");
    }
}
