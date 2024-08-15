using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.Enums;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ParentTask: JsonBase
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("no")]
        public long Nomer { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("assigned_department_name")]
        public string AssignedOrganizationName { get; set; }

        [JsonProperty("assigned_to")]
        public int? AssignedTo { get; set; }

        [JsonProperty("assigned_to_user")]
        public int? AssignedToUser { get; set; }

        [JsonProperty("assigned_user_fio")]
        public string AssignedUserFio { get; set; }

        [JsonProperty("confirmed")]
        public TaskConfirmedType? ConfirmedType { get; set; }

        [JsonProperty("department_logo")]
        public string OrganizationLogo { get; set; }

        [JsonProperty("news_date")]
        public long? TaskDate { get; set; }

        [JsonProperty("status_id")]
        public int? StatusId { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("news_type_id")]
        public int? WorkTypeId { get; set; }

        [JsonProperty("news_type_name")]
        public string WorkTypeName { get; set; }

        [JsonProperty("department_id")]
        public int? OrganizationId { get; set; }

        [JsonProperty("department_title")]
        public string OrganizationTitle { get; set; }

        [JsonProperty("category_id")]
        public int? PriorityId { get; set; }

        [JsonProperty("category_name")]
        public string PriorityName { get; set; }
    }
}
