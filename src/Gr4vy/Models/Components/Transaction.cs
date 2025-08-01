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
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// A full transaction resource.
    /// </summary>
    public class Transaction
    {

        /// <summary>
        /// Always `transaction`.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; } = "transaction";

        /// <summary>
        /// The ID for the transaction.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        /// <summary>
        /// The base62 encoded transaction ID. This represents a shorter version of this transaction&apos;s `id` which is sent to payment services, anti-fraud services, and other connectors. You can use this ID to reconcile a payment service&apos;s transaction against our system. This ID is sent instead of the transaction ID because not all services support 36 digit identifiers.
        /// </summary>
        [JsonProperty("reconciliation_id")]
        public string ReconciliationId { get; set; } = default!;

        /// <summary>
        /// The ID of the merchant account this transaction belongs to.
        /// </summary>
        [JsonProperty("merchant_account_id")]
        public string MerchantAccountId { get; set; } = default!;

        /// <summary>
        /// The currency code for this transaction.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; } = default!;

        /// <summary>
        /// The total amount for this transaction across all funding sources including gift cards.
        /// </summary>
        [JsonProperty("amount")]
        public long Amount { get; set; } = default!;

        [JsonProperty("status")]
        public string Status { get; set; } = default!;

        /// <summary>
        /// The amount for this transaction that has been authorized for the `payment_method`. This can be less than the `amount` if gift cards were used.
        /// </summary>
        [JsonProperty("authorized_amount")]
        public long AuthorizedAmount { get; set; } = default!;

        /// <summary>
        /// The total amount captured for this transaction, in the smallest currency unit (for example, cents or pence). This can be the full value of the `authorized_amount` or less.
        /// </summary>
        [JsonProperty("captured_amount")]
        public long CapturedAmount { get; set; } = default!;

        /// <summary>
        /// The total amount refunded for this transaction, in the smallest currency unit (for example, cents or pence). This can be the full value of the `captured_amount` or less.
        /// </summary>
        [JsonProperty("refunded_amount")]
        public long RefundedAmount { get; set; } = default!;

        /// <summary>
        /// The ISO 4217 currency code of this transaction&apos;s settlement.
        /// </summary>
        [JsonProperty("settled_currency")]
        public string? SettledCurrency { get; set; } = null;

        /// <summary>
        /// The net amount settled for this transaction, in the smallest currency unit (for example, cents or pence).
        /// </summary>
        [JsonProperty("settled_amount")]
        public long SettledAmount { get; set; } = default!;

        /// <summary>
        /// Indicates whether this transaction has been settled.
        /// </summary>
        [JsonProperty("settled")]
        public bool Settled { get; set; } = default!;

        /// <summary>
        /// The 2-letter ISO 3166-1 alpha-2 country code for the transaction. Used to filter payment services for processing.
        /// </summary>
        [JsonProperty("country")]
        public string? Country { get; set; } = null;

        /// <summary>
        /// An external identifier that can be used to match the transaction against your own records.
        /// </summary>
        [JsonProperty("external_identifier")]
        public string? ExternalIdentifier { get; set; } = null;

        [JsonProperty("intent")]
        public string Intent { get; set; } = default!;

        /// <summary>
        /// The payment method used for this transaction.
        /// </summary>
        [JsonProperty("payment_method")]
        public TransactionPaymentMethod? PaymentMethod { get; set; } = null;

        /// <summary>
        /// The method used for the transaction.
        /// </summary>
        [JsonProperty("method")]
        public string? Method { get; set; } = null;

        /// <summary>
        /// The name of the instrument used to process the transaction.
        /// </summary>
        [JsonProperty("instrument_type")]
        public string? InstrumentType { get; set; } = null;

        /// <summary>
        /// The standardized error code set by Gr4vy.
        /// </summary>
        [JsonProperty("error_code")]
        public string? ErrorCode { get; set; } = null;

        /// <summary>
        /// The payment service used for this transaction.
        /// </summary>
        [JsonProperty("payment_service")]
        public TransactionPaymentService? PaymentService { get; set; } = null;

        /// <summary>
        /// Whether a manual anti fraud review is pending with an anti fraud service.
        /// </summary>
        [JsonProperty("pending_review")]
        public bool? PendingReview { get; set; } = false;

        /// <summary>
        /// The buyer used for this transaction.
        /// </summary>
        [JsonProperty("buyer")]
        public TransactionBuyer? Buyer { get; set; } = null;

        /// <summary>
        /// This is the response code received from the payment service. This can be set to any value and is not standardized across different payment services.
        /// </summary>
        [JsonProperty("raw_response_code")]
        public string? RawResponseCode { get; set; } = null;

        /// <summary>
        ///  This is the response description received from the payment service. This can be set to any value and is not standardized across different payment services.
        /// </summary>
        [JsonProperty("raw_response_description")]
        public string? RawResponseDescription { get; set; } = null;

        /// <summary>
        /// The shipping details associated with the transaction.
        /// </summary>
        [JsonProperty("shipping_details")]
        public Models.Components.ShippingDetails? ShippingDetails { get; set; } = null;

        /// <summary>
        /// The identifier for the checkout session this transaction is associated with.
        /// </summary>
        [JsonProperty("checkout_session_id")]
        public string? CheckoutSessionId { get; set; } = null;

        /// <summary>
        /// The gift cards redeemed for this transaction.
        /// </summary>
        [JsonProperty("gift_card_redemptions")]
        public List<GiftCardRedemption> GiftCardRedemptions { get; set; } = default!;

        /// <summary>
        /// The gift card service used for this transaction.
        /// </summary>
        [JsonProperty("gift_card_service")]
        public GiftCardService? GiftCardService { get; set; } = null;

        /// <summary>
        /// The date and time when the transaction was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; } = default!;

        /// <summary>
        /// The date and time when the transaction was last updated, in ISO 8601 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; } = default!;

        /// <summary>
        /// Contains information about an airline travel, if applicable.
        /// </summary>
        [JsonProperty("airline")]
        public Airline? Airline { get; set; } = null;

        /// <summary>
        /// This is the response description received from the processor.
        /// </summary>
        [JsonProperty("auth_response_code")]
        public string? AuthResponseCode { get; set; } = null;

        /// <summary>
        /// The response code received from the payment service for the Address Verification Check (AVS). This code is mapped to a standardized Gr4vy AVS response code.
        /// </summary>
        [JsonProperty("avs_response_code")]
        public string? AvsResponseCode { get; set; } = null;

        /// <summary>
        /// The response code received from the payment service for the Card Verification Value (CVV). This code is mapped to a standardized Gr4vy CVV response code.
        /// </summary>
        [JsonProperty("cvv_response_code")]
        public string? CvvResponseCode { get; set; } = null;

        /// <summary>
        /// The mapped decision received from the anti-fraud service. In case of a review decision this field is not updated once the review is resolved.
        /// </summary>
        [JsonProperty("anti_fraud_decision")]
        public string? AntiFraudDecision { get; set; } = null;

        /// <summary>
        /// The way payment method information made it to this transaction.
        /// </summary>
        [JsonProperty("payment_source")]
        public string PaymentSource { get; set; } = default!;

        /// <summary>
        /// Indicates whether the transaction was initiated by the merchant or the customer.
        /// </summary>
        [JsonProperty("merchant_initiated")]
        public bool MerchantInitiated { get; set; } = default!;

        /// <summary>
        /// Indicates whether the transaction represents a subsequent payment or an initial one.
        /// </summary>
        [JsonProperty("is_subsequent_payment")]
        public bool IsSubsequentPayment { get; set; } = default!;

        /// <summary>
        /// An array of cart items that represents the line items of a transaction.
        /// </summary>
        [JsonProperty("cart_items")]
        public List<CartItem>? CartItems { get; set; } = null;

        /// <summary>
        /// The statement descriptor is the text to be shown on the buyer&apos;s statements.
        /// </summary>
        [JsonProperty("statement_descriptor")]
        public StatementDescriptor? StatementDescriptor { get; set; } = null;

        /// <summary>
        /// An identifier for the transaction used by the scheme itself, when available.
        /// </summary>
        [JsonProperty("scheme_transaction_id")]
        public string? SchemeTransactionId { get; set; } = null;

        /// <summary>
        /// The 3-D Secure data that was sent to the payment service for the transaction.
        /// </summary>
        [JsonProperty("three_d_secure")]
        public TransactionThreeDSecureSummary? ThreeDSecure { get; set; } = null;

        /// <summary>
        /// The payment service&apos;s unique ID for the transaction.
        /// </summary>
        [JsonProperty("payment_service_transaction_id")]
        public string? PaymentServiceTransactionId { get; set; } = null;

        /// <summary>
        /// A list of additional identifiers that we may keep track of to manage this transaction. This may include the authorization ID, capture ID, and processor ID, as well as an undefined list of additional identifiers.
        /// </summary>
        [JsonProperty("additional_identifiers")]
        public Dictionary<string, string?>? AdditionalIdentifiers { get; set; }

        /// <summary>
        /// Additional information about the transaction stored as key-value pairs.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; } = null;

        /// <summary>
        /// The date this transaction was authorized at.
        /// </summary>
        [JsonProperty("authorized_at")]
        public DateTime? AuthorizedAt { get; set; } = null;

        /// <summary>
        /// The date this transaction was captured at.
        /// </summary>
        [JsonProperty("captured_at")]
        public DateTime? CapturedAt { get; set; } = null;

        /// <summary>
        /// The date this transaction was voided at.
        /// </summary>
        [JsonProperty("voided_at")]
        public DateTime? VoidedAt { get; set; } = null;

        /// <summary>
        /// The date this transaction&apos;s approval URL will expire at.
        /// </summary>
        [JsonProperty("approval_expires_at")]
        public DateTime? ApprovalExpiresAt { get; set; } = null;

        /// <summary>
        /// The date this transaction&apos;s approval timed out at.
        /// </summary>
        [JsonProperty("buyer_approval_timedout_at")]
        public DateTime? BuyerApprovalTimedoutAt { get; set; } = null;

        [JsonProperty("intent_outcome")]
        public string IntentOutcome { get; set; } = default!;

        /// <summary>
        /// The outcome of the original intent of a transaction. This allows you to understand if the intent of the transaction (e.g. `capture` or `authorize`) has been achieved when dealing with multiple payment instruments.
        /// </summary>
        [JsonProperty("multi_tender")]
        public bool MultiTender { get; set; } = default!;

        /// <summary>
        /// Marks the transaction as an AFT. Requires the payment service to support this feature, and might `recipient` and `buyer` data
        /// </summary>
        [JsonProperty("account_funding_transaction")]
        public bool AccountFundingTransaction { get; set; } = default!;

        /// <summary>
        /// The recipient of any account to account funding. For use with AFTs.
        /// </summary>
        [JsonProperty("recipient")]
        public Recipient? Recipient { get; set; } = null;

        /// <summary>
        /// An optional merchant advice code which provides insight into the type of transaction or reason why the payment failed.
        /// </summary>
        [JsonProperty("merchant_advice_code")]
        public string? MerchantAdviceCode { get; set; } = null;

        /// <summary>
        /// The number of installments for this transaction, if applicable.
        /// </summary>
        [JsonProperty("installment_count")]
        public long? InstallmentCount { get; set; } = null;
    }
}