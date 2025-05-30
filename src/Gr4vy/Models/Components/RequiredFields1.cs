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
    using Gr4vy.Utils;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    

    public class RequiredFields1Type
    {
        private RequiredFields1Type(string value) { Value = value; }

        public string Value { get; private set; }
        public static RequiredFields1Type Boolean { get { return new RequiredFields1Type("boolean"); } }
        
        public static RequiredFields1Type Any { get { return new RequiredFields1Type("any"); } }
        
        public static RequiredFields1Type Null { get { return new RequiredFields1Type("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(RequiredFields1Type v) { return v.Value; }
        public static RequiredFields1Type FromString(string v) {
            switch(v) {
                case "boolean": return Boolean;
                case "any": return Any;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for RequiredFields1Type");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((RequiredFields1Type)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    [JsonConverter(typeof(RequiredFields1.RequiredFields1Converter))]
    public class RequiredFields1 {
        public RequiredFields1(RequiredFields1Type type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public bool? Boolean { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public object? Any { get; set; }

        public RequiredFields1Type Type { get; set; }


        public static RequiredFields1 CreateBoolean(bool boolean) {
            RequiredFields1Type typ = RequiredFields1Type.Boolean;

            RequiredFields1 res = new RequiredFields1(typ);
            res.Boolean = boolean;
            return res;
        }

        public static RequiredFields1 CreateAny(object any) {
            RequiredFields1Type typ = RequiredFields1Type.Any;

            RequiredFields1 res = new RequiredFields1(typ);
            res.Any = any;
            return res;
        }

        public static RequiredFields1 CreateNull() {
            RequiredFields1Type typ = RequiredFields1Type.Null;
            return new RequiredFields1(typ);
        }

        public class RequiredFields1Converter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(RequiredFields1);

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
                    var converted = Convert.ToBoolean(json);
                    return new RequiredFields1(RequiredFields1Type.Boolean)
                    {
                        Boolean = converted
                    };
                }
                catch (System.FormatException)
                {
                    // try next option
                }

                try
                {
                    return new RequiredFields1(RequiredFields1Type.Any)
                    {
                        Any = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<object>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(object), new RequiredFields1(RequiredFields1Type.Any), "Any"));
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
                RequiredFields1 res = (RequiredFields1)value;
                if (RequiredFields1Type.FromString(res.Type).Equals(RequiredFields1Type.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.Boolean != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Boolean));
                    return;
                }
                if (res.Any != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Any));
                    return;
                }

            }

        }

    }
}