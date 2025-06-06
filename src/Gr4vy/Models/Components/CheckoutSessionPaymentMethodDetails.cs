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
    
    public class CheckoutSessionPaymentMethodDetails
    {

        /// <summary>
        /// The first 6 digit of the card.
        /// </summary>
        [JsonProperty("bin")]
        public string? Bin { get; set; } = null;

        /// <summary>
        /// The country of the card issuer.
        /// </summary>
        [JsonProperty("card_country")]
        public string? CardCountry { get; set; } = null;

        /// <summary>
        /// The payment scheme of the card.
        /// </summary>
        [JsonProperty("card_type")]
        public string? CardType { get; set; } = null;

        /// <summary>
        /// The card issuer.
        /// </summary>
        [JsonProperty("card_issuer_name")]
        public string? CardIssuerName { get; set; } = null;
    }
}