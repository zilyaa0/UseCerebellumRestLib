using System.Reflection;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.Enums;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public abstract class TaskUnitEdit : JsonBase
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("news_type_id")]
        public int? WorkTypeId { get; set; }

        [JsonProperty("category_id")]
        public int? CategoryId { get; set; }

        [JsonProperty("deadline")]
        public long? Deadline { get; set; }

        [JsonProperty("photo_main")]
        public int? MainPhotoIndex { get; set; }

        [JsonProperty("system_data")]
        public string SystemData { get; set; }

        [JsonProperty("custom_fields")]
        public string CustomFields { get; set; }

        [JsonProperty("attachments")]
        public Attachment[] Attachments { get; set; }

        [JsonProperty("assigned_status")]
        public TaskStatus? AssignedStatus { get; set; }

        [JsonProperty("assigned_organization_id")]
        public int? AssignedOrganisationId { get; set; }

        [JsonProperty("assigned_user_id")]
        public int? AssignedUserId { get; set; }
    }
    
    public class TaskUnitCreate : TaskUnitEdit
    {
        [JsonProperty("issue_date")]
        public long IssueDate { get; set; }

        [JsonProperty("department_id")]
        public int DepartmentId { get; set; }

        [JsonProperty("service_object_id")]
        public long? ServiceObjectId { get; set; }

        [JsonProperty("service_object_layer_id")]
        public long? ServiceObjectLayerId { get; set; }

        [JsonProperty("parent_id")]
        public int? ParentId { get; set; }

        public bool IsValid()
        {
            return WorkTypeId != null && CategoryId != null;
        }
    }

    public class TaskUnitUpdate : TaskUnitEdit
    {
        [JsonProperty("restricted")]
        public bool? IsRestricted { get; set; }

        [JsonProperty("archive")]
        public bool? IsArchived { get; set; }

        [JsonProperty("point")]
        public double[] Point { get; set; }

        [JsonProperty("pointZoom")]
        public int? PointZoom { get; set; }

        [JsonProperty("update_comments")]
        public string UpdateComment { get; set; }

        [JsonProperty("is_template")]
        public bool? IsTemplate { get; set; }

        [JsonProperty("confirmed")]
        public TaskConfirmedType? ConfirmedType { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }
    }
}