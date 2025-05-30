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
    

    public class RequiredFields2Type
    {
        private RequiredFields2Type(string value) { Value = value; }

        public string Value { get; private set; }
        public static RequiredFields2Type Boolean { get { return new RequiredFields2Type("boolean"); } }
        
        public static RequiredFields2Type MapOfRequiredFields1 { get { return new RequiredFields2Type("mapOfRequiredFields1"); } }
        
        public static RequiredFields2Type Null { get { return new RequiredFields2Type("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(RequiredFields2Type v) { return v.Value; }
        public static RequiredFields2Type FromString(string v) {
            switch(v) {
                case "boolean": return Boolean;
                case "mapOfRequiredFields1": return MapOfRequiredFields1;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for RequiredFields2Type");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((RequiredFields2Type)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    [JsonConverter(typeof(RequiredFields2.RequiredFields2Converter))]
    public class RequiredFields2 {
        public RequiredFields2(RequiredFields2Type type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public bool? Boolean { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public Dictionary<string, RequiredFields1>? MapOfRequiredFields1 { get; set; }

        public RequiredFields2Type Type { get; set; }


        public static RequiredFields2 CreateBoolean(bool boolean) {
            RequiredFields2Type typ = RequiredFields2Type.Boolean;

            RequiredFields2 res = new RequiredFields2(typ);
            res.Boolean = boolean;
            return res;
        }

        public static RequiredFields2 CreateMapOfRequiredFields1(Dictionary<string, RequiredFields1> mapOfRequiredFields1) {
            RequiredFields2Type typ = RequiredFields2Type.MapOfRequiredFields1;

            RequiredFields2 res = new RequiredFields2(typ);
            res.MapOfRequiredFields1 = mapOfRequiredFields1;
            return res;
        }

        public static RequiredFields2 CreateNull() {
            RequiredFields2Type typ = RequiredFields2Type.Null;
            return new RequiredFields2(typ);
        }

        public class RequiredFields2Converter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(RequiredFields2);

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
                    return new RequiredFields2(RequiredFields2Type.Boolean)
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
                    return new RequiredFields2(RequiredFields2Type.MapOfRequiredFields1)
                    {
                        MapOfRequiredFields1 = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<Dictionary<string, RequiredFields1>>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(Dictionary<string, RequiredFields1>), new RequiredFields2(RequiredFields2Type.MapOfRequiredFields1), "MapOfRequiredFields1"));
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
                RequiredFields2 res = (RequiredFields2)value;
                if (RequiredFields2Type.FromString(res.Type).Equals(RequiredFields2Type.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.Boolean != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Boolean));
                    return;
                }
                if (res.MapOfRequiredFields1 != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.MapOfRequiredFields1));
                    return;
                }

            }

        }

    }
}