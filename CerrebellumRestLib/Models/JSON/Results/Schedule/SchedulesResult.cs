using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    class SchedulesResult:JsonBase
    {
        [JsonProperty("items")]
        public List<Schedule> Schedules { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
