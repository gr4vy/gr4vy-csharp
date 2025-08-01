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
    using Gr4vy.Utils;
    using System;
    using System.Collections.Generic;
    
    public class ListTransactionsRequest
    {

        /// <summary>
        /// A pointer to the page of results to return.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=cursor")]
        public string? Cursor { get; set; } = null;

        /// <summary>
        /// The maximum number of items that are at returned.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=limit")]
        public long? Limit { get; set; } = 20;

        /// <summary>
        /// Filters the results to only transactions created before this ISO date-time string. The time zone must be included. Ensure that the date-time string is URL encoded, e.g. `2022-01-01T12:00:00+08:00` must be encoded as `2022-01-01T12%3A00%3A00%2B08%3A00`.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=created_at_lte")]
        public DateTime? CreatedAtLte { get; set; } = null;

        /// <summary>
        /// Filters the results to only transactions created after this ISO date-time string. The time zone must be included. Ensure that the date-time string is URL encoded, e.g. `2022-01-01T12:00:00+08:00` must be encoded as `2022-01-01T12%3A00%3A00%2B08%3A00`.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=created_at_gte")]
        public DateTime? CreatedAtGte { get; set; } = null;

        /// <summary>
        /// Filters the results to only transactions updated before this ISO date-time string. The time zone must be included. Ensure that the date-time string is URL encoded, e.g. `2022-01-01T12:00:00+08:00` must be encoded as `2022-01-01T12%3A00%3A00%2B08%3A00`.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=updated_at_lte")]
        public DateTime? UpdatedAtLte { get; set; } = null;

        /// <summary>
        /// Filters the results to only transactions updated after this ISO date-time string. The time zone must be included. Ensure that the date-time string is URL encoded, e.g. `2022-01-01T12:00:00+08:00` must be encoded as `2022-01-01T12%3A00%3A00%2B08%3A00`.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=updated_at_gte")]
        public DateTime? UpdatedAtGte { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=search")]
        public string? Search { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=buyer_external_identifier")]
        public string? BuyerExternalIdentifier { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=buyer_id")]
        public string? BuyerId { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=buyer_email_address")]
        public string? BuyerEmailAddress { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=ip_address")]
        public string? IpAddress { get; set; } = null;

        /// <summary>
        /// Filters the results to only the transactions that have a `status` that matches with any of the provided status values.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=status")]
        public List<string>? Status { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=id")]
        public string? Id { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=payment_service_transaction_id")]
        public string? PaymentServiceTransactionId { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=external_identifier")]
        public string? ExternalIdentifier { get; set; } = null;

        /// <summary>
        /// Filters for transactions where their `metadata` values contain all of the provided `metadata` keys. The value sent for `metadata` must be formatted as a JSON string, and all keys and values must be strings. This value should also be URL encoded.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=metadata")]
        public List<string>? Metadata { get; set; } = null;

        /// <summary>
        /// Filters for transactions that have an `amount` that is equal to the provided `amount_eq` value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=amount_eq")]
        public long? AmountEq { get; set; } = null;

        /// <summary>
        /// Filters for transactions that have an `amount` that is less than or equal to the `amount_lte` value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=amount_lte")]
        public long? AmountLte { get; set; } = null;

        /// <summary>
        /// Filters for transactions that have an `amount` that is greater than or equal to the `amount_gte` value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=amount_gte")]
        public long? AmountGte { get; set; } = null;

        /// <summary>
        /// Filters for transactions that have matching `currency` values. The `currency` values provided must be formatted as 3-letter ISO currency code.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=currency")]
        public List<string>? Currency { get; set; } = null;

        /// <summary>
        /// Filters for transactions that have matching `country` values.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=country")]
        public List<string>? Country { get; set; } = null;

        /// <summary>
        /// Filters for transactions that were processed by the provided `payment_service_id` values.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=payment_service_id")]
        public List<string>? PaymentServiceId { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=payment_method_id")]
        public string? PaymentMethodId { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=payment_method_label")]
        public string? PaymentMethodLabel { get; set; } = null;

        /// <summary>
        /// Filters for transactions where the `payment_method_scheme` matches one of the provided values.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=payment_method_scheme")]
        public List<string>? PaymentMethodScheme { get; set; } = null;

        /// <summary>
        /// Filters for transactions that have a payment method with a country that matches with the provided value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=payment_method_country")]
        public string? PaymentMethodCountry { get; set; } = null;

        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=payment_method_fingerprint")]
        public string? PaymentMethodFingerprint { get; set; } = null;

        /// <summary>
        /// Filters for transactions that have matching `method` values.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=method")]
        public List<string>? Method { get; set; } = null;

        /// <summary>
        /// Filters for transactions where the `error_code` matches one for the provided values.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=error_code")]
        public List<string>? ErrorCode { get; set; } = null;

        /// <summary>
        /// Filters for transactions with refunds.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=has_refunds")]
        public bool? HasRefunds { get; set; } = null;

        /// <summary>
        /// Filters for transactions with a pending manual anti-fraud review.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=pending_review")]
        public bool? PendingReview { get; set; } = null;

        /// <summary>
        /// Filters for transactions where the `checkout_session_id` matches the provided value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=checkout_session_id")]
        public string? CheckoutSessionId { get; set; } = null;

        /// <summary>
        /// Filters for transactions where the `reconciliation_id` matches the provided value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=reconciliation_id")]
        public string? ReconciliationId { get; set; } = null;

        /// <summary>
        /// Filters for transactions with gift card redemptions.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=has_gift_card_redemptions")]
        public bool? HasGiftCardRedemptions { get; set; } = null;

        /// <summary>
        /// Filters for transactions where a gift card used has an `id` that matches the provided value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=gift_card_id")]
        public string? GiftCardId { get; set; } = null;

        /// <summary>
        /// Filters for transactions that have at least one gift card redemption where the last 4 digits of its gift card number matches exactly with the provided value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=gift_card_last4")]
        public string? GiftCardLast4 { get; set; } = null;

        /// <summary>
        /// Filters for transactions that have at least one associated settlement record.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=has_settlements")]
        public bool? HasSettlements { get; set; } = null;

        /// <summary>
        /// Filter for transactions that have a card with a BIN that matches exactly with the provided value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=payment_method_bin")]
        public string? PaymentMethodBin { get; set; } = null;

        /// <summary>
        /// Filters the results to only the transactions that have a payment source that matches with any of the provided values.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=payment_source")]
        public List<string>? PaymentSource { get; set; } = null;

        /// <summary>
        /// Filters for transactions where the `is_subsequent_payment` matches the provided value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=is_subsequent_payment")]
        public bool? IsSubsequentPayment { get; set; } = null;

        /// <summary>
        /// Filters for transactions where the `merchant_initiated` matches the provided value.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=merchant_initiated")]
        public bool? MerchantInitiated { get; set; } = null;

        /// <summary>
        /// Filters for transactions that attempted 3DS authentication or not.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=used_3ds")]
        public bool? Used3ds { get; set; } = null;

        /// <summary>
        /// Filters the results to only get the items for which some of the buyer data contains exactly the provided `buyer_search` values.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=buyer_search")]
        public List<string>? BuyerSearch { get; set; } = null;

        /// <summary>
        /// The ID of the merchant account to use for this request.
        /// </summary>
        [SpeakeasyMetadata("header:style=simple,explode=false,name=x-gr4vy-merchant-account-id")]
        public string? MerchantAccountId { get; set; }
    }
}