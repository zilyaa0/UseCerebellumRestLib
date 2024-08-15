using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.V2
{
    public class TaskDistribution : JsonBase
    {
        [JsonProperty("type")]
        public Dictionary<int, int> WorkTypes { get; set; }

        [JsonProperty("priority")]
        public Dictionary<int, int> Priorities { get; set; }

        [JsonProperty("stage")]
        public Dictionary<int, int> Stadiums { get; set; }

        [JsonProperty("status")]
        public Dictionary<int, int> Statuses { get; set; }
    }
}
