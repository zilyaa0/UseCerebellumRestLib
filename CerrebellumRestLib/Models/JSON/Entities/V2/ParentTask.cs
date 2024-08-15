using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.V2
{
    public class ParentTask : JsonBase
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("no")]
        public long Nomer { get; set; }

        [JsonProperty("date")]
        public long? TaskDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("organization_id")]
        public int? OrganizationId { get; set; }

        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        [JsonProperty("organization_logo")]
        public string OrganizationLogo { get; set; }

        [JsonProperty("stage")]
        public TaskConfirmedType? Stage { get; set; }

        [JsonProperty("type_id")]
        public int? WorkTypeId { get; set; }

        [JsonProperty("type_name")]
        public string WorkTypeName { get; set; }

        [JsonProperty("type_icon")]
        public string WorkTypeIcon { get; set; }

        [JsonProperty("priority_id")]
        public int? PriorityId { get; set; }

        [JsonProperty("priority_name")]
        public string PriorityName { get; set; }

        [JsonProperty("status_id")]
        public int? StatusId { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("assigned_organization_id")]
        public int? AssignedOrganizationId { get; set; }

        [JsonProperty("assigned_organization_name")]
        public string AssignedOrganizationName { get; set; }

        [JsonProperty("assigned_user_id")]
        public int? AssignedUserId { get; set; }

        [JsonProperty("assigned_user_fio")]
        public string AssignedUserFio { get; set; }
    }
}
