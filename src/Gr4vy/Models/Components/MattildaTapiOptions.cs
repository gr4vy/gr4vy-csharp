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
    
    public class MattildaTapiOptions
    {

        /// <summary>
        /// Defines the date at which the payment will expire if not completed. Must be provided in ISO 8601 format `(YYYY-MM-DD`). If not specified, it defaults to 7 days in the future from the current date.
        /// </summary>
        [JsonProperty("payment_method_expires_at")]
        public string? PaymentMethodExpiresAt { get; set; } = null;
    }
}