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
    
    public class GiftCardRedemption
    {

        /// <summary>
        /// Always `gift-card-redemption`.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; } = "gift-card-redemption";

        /// <summary>
        /// The ID for the gift card redemption.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        [JsonProperty("status")]
        public string Status { get; set; } = default!;

        /// <summary>
        /// The amount redeemed for this gift card.
        /// </summary>
        [JsonProperty("amount")]
        public long Amount { get; set; } = default!;

        /// <summary>
        /// The amount refunded for this gift card. This can not be larger than `amount`.
        /// </summary>
        [JsonProperty("refunded_amount")]
        public long RefundedAmount { get; set; } = default!;

        /// <summary>
        /// The gift card service&apos;s unique ID for the redemption.
        /// </summary>
        [JsonProperty("gift_card_service_redemption_id")]
        public string? GiftCardServiceRedemptionId { get; set; } = null;

        /// <summary>
        /// If this gift card redemption resulted in an error, this will contain the internal code for the error.
        /// </summary>
        [JsonProperty("error_code")]
        public string? ErrorCode { get; set; } = null;

        /// <summary>
        /// If this gift card redemption resulted in an error, this will contain the raw error code received from the gift card provider.
        /// </summary>
        [JsonProperty("raw_error_code")]
        public string? RawErrorCode { get; set; } = null;

        /// <summary>
        /// If this gift card redemption resulted in an error, this will contain the raw error message received from the gift card provider.
        /// </summary>
        [JsonProperty("raw_error_message")]
        public string? RawErrorMessage { get; set; } = null;

        [JsonProperty("gift_card")]
        public TransactionGiftCard GiftCard { get; set; } = default!;
    }
}