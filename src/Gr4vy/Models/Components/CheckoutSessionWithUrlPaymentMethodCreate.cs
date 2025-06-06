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
    
    /// <summary>
    /// Create a payment with a checkout session ID (and an optional URL for 3DS).
    /// </summary>
    public class CheckoutSessionWithUrlPaymentMethodCreate
    {

        /// <summary>
        /// Always `checkout-session`
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; } = "checkout-session";

        /// <summary>
        /// The ID for the checkout session.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        /// <summary>
        /// The merchant reference that can be used to match the payment method against your own records.
        /// </summary>
        [JsonProperty("external_identifier")]
        public string? ExternalIdentifier { get; set; } = null;

        /// <summary>
        /// The `id` of a stored buyer to use Use this instead of the `buyer_external_identifier`.
        /// </summary>
        [JsonProperty("buyer_id")]
        public string? BuyerId { get; set; } = null;

        /// <summary>
        /// The `external_identifier` of a stored buyer to use. Use this instead of the `buyer_id`.
        /// </summary>
        [JsonProperty("buyer_external_identifier")]
        public string? BuyerExternalIdentifier { get; set; } = null;

        /// <summary>
        /// The URL to redirect a user back to after the complete 3DS in browser.
        /// </summary>
        [JsonProperty("redirect_url")]
        public string? RedirectUrl { get; set; } = null;
    }
}