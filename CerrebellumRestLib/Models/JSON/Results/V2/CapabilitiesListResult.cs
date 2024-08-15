using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results.V2
{
    class CapabilitiesListResult: JsonBase
    {
        [JsonProperty("items")]
        public List<Capability> Capabilities { get; set; }
    }
}
