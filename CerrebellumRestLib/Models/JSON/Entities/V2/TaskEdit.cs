using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.V2
{
    public class TaskEdit: JsonBase
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type_id")]
        public int? WorkTypeId { get; set; }

        [JsonProperty("priority_id")]
        public int? PriorityId { get; set; }

        [JsonProperty("parent_id")]
        public long? ParentId { get; set; }

        [JsonProperty("status_id")]
        public int? StatusId { get; set; }

        [JsonProperty("stage")]
        public TaskConfirmedType? Stage { get; set; }

        [JsonProperty("assigned_user_id")]
        public int? AssignedUserId { get; set; }

        [JsonProperty("assigned_organization_id")]
        public int? AssignedOrganizationId { get; set; }

        [JsonProperty("deadline")]
        public long? Deadline { get; set; }

        [JsonProperty("is_template")]
        public bool? IsTemplate { get; set; }
        [JsonProperty("photo_main")]
        public int? PhotoMain { get; set; }

        //[lon, lat]
        [JsonProperty("point")]
        public IEnumerable<double> Point { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, CustomFieldValue> Fields { get; set; }

        [JsonProperty("attachments")]
        public IEnumerable<Attachment> Attachments { get; set; }

        [JsonProperty("service_object_id")]
        public long? ServiceObjectId { get; set; }

        [JsonProperty("service_object_layer_id")]
        public long? ServiceObjectLayerId { get; set; }
    }
    public class TaskCreate : TaskEdit
    {
        [JsonProperty("date")]
        public long TaskDate { get; set; }

        [JsonProperty("organization_id")]
        public int? OrganizationId { get; set; }

        [JsonProperty("contract_id")]
        public int? ContractId { get; set; }

        public bool IsValid()
        {
            return TaskDate > 0;
        }
    }
}
