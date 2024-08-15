using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ScheduleTasks
    {
        [JsonProperty("task")]
        public ScheduleTask Task { get; set; }

        [JsonProperty("run")]
        public Run Run { get; set; }

        [JsonProperty("template")]
        public ScheduleTask Template { get; set; }

        [JsonProperty("fail")]
        public string Fail { get; set; }

        [JsonProperty("template_deleted")]
        public bool TemplateDeleted { get; set; }
    }
    public class Run
    {
        [JsonProperty("stats")]
        public Stat Stats { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }

    public class ScheduleTask
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("no")]
        public int Nomer { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("organization")]
        public ScheduleOrganization Organization { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("deadline")]
        public long? Deadline { get; set; }

        [JsonProperty("stage")]
        public int Stage { get; set; }

        [JsonProperty("type")]
        public ScheduleType WorkType { get; set; }

        [JsonProperty("priority")]
        public SchedulePriority Priority { get; set; }

        [JsonProperty("assigned_organization")]
        public ScheduleOrganization AssignedOrganization { get; set; }

        [JsonProperty("status")]
        public ScheduleTaskStatus Status { get; set; }

        [JsonProperty("assigned_user")]
        public ScheduleUser AssignedUser { get; set; }

        [JsonProperty("num_main_photo")]
        public int? NumMainPhoto { get; set; }

        [JsonProperty("update_date")]
        public long UpdateDate { get; set; }

        [JsonProperty("deleted")]
        public string Deleted { get; set; }

        [JsonProperty("workgroup_id")]
        public int WorkgroupId { get; set; }
    }

    public class ScheduleTaskStatus
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}