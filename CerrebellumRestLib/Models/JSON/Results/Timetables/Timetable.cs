using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.Timetables;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results.Timetables
{
    public class TimetableListResult : JsonBase
    {
        [JsonProperty("items")]
        public List<Timetable> Items { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }
    }

    public class Timetable : TimetableBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("schedule_id")]
        public long ScheduleId { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }

    public class Day
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("on")]
        public bool On { get; set; }

        [JsonProperty("random_patterns")]
        public List<TimetablePattern> RandomPatterns { get; set; }

        [JsonProperty("weekly_patterns")]
        public List<TimetablePattern> WeeklyPatterns { get; set; }

        [JsonProperty("monthly_patterns")]
        public List<TimetablePattern> MonthlyPatterns { get; set; }

        [JsonProperty("yearly_patterns")]
        public List<TimetablePattern> YearlyPatterns { get; set; }

        [JsonProperty("times")]
        public List<Time> Times { get; set; }

        [JsonProperty("periods_months")]
        public List<object> PeriodsMonths { get; set; }
    }

    public class TimetablePattern : CreatePattern
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
    }

    public class Time : CreateTime
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
    }
}