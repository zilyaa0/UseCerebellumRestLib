using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities.Timetables
{
    public class TimetablesCreate : JsonBase
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("worktime")]
        public int? Worktime { get; set; }

        [JsonProperty("contract")]
        public ScheduleContract Contract { get; set; }

        [JsonProperty("start_date_time")]
        public long? StartDateTime { get; set; }

        [JsonProperty("finish_date_time")]
        public long? FinishDateTime { get; set; }

        [JsonProperty("on")]
        public bool On { get; set; }

        [JsonProperty("weekdays")]
        public List<Weekday> Weekdays { get; set; }

        [JsonProperty("holidays")]
        public List<Holiday> Holidays { get; set; }

        [JsonProperty("organization")]
        public ScheduleOrganization Organization { get; set; }

        [JsonProperty("cluster")]
        public ScheduleOrganization Cluster { get; set; }

        [JsonProperty("templates")]
        public IEnumerable<Template> Templates { get; set; }
    }
    public class Holiday
    {
        [JsonProperty("on")]
        public bool On { get; set; }

        [JsonProperty("weekly_patterns")]
        public List<CreatePattern> WeeklyPatterns { get; set; }

        [JsonProperty("random_patterns")]
        public List<CreatePattern> RandomPatterns { get; set; }

        [JsonProperty("yearly_patterns")]
        public List<CreatePattern> YearlyPatterns { get; set; }

        [JsonProperty("monthly_patterns")]
        public List<CreatePattern> MonthlyPatterns { get; set; }
    }

    public class CreatePattern
    {
        [JsonProperty("on")]
        public bool On { get; set; }

        [JsonProperty("value")]
        public List<string> Value { get; set; }
    }

    public class Weekday
    {
        [JsonProperty("on")]
        public bool On { get; set; }

        [JsonProperty("times")]
        public List<CreateTime> Times { get; set; }

        [JsonProperty("periods_months")]
        public List<CreatePattern> PeriodsMonths { get; set; }

        [JsonProperty("weekly_patterns")]
        public List<CreatePattern> WeeklyPatterns { get; set; }

        [JsonProperty("random_patterns")]
        public List<CreatePattern> RandomPatterns { get; set; }

        [JsonProperty("yearly_patterns")]
        public List<CreatePattern> YearlyPatterns { get; set; }

        [JsonProperty("monthly_patterns")]
        public List<CreatePattern> MonthlyPatterns { get; set; }
    }

    public class CreateTime
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("on")]
        public bool On { get; set; }
    }
}