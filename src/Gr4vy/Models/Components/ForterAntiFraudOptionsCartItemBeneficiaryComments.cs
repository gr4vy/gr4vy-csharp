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
    
    public class ForterAntiFraudOptionsCartItemBeneficiaryComments
    {

        /// <summary>
        /// Comments from the user to the merchant.
        /// </summary>
        [JsonProperty("user_comments_to_merchant")]
        public string? UserCommentsToMerchant { get; set; } = null;

        /// <summary>
        /// Message intended for the beneficiary of the item.
        /// </summary>
        [JsonProperty("message_to_beneficiary")]
        public string? MessageToBeneficiary { get; set; } = null;

        /// <summary>
        /// Comments from the merchant about this transaction.
        /// </summary>
        [JsonProperty("merchant_comments")]
        public string? MerchantComments { get; set; } = null;
    }
}