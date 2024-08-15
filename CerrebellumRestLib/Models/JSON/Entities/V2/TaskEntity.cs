using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.Enums;
using CerebellumRestLib.Models.JSON.Entities.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.V2
{
    public class TaskEntity : JsonBase
    {
        [JsonProperty("id")]
        public long TaskId { get; set; }

        [JsonProperty("no")]
        public long Nomer { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("user_fio")]
        public string UserFio { get; set; }

        [JsonProperty("organization_id")]
        public int OrganizationId { get; set; }

        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        [JsonProperty("organization_logo")]
        public string OrganizationLogo { get; set; }

        [JsonProperty("workgroup_id")]
        public int? WorkgroupId { get; set; }

        [JsonProperty("date")]
        public long TaskDate { get; set; }

        [JsonProperty("deadline")]
        public long? Deadline { get; set; }

        [JsonProperty("expired_date")]
        public long? ExpiredDate { get; set; }

        [JsonProperty("stage")]
        public TaskConfirmedType Stage { get; set; }

        [JsonProperty("type_id")]
        public int WorkTypeId { get; set; }

        [JsonProperty("type_name")]
        public string WorkTypeName { get; set; }

        [JsonProperty("type_icon")]
        public string WorkTypeIcon { get; set; }

        [JsonProperty("priority_id")]
        public int PriorityId { get; set; }

        [JsonProperty("priority_name")]
        public string PriorityName { get; set; }

        [JsonProperty("status_id")]
        public int StatusId { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("num_main_photo")]
        public int? NumMainPhoto { get; set; }

        [JsonProperty("update_date")]
        public long UpdateDate { get; set; }

        [JsonProperty("assigned_organization_id")]
        public int? AssignedOrganizationId { get; set; }

        [JsonProperty("assigned_organization_name")]
        public string AssignedOrganizationName { get; set; }

        [JsonProperty("assigned_user_id")]
        public int? AssignedUserId { get; set; }

        [JsonProperty("assigned_user_fio")]
        public string AssignedUserFio { get; set; }

        [JsonProperty("lon")]
        public double? Longitude { get; set; }

        [JsonProperty("lat")]
        public double? Latitude { get; set; }

        [JsonProperty("is_template")]
        public bool IsTemplate { get; set; }

        [JsonProperty("unread_message_count")]
        public int? UnreadMessageCount { get; set; }

        [JsonProperty("sample_matching")]
        public double? SampleMatching { get; set; }

        [JsonProperty("service_object_layer_id")]
        public long? ServiceObjectLayerId { get; set; }

        [JsonProperty("service_object_layer_title")]
        public string ServiceObjectLayerTitle { get; set; }

        [JsonProperty("service_object_id")]
        public long? ServiceObjectId { get; set; }

        [JsonProperty("service_object_title")]
        public string ServiceObjectTitle { get; set; }

        [JsonProperty("contract_id")]
        public int? ContractId { get; set; }

        [JsonProperty("contract_title")]
        public string ContractTitle { get; set; }

        [JsonProperty("favorite")]
        public bool? IsFavorite { get; set; }

        [JsonProperty("schedule_id")]
        public int? ScheduleId { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, CustomFieldValue> Fields { get; set; }

        [JsonProperty("attachments")]
        public IEnumerable<FileEntry> Attachments { get; set; }

        [JsonProperty("parent")]
        public ParentTask Parent { get; set; }

        [JsonIgnore]
        public Configuration Configuration { get; set; }

        [JsonIgnore]
        public ScheduleInfo Schedule { get; set; }

        public TaskUnit ConvertToTaskUnit()
        {
            return new TaskUnit()
            {
                Id = (int)TaskId,
                Nomer = Nomer,
                Title = Title,
                AssignedOrganizationName = AssignedOrganizationName,
                AssignedTo = AssignedOrganizationId,
                AssignedToUser = AssignedUserId,
                AssignedUserFio = AssignedUserFio,
                AssignedStatus = (TaskStatus)StatusId,
                Attachments = Attachments,
                Configuration = Configuration,
                ConfirmedType = Stage,
                CustomFields = Fields != null ? JsonConvert.SerializeObject(Fields).Trim('"') : null,
                Deadline = Deadline,
                IsTemplate = IsTemplate,
                Latitude = Latitude,
                Longitude = Longitude,
                NumMainPhoto = NumMainPhoto,
                OrganizationId = OrganizationId,
                OrganizationLogo = OrganizationLogo,
                OrganizationTitle = OrganizationName,
                PriorityId = PriorityId,
                PriorityName = PriorityName,
                ServiceObjectId = ServiceObjectId,
                ServiceObjectLayerId = ServiceObjectLayerId,
                ServiceObjectLayerTitle = ServiceObjectLayerTitle,
                ServiceObjectTitle = ServiceObjectTitle,
                StatusId = StatusId,
                StatusName = StatusName,
                Schedule = Schedule,
                TaskDate = TaskDate,
                Text = Text,
                UnreadMessageCount = UnreadMessageCount,
                ContractId = ContractId,
                ContractTitle = ContractTitle,
                UserFio = UserFio,
                UserId = UserId,
                UpdateDate = UpdateDate,
                WorkTypeIcon = WorkTypeIcon,
                WorkTypeId = WorkTypeId,
                WorkTypeName = WorkTypeName,
                SampleMatching = SampleMatching,
                IsFavorite = IsFavorite,
                Parent = Parent != null ? new CerebellumRestLib.Models.JSON.Entities.ParentTask
                {
                    Id = (int)Parent.Id,
                    Nomer = Parent.Nomer,
                    AssignedOrganizationName = Parent.AssignedOrganizationName,
                    AssignedTo = Parent.AssignedOrganizationId,
                    AssignedToUser = Parent.AssignedUserId,
                    AssignedUserFio = Parent.AssignedUserFio,
                    ConfirmedType = Parent.Stage,
                    OrganizationId = Parent.OrganizationId,
                    OrganizationLogo = Parent.OrganizationLogo,
                    OrganizationTitle = Parent.OrganizationName,
                    PriorityId = Parent.PriorityId,
                    PriorityName = Parent.PriorityName,
                    StatusId = Parent.StatusId,
                    StatusName = Parent.StatusName,
                    TaskDate = Parent.TaskDate,
                    Title = Parent.Title,
                    WorkTypeId = Parent.WorkTypeId,
                    WorkTypeName = Parent.WorkTypeName,
                } : null
            };
        }
    }
    public class ScheduleInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("archive")]
        public bool Archive { get; set; }

        [JsonProperty("organization")]
        public ScheduleOrganization Organization { get; set; }
    }
    public class TaskEntityWithConfiguration : JsonBase
    {
        [JsonProperty("task")]
        public TaskEntity Task { get; set; }

        [JsonProperty("configuration")]
        public Configuration Configuration { get; set; }

        [JsonProperty("schedule")]
        public ScheduleInfo Schedule { get; set; }
    }
}
