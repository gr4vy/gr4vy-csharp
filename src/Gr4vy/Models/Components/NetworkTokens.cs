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
    using System.Collections.Generic;
    
    public class NetworkTokens
    {

        /// <summary>
        /// A list of items returned for this request.
        /// </summary>
        [JsonProperty("items")]
        public List<NetworkToken> Items { get; set; } = default!;
    }
}