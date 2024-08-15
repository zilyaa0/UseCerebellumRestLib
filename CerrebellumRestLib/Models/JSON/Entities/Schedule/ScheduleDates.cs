using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ScheduleDates : JsonBase
    {
        [JsonProperty("items")]
        public List<long> Dates { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }


    }
}
