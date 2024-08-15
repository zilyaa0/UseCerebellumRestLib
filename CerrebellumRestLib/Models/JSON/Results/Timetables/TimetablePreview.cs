using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results.Timetables
{
    public class TimetablePreview : JsonBase
    {
        [JsonProperty("schedule")]
        public TimetablePreview Schedule { get; set; }

        [JsonProperty("holidays")]
        public object[] Holidays { get; set; }

        [JsonProperty("runs")]
        public TimetablePreviewRun[] Runs { get; set; }
    }

    public class TimetableBase : JsonBase
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("archive")]
        public bool? Archive { get; set; }

        [JsonProperty("weekdays")]
        public List<Day> Weekdays { get; set; }

        [JsonProperty("on")]
        public bool? On { get; set; }

        [JsonProperty("start_date_time")]
        public long? StartDateTime { get; set; }

        [JsonProperty("finish_date_time")]
        public long? FinishDateTime { get; set; }

        [JsonProperty("holidays")]
        public List<Day> Holidays { get; set; }

        [JsonProperty("contract")]
        public ScheduleContract Contract { get; set; }

        [JsonProperty("workgroup")]
        public Workgroup Workgroup { get; set; }

        [JsonProperty("cluster")]
        public Workgroup Cluster { get; set; }

        [JsonProperty("user")]
        public ScheduleUser User { get; set; }

        [JsonProperty("worktime")]
        public long? Worktime { get; set; }

        [JsonProperty("organization")]
        public ScheduleOrganization Organization { get; set; }

        [JsonProperty("total_template_count")]
        public long TotalTemplateCount { get; set; }
    }

    public class TimetablePreviewRun
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }

}