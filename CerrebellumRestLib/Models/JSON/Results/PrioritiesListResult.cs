using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class PrioritiesListResult : JsonBase
    {
        [JsonProperty("category")]
        public List<Priority> Priorities { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
