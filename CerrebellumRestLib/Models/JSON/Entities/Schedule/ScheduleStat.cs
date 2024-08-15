using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ScheduleStat : JsonBase
    {
        [JsonProperty("stats")]
        public List<Stat> Stats { get; set; }

        [JsonProperty("items")]
        public List<ScheduleTasks> ScheduleTasks { get; set; }
    }

    public class Stat
    {
        [JsonProperty("off")]
        public int Off { get; set; }
        [JsonProperty("fail")]
        public int Fail { get; set; }
        [JsonProperty("missed")]
        public int Missed { get; set; }
        [JsonProperty("planned")]
        public int Planned { get; set; }
        [JsonProperty("done_expired")]
        public int DoneExpired { get; set; }
        [JsonProperty("done_not_expired")]
        public int DoneNotExpired { get; set; }
        [JsonProperty("rejected_expired")]
        public int RejectedExpired { get; set; }
        [JsonProperty("rejected_not_expired")]
        public int RejectedNotExpired { get; set; }
        [JsonProperty("working_expired")]
        public int WorkingExpired { get; set; }
        [JsonProperty("working_not_expired")]
        public int WorkingNotExpired { get; set; }
        [JsonProperty("date")]
        public long? Date { get; set; }
        [JsonProperty("on")]
        public int On { get; set; }
        [JsonProperty("created")]
        public int Created { get; set; }
    }
}
