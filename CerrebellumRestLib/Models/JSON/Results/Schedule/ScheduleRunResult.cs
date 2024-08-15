using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    class ScheduleRunResult : JsonBase
    {
        [JsonProperty("items")]
        public List<ScheduleRun> ScheduleRuns { get; set; }
    }
}