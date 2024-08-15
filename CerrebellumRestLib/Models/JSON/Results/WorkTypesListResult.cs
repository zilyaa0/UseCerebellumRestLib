using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class WorkTypesListResult : JsonBase
    {
        [JsonProperty("newstype")]
        public List<WorkType> WorkTypes { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
