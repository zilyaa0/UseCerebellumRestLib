using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ScheduleCreate : ScheduleBase
    {
        [JsonProperty("templates")]
        public IEnumerable<Template> Templates { get; set; }

        [JsonProperty("times")]
        public IEnumerable<TimeCreate> Times { get; set; }
        
        [JsonProperty("dates")]
        public IEnumerable<long> Dates { get; set; }

        [JsonProperty("organization")]
        public ScheduleOrganization Organization { get; set; }
        
        [JsonProperty("contract")]
        public ScheduleContract Contract { get; set; }
    }

    public class ScheduleContract
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
    public class ScheduleAdded: ScheduleBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("times")]
        public IEnumerable<ScheduleTime> Times { get; set; }

        [JsonProperty("user")]
        public ScheduleUser User { get; set; }

        [JsonProperty("workgroup")]
        public Workgroup Workgroup { get; set; }

        [JsonProperty("archive")]
        public bool Archive { get; set; }

        [JsonProperty("organization")]
        public ScheduleOrganization Organization { get; set; }

        [JsonProperty("templates")]
        public IEnumerable<Template> Templates { get; set; }

        [JsonProperty("total_template_count")]
        public int TotalTemplateCount { get; set; }

        [JsonProperty("restricted_access")]
        public bool RestrictedAccess { get; set; }
    }

    public partial class Template
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class TimeCreate
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("on")]
        public bool On { get; set; }
    }
}
