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
    
    public class TrustlyOptions
    {

        /// <summary>
        /// Indicates to Gr4vy whether or not the stored Trustly agreement needs refreshing.
        /// </summary>
        [JsonProperty("refreshSplitToken")]
        public bool? RefreshSplitToken { get; set; } = null;
    }
}