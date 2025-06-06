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
    
    /// <summary>
    /// Create a Google Pay transaction with a device token.
    /// </summary>
    public class GooglePayPaymentMethodCreate
    {

        /// <summary>
        /// The external identifier of the buyer to create a payment for.
        /// </summary>
        [JsonProperty("buyer_external_identifier")]
        public string? BuyerExternalIdentifier { get; set; } = null;

        /// <summary>
        /// The ID of the buyer to retrieve billing details for.
        /// </summary>
        [JsonProperty("buyer_id")]
        public string? BuyerId { get; set; } = null;

        /// <summary>
        /// The card holder name associated to the original card for the token.
        /// </summary>
        [JsonProperty("cardholder_name")]
        public string? CardholderName { get; set; } = null;

        /// <summary>
        /// The URL to redirect a user back to after the complete 3DS in browser.
        /// </summary>
        [JsonProperty("redirect_url")]
        public string? RedirectUrl { get; set; } = null;

        /// <summary>
        /// The last 4 digits of the original card used to generate the token.
        /// </summary>
        [JsonProperty("card_suffix")]
        public string? CardSuffix { get; set; } = null;

        /// <summary>
        /// The original card scheme for which the token was generated.
        /// </summary>
        [JsonProperty("card_scheme")]
        public string? CardScheme { get; set; } = null;

        /// <summary>
        /// The payment scheme of the card.
        /// </summary>
        [JsonProperty("card_type")]
        public string? CardType { get; set; } = null;

        /// <summary>
        /// Always `googlepay`
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; } = "googlepay";

        /// <summary>
        /// The opaque token as received from the Google Pay JS library. This format may change between JS library versions.
        /// </summary>
        [JsonProperty("token")]
        public Token Token { get; set; } = default!;

        /// <summary>
        /// The assurance details provided by Google Pay
        /// </summary>
        [JsonProperty("assurance_details")]
        public GooglePayAssuranceDetails? AssuranceDetails { get; set; } = null;
    }
}