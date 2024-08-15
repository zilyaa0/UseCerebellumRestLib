using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results.Timetables
{
    public class TimetableTasksResult : JsonBase
    {
        [JsonProperty("schedule")]
        public Schedule Schedule { get; set; }

        [JsonProperty("times")]
        public List<string> Times { get; set; }

        [JsonProperty("items")]
        public List<TimetableTaskInfo> Items { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }
    }

    public class TimetableTaskInfo
    {
        [JsonProperty("run")]
        public Run Run { get; set; }

        [JsonProperty("task")]
        public TimetableTask Task { get; set; }

        [JsonProperty("template")]
        public TimetableTemplate Template { get; set; }

        [JsonProperty("template_deleted")]
        public bool TemplateDeleted { get; set; }

        [JsonProperty("fail")]
        public string Fail { get; set; }
    }

    public class TimetableTask
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
}
