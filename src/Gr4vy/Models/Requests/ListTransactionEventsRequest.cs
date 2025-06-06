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
    
    public class ListTransactionEventsRequest
    {

        /// <summary>
        /// The ID of the transaction
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=transaction_id")]
        public string TransactionId { get; set; } = default!;

        /// <summary>
        /// A pointer to the page of results to return.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=cursor")]
        public string? Cursor { get; set; } = null;

        /// <summary>
        /// The maximum number of items that are at returned.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=limit")]
        public long? Limit { get; set; } = 100;

        /// <summary>
        /// The ID of the merchant account to use for this request.
        /// </summary>
        [SpeakeasyMetadata("header:style=simple,explode=false,name=x-gr4vy-merchant-account-id")]
        public string? MerchantAccountId { get; set; }
    }
}