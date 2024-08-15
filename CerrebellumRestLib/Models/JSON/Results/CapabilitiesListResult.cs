using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class CapabilitiesListResult : JsonBase
    {
        [JsonProperty("capabilities")]
        public List<Capability> Capabilities { get; set; }
    }
}
