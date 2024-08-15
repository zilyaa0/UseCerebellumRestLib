using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results.Timetables
{
    internal class TimetableRunsResult : JsonBase
    {
        [JsonProperty("items")]
        public List<TimetableRun> Items { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }
    }

    public class TimetableRun
    {
        [JsonProperty("runs")]
        public List<Run> Runs { get; set; }

        [JsonProperty("schedule")]
        public Timetable Schedule { get; set; }
    }
}
