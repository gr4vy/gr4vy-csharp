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
    using System.Collections.Generic;
    
    /// <summary>
    /// A settlement record for a transaction.
    /// </summary>
    public class Settlement
    {

        /// <summary>
        /// Always &apos;settlement&apos;.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; } = "settlement";

        /// <summary>
        /// The unique identifier for the settlement.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        /// <summary>
        /// The merchant account this settlement belongs to.
        /// </summary>
        [JsonProperty("merchant_account_id")]
        public string MerchantAccountId { get; set; } = default!;

        /// <summary>
        /// The date and time the settlement was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; } = default!;

        /// <summary>
        /// The date and time the settlement was last updated, in ISO 8601 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; } = default!;

        /// <summary>
        /// The date and time the settlement was posted, in ISO 8601 format.
        /// </summary>
        [JsonProperty("posted_at")]
        public DateTime PostedAt { get; set; } = default!;

        /// <summary>
        /// The date and time the settlement was ingested, in ISO 8601 format.
        /// </summary>
        [JsonProperty("ingested_at")]
        public DateTime IngestedAt { get; set; } = default!;

        /// <summary>
        /// ISO 4217 currency code for the settlement.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; } = default!;

        /// <summary>
        /// The total settled amount in the smallest currency unit (e.g. cents).
        /// </summary>
        [JsonProperty("amount")]
        public long Amount { get; set; } = default!;

        /// <summary>
        /// The exchange rate used for settlement, if applicable.
        /// </summary>
        [JsonProperty("exchange_rate")]
        public double? ExchangeRate { get; set; } = null;

        /// <summary>
        /// The commission amount deducted in the smallest currency unit.
        /// </summary>
        [JsonProperty("commission")]
        public long Commission { get; set; } = default!;

        /// <summary>
        /// The interchange fee, if applicable, in the smallest currency unit.
        /// </summary>
        [JsonProperty("interchange")]
        public long? Interchange { get; set; } = null;

        /// <summary>
        /// The markup fee, if applicable, in the smallest currency unit.
        /// </summary>
        [JsonProperty("markup")]
        public long? Markup { get; set; } = null;

        /// <summary>
        /// The scheme fee, if applicable, in the smallest currency unit.
        /// </summary>
        [JsonProperty("scheme_fee")]
        public long? SchemeFee { get; set; } = null;

        /// <summary>
        /// The report ID from the payment service.
        /// </summary>
        [JsonProperty("payment_service_report_id")]
        public string PaymentServiceReportId { get; set; } = default!;

        /// <summary>
        /// List of file IDs for the payment service report.
        /// </summary>
        [JsonProperty("payment_service_report_file_ids")]
        public List<string> PaymentServiceReportFileIds { get; set; } = default!;

        /// <summary>
        /// The transaction this settlement is associated with.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; } = default!;
    }
}