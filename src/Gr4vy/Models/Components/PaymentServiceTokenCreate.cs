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
    
    public class PaymentServiceTokenCreate
    {

        /// <summary>
        /// The 3 or 4 digit security code often found on the card. This often referred to as the CVV or CVD.
        /// </summary>
        [JsonProperty("security_code")]
        public string? SecurityCode { get; set; } = null;

        /// <summary>
        /// The ID of the payment method to use.
        /// </summary>
        [JsonProperty("payment_service_id")]
        public string PaymentServiceId { get; set; } = default!;

        /// <summary>
        /// The redirect URL to redirect a buyer to after they have authorized the payment method.
        /// </summary>
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; } = default!;
    }
}