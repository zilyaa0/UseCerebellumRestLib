using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results.Timetables
{
    public class TimetableStatResult : JsonBase
    {
        [JsonProperty("stats")]
        public List<TimetableStat> Stats { get; set; }
    }

    public class TimetableStat
    {
        [JsonProperty("creating")]
        public int Creating { get; set; }

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

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
