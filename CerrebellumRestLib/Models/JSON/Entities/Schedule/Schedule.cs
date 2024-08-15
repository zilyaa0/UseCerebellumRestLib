using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public abstract class ScheduleBase : JsonBase
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("worktime", NullValueHandling = NullValueHandling.Include)]
        public long? Worktime { get; set; }

        [JsonProperty("on")]
        public bool On { get; set; }
    }

    public class Schedule : ScheduleBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("times")]
        public List<ScheduleTime> Times { get; set; }

        [JsonProperty("dates")]
        public List<long> Dates { get; set; }

        [JsonProperty("user")]
        public ScheduleUser User { get; set; }

        [JsonProperty("workgroup")]
        public Workgroup Workgroup { get; set; }

        [JsonProperty("archive")]
        public bool Archive { get; set; }

        [JsonProperty("organization")]
        public ScheduleOrganization Organization { get; set; }

        [JsonProperty("sample_template")]
        public ScheduleTemplate SampleTemplate { get; set; }

        [JsonProperty("total_template_count")]
        public int TotalTemplateCount { get; set; }

        [JsonProperty("restricted_access")]
        public bool RestrictedAccess { get; set; }

        [JsonProperty("contract")]
        public ContractInfo Contract { get; set; }

        public Schedule Clone()
        {
            return new Schedule
            {
                Id = Id,
                Times = Times != null ? Times.Select(w => new ScheduleTime { Id = w.Id, On = w.On, Time = w.Time }).ToList() : null,
                Dates = Dates,
                User = User,
                Workgroup = Workgroup,
                Organization = Organization,
                SampleTemplate = SampleTemplate,
                TotalTemplateCount = TotalTemplateCount,
                RestrictedAccess = RestrictedAccess,
                Contract = Contract,
                Archive = Archive,
                On = On,
                Title = Title,
                Worktime = Worktime
            };
        }

        public override string ToString()
        {
            return Title.ToString();
        }
    }

    public class ScheduleTemplate : ScheduleTask
    {

    }

    public class SchedulePriority
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ScheduleOrganization
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ScheduleUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fio")]
        public string Fio { get; set; }
    }

    public class ScheduleType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class ScheduleTime
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("on")]
        public bool On { get; set; }
    }

    public class Workgroup
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
    public class ContractInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
