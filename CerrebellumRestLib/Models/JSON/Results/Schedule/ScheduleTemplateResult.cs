using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class ScheduleTemplateResult : JsonBase
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
        
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("items")]
        public IEnumerable<ScheduleTemplate> ScheduleTemplates { get; set; }
    }
}
