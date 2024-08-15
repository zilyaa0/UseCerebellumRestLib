using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class WorkTypesCompressedListResult: JsonBase
    {

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("newstype")]
        public List<WorkTypeCompressed> WorkTypeCompresseds { get; set; }
    }
}
