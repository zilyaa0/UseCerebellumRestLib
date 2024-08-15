using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    class ScheduleAddedResult:JsonBase
    {
        [JsonProperty("schedule")]
        public ScheduleAdded Schedule { get; set; }
    }
}
