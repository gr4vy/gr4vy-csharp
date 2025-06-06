//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Gr4vy.Models.Components
{
    using Gr4vy.Models.Components;
    using Gr4vy.Utils;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    

    public class TransactionCreatePaymentMethodType
    {
        private TransactionCreatePaymentMethodType(string value) { Value = value; }

        public string Value { get; private set; }
        public static TransactionCreatePaymentMethodType CardWithUrlPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("CardWithUrlPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType RedirectPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("RedirectPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType TokenPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("TokenPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType ApplePayPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("ApplePayPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType ClickToPayPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("ClickToPayPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType ClickToPayFPANPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("ClickToPayFPANPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType GooglePayPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("GooglePayPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType GooglePayFPANPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("GooglePayFPANPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType NetworkTokenPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("NetworkTokenPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType CheckoutSessionWithUrlPaymentMethodCreate { get { return new TransactionCreatePaymentMethodType("CheckoutSessionWithUrlPaymentMethodCreate"); } }
        
        public static TransactionCreatePaymentMethodType Null { get { return new TransactionCreatePaymentMethodType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(TransactionCreatePaymentMethodType v) { return v.Value; }
        public static TransactionCreatePaymentMethodType FromString(string v) {
            switch(v) {
                case "CardWithUrlPaymentMethodCreate": return CardWithUrlPaymentMethodCreate;
                case "RedirectPaymentMethodCreate": return RedirectPaymentMethodCreate;
                case "TokenPaymentMethodCreate": return TokenPaymentMethodCreate;
                case "ApplePayPaymentMethodCreate": return ApplePayPaymentMethodCreate;
                case "ClickToPayPaymentMethodCreate": return ClickToPayPaymentMethodCreate;
                case "ClickToPayFPANPaymentMethodCreate": return ClickToPayFPANPaymentMethodCreate;
                case "GooglePayPaymentMethodCreate": return GooglePayPaymentMethodCreate;
                case "GooglePayFPANPaymentMethodCreate": return GooglePayFPANPaymentMethodCreate;
                case "NetworkTokenPaymentMethodCreate": return NetworkTokenPaymentMethodCreate;
                case "CheckoutSessionWithUrlPaymentMethodCreate": return CheckoutSessionWithUrlPaymentMethodCreate;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for TransactionCreatePaymentMethodType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((TransactionCreatePaymentMethodType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    /// <summary>
    /// The optional payment method to use for this transaction. This field is required if no `gift_cards` have been added.
    /// </summary>
    [JsonConverter(typeof(TransactionCreatePaymentMethod.TransactionCreatePaymentMethodConverter))]
    public class TransactionCreatePaymentMethod {
        public TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public CardWithUrlPaymentMethodCreate? CardWithUrlPaymentMethodCreate { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public RedirectPaymentMethodCreate? RedirectPaymentMethodCreate { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public TokenPaymentMethodCreate? TokenPaymentMethodCreate { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public ApplePayPaymentMethodCreate? ApplePayPaymentMethodCreate { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public ClickToPayPaymentMethodCreate? ClickToPayPaymentMethodCreate { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public ClickToPayFPANPaymentMethodCreate? ClickToPayFPANPaymentMethodCreate { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public GooglePayPaymentMethodCreate? GooglePayPaymentMethodCreate { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public GooglePayFPANPaymentMethodCreate? GooglePayFPANPaymentMethodCreate { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public NetworkTokenPaymentMethodCreate? NetworkTokenPaymentMethodCreate { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public CheckoutSessionWithUrlPaymentMethodCreate? CheckoutSessionWithUrlPaymentMethodCreate { get; set; }

        public TransactionCreatePaymentMethodType Type { get; set; }


        public static TransactionCreatePaymentMethod CreateCardWithUrlPaymentMethodCreate(CardWithUrlPaymentMethodCreate cardWithURLPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.CardWithUrlPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.CardWithUrlPaymentMethodCreate = cardWithURLPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateRedirectPaymentMethodCreate(RedirectPaymentMethodCreate redirectPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.RedirectPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.RedirectPaymentMethodCreate = redirectPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateTokenPaymentMethodCreate(TokenPaymentMethodCreate tokenPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.TokenPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.TokenPaymentMethodCreate = tokenPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateApplePayPaymentMethodCreate(ApplePayPaymentMethodCreate applePayPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.ApplePayPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.ApplePayPaymentMethodCreate = applePayPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateClickToPayPaymentMethodCreate(ClickToPayPaymentMethodCreate clickToPayPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.ClickToPayPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.ClickToPayPaymentMethodCreate = clickToPayPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateClickToPayFPANPaymentMethodCreate(ClickToPayFPANPaymentMethodCreate clickToPayFPANPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.ClickToPayFPANPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.ClickToPayFPANPaymentMethodCreate = clickToPayFPANPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateGooglePayPaymentMethodCreate(GooglePayPaymentMethodCreate googlePayPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.GooglePayPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.GooglePayPaymentMethodCreate = googlePayPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateGooglePayFPANPaymentMethodCreate(GooglePayFPANPaymentMethodCreate googlePayFPANPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.GooglePayFPANPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.GooglePayFPANPaymentMethodCreate = googlePayFPANPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateNetworkTokenPaymentMethodCreate(NetworkTokenPaymentMethodCreate networkTokenPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.NetworkTokenPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.NetworkTokenPaymentMethodCreate = networkTokenPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateCheckoutSessionWithUrlPaymentMethodCreate(CheckoutSessionWithUrlPaymentMethodCreate checkoutSessionWithURLPaymentMethodCreate) {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.CheckoutSessionWithUrlPaymentMethodCreate;

            TransactionCreatePaymentMethod res = new TransactionCreatePaymentMethod(typ);
            res.CheckoutSessionWithUrlPaymentMethodCreate = checkoutSessionWithURLPaymentMethodCreate;
            return res;
        }

        public static TransactionCreatePaymentMethod CreateNull() {
            TransactionCreatePaymentMethodType typ = TransactionCreatePaymentMethodType.Null;
            return new TransactionCreatePaymentMethod(typ);
        }

        public class TransactionCreatePaymentMethodConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(TransactionCreatePaymentMethod);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            {
                var json = JRaw.Create(reader).ToString();
                if (json == "null")
                {
                    return null;
                }

                var fallbackCandidates = new List<(System.Type, object, string)>();

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.TokenPaymentMethodCreate)
                    {
                        TokenPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<TokenPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(TokenPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.TokenPaymentMethodCreate), "TokenPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.CheckoutSessionWithUrlPaymentMethodCreate)
                    {
                        CheckoutSessionWithUrlPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<CheckoutSessionWithUrlPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(CheckoutSessionWithUrlPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.CheckoutSessionWithUrlPaymentMethodCreate), "CheckoutSessionWithUrlPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.RedirectPaymentMethodCreate)
                    {
                        RedirectPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<RedirectPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(RedirectPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.RedirectPaymentMethodCreate), "RedirectPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.ClickToPayPaymentMethodCreate)
                    {
                        ClickToPayPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<ClickToPayPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(ClickToPayPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.ClickToPayPaymentMethodCreate), "ClickToPayPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.CardWithUrlPaymentMethodCreate)
                    {
                        CardWithUrlPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<CardWithUrlPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(CardWithUrlPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.CardWithUrlPaymentMethodCreate), "CardWithUrlPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.ApplePayPaymentMethodCreate)
                    {
                        ApplePayPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<ApplePayPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(ApplePayPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.ApplePayPaymentMethodCreate), "ApplePayPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.ClickToPayFPANPaymentMethodCreate)
                    {
                        ClickToPayFPANPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<ClickToPayFPANPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(ClickToPayFPANPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.ClickToPayFPANPaymentMethodCreate), "ClickToPayFPANPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.GooglePayFPANPaymentMethodCreate)
                    {
                        GooglePayFPANPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<GooglePayFPANPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(GooglePayFPANPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.GooglePayFPANPaymentMethodCreate), "GooglePayFPANPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.GooglePayPaymentMethodCreate)
                    {
                        GooglePayPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<GooglePayPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(GooglePayPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.GooglePayPaymentMethodCreate), "GooglePayPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.NetworkTokenPaymentMethodCreate)
                    {
                        NetworkTokenPaymentMethodCreate = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<NetworkTokenPaymentMethodCreate>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(NetworkTokenPaymentMethodCreate), new TransactionCreatePaymentMethod(TransactionCreatePaymentMethodType.NetworkTokenPaymentMethodCreate), "NetworkTokenPaymentMethodCreate"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                if (fallbackCandidates.Count > 0)
                {
                    fallbackCandidates.Sort((a, b) => ResponseBodyDeserializer.CompareFallbackCandidates(a.Item1, b.Item1, json));
                    foreach(var (deserializationType, returnObject, propertyName) in fallbackCandidates)
                    {
                        try
                        {
                            return ResponseBodyDeserializer.DeserializeUndiscriminatedUnionFallback(deserializationType, returnObject, propertyName, json);
                        }
                        catch (ResponseBodyDeserializer.DeserializationException)
                        {
                            // try next fallback option
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }

                throw new InvalidOperationException("Could not deserialize into any supported types.");
            }

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value == null) {
                    writer.WriteRawValue("null");
                    return;
                }
                TransactionCreatePaymentMethod res = (TransactionCreatePaymentMethod)value;
                if (TransactionCreatePaymentMethodType.FromString(res.Type).Equals(TransactionCreatePaymentMethodType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.CardWithUrlPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.CardWithUrlPaymentMethodCreate));
                    return;
                }
                if (res.RedirectPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.RedirectPaymentMethodCreate));
                    return;
                }
                if (res.TokenPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.TokenPaymentMethodCreate));
                    return;
                }
                if (res.ApplePayPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.ApplePayPaymentMethodCreate));
                    return;
                }
                if (res.ClickToPayPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.ClickToPayPaymentMethodCreate));
                    return;
                }
                if (res.ClickToPayFPANPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.ClickToPayFPANPaymentMethodCreate));
                    return;
                }
                if (res.GooglePayPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.GooglePayPaymentMethodCreate));
                    return;
                }
                if (res.GooglePayFPANPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.GooglePayFPANPaymentMethodCreate));
                    return;
                }
                if (res.NetworkTokenPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.NetworkTokenPaymentMethodCreate));
                    return;
                }
                if (res.CheckoutSessionWithUrlPaymentMethodCreate != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.CheckoutSessionWithUrlPaymentMethodCreate));
                    return;
                }

            }

        }

    }
}