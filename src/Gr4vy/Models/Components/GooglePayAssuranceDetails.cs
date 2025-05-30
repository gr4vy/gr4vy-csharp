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
    /// The assurance details provided by Google Pay
    /// </summary>
    public class GooglePayAssuranceDetails
    {

        /// <summary>
        /// Defines if an account was verified.
        /// </summary>
        [JsonProperty("account_verified")]
        public bool? AccountVerified { get; set; } = null;

        /// <summary>
        /// Defines if the card holder was authenticated.
        /// </summary>
        [JsonProperty("card_holder_authenticated")]
        public bool? CardHolderAuthenticated { get; set; } = null;
    }
}