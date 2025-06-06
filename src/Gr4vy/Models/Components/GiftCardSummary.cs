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
    using System;
    
    public class GiftCardSummary
    {

        /// <summary>
        /// Always `gift-card`.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; } = "gift-card";

        /// <summary>
        /// The ID for the gift card.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; } = null;

        /// <summary>
        /// The ID of the merchant account this buyer belongs to.
        /// </summary>
        [JsonProperty("merchant_account_id")]
        public string MerchantAccountId { get; set; } = default!;

        /// <summary>
        /// The first 6 digits of the full gift card number.
        /// </summary>
        [JsonProperty("bin")]
        public string Bin { get; set; } = default!;

        /// <summary>
        /// The 3 digits after the `bin` of the full gift card number.
        /// </summary>
        [JsonProperty("sub_bin")]
        public string SubBin { get; set; } = default!;

        /// <summary>
        /// The last 4 digits for the gift card.
        /// </summary>
        [JsonProperty("last4")]
        public string Last4 { get; set; } = default!;

        /// <summary>
        /// The ISO-4217 currency code that this gift card has a balance for.
        /// </summary>
        [JsonProperty("currency")]
        public string? Currency { get; set; } = null;

        /// <summary>
        ///  The date and time when this gift card expires. This is a full date/time and may be more accurate than the actual expiry date received by the gift card service.
        /// </summary>
        [JsonProperty("expiration_date")]
        public DateTime? ExpirationDate { get; set; } = null;

        /// <summary>
        /// The amount remaining on the balance for this gift card according to the gift card service. This may be `null` if the balance could not be fetched.
        /// </summary>
        [JsonProperty("balance")]
        public long? Balance { get; set; } = null;

        /// <summary>
        /// If the last balance update failed, this will contain the internal code for this error.
        /// </summary>
        [JsonProperty("balance_error_code")]
        public string? BalanceErrorCode { get; set; } = null;

        /// <summary>
        /// If the last balance update failed, this will contain the the raw error code received from the gift card provider.
        /// </summary>
        [JsonProperty("balance_raw_error_code")]
        public string? BalanceRawErrorCode { get; set; } = null;

        /// <summary>
        /// If the last balance update failed, this will contain the the raw error message received from the gift card provider.
        /// </summary>
        [JsonProperty("balance_raw_error_message")]
        public string? BalanceRawErrorMessage { get; set; } = null;
    }
}