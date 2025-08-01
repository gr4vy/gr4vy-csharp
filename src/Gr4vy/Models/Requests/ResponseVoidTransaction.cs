//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Gr4vy.Models.Requests
{
    using Gr4vy.Models.Components;
    using Gr4vy.Utils;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    

    public class ResponseVoidTransactionType
    {
        private ResponseVoidTransactionType(string value) { Value = value; }

        public string Value { get; private set; }
        public static ResponseVoidTransactionType Transaction { get { return new ResponseVoidTransactionType("Transaction"); } }
        
        public static ResponseVoidTransactionType TransactionVoid { get { return new ResponseVoidTransactionType("TransactionVoid"); } }
        
        public static ResponseVoidTransactionType Null { get { return new ResponseVoidTransactionType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(ResponseVoidTransactionType v) { return v.Value; }
        public static ResponseVoidTransactionType FromString(string v) {
            switch(v) {
                case "Transaction": return Transaction;
                case "TransactionVoid": return TransactionVoid;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for ResponseVoidTransactionType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((ResponseVoidTransactionType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    /// <summary>
    /// Successful Response
    /// </summary>
    [JsonConverter(typeof(ResponseVoidTransaction.ResponseVoidTransactionConverter))]
    public class ResponseVoidTransaction {
        public ResponseVoidTransaction(ResponseVoidTransactionType type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public Transaction? Transaction { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public TransactionVoid? TransactionVoid { get; set; }

        public ResponseVoidTransactionType Type { get; set; }


        public static ResponseVoidTransaction CreateTransaction(Transaction transaction) {
            ResponseVoidTransactionType typ = ResponseVoidTransactionType.Transaction;

            ResponseVoidTransaction res = new ResponseVoidTransaction(typ);
            res.Transaction = transaction;
            return res;
        }

        public static ResponseVoidTransaction CreateTransactionVoid(TransactionVoid transactionVoid) {
            ResponseVoidTransactionType typ = ResponseVoidTransactionType.TransactionVoid;

            ResponseVoidTransaction res = new ResponseVoidTransaction(typ);
            res.TransactionVoid = transactionVoid;
            return res;
        }

        public static ResponseVoidTransaction CreateNull() {
            ResponseVoidTransactionType typ = ResponseVoidTransactionType.Null;
            return new ResponseVoidTransaction(typ);
        }

        public class ResponseVoidTransactionConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(ResponseVoidTransaction);

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
                    return new ResponseVoidTransaction(ResponseVoidTransactionType.TransactionVoid)
                    {
                        TransactionVoid = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<TransactionVoid>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(TransactionVoid), new ResponseVoidTransaction(ResponseVoidTransactionType.TransactionVoid), "TransactionVoid"));
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
                    return new ResponseVoidTransaction(ResponseVoidTransactionType.Transaction)
                    {
                        Transaction = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<Transaction>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(Transaction), new ResponseVoidTransaction(ResponseVoidTransactionType.Transaction), "Transaction"));
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
                ResponseVoidTransaction res = (ResponseVoidTransaction)value;
                if (ResponseVoidTransactionType.FromString(res.Type).Equals(ResponseVoidTransactionType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.Transaction != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Transaction));
                    return;
                }
                if (res.TransactionVoid != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.TransactionVoid));
                    return;
                }

            }

        }

    }
}