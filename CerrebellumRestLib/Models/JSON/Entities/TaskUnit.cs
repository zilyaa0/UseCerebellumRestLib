using System.Collections.Generic;
using Newtonsoft.Json;
using CerebellumRestLib.Models.Enums;
using System;
using CerebellumRestLib.Models.JSON.Entities.V2;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class TaskUnit : ICloneable
    {
        #region Fields
        private string _customFields;
        #endregion

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
        public TaskConfirmedType ConfirmedType { get; set; }

        [JsonProperty("department_logo")]
        public string OrganizationLogo { get; set; }

        [JsonProperty("news_date")]
        public long TaskDate { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("user_fio")]
        public string UserFio { get; set; }

        [JsonProperty("parent")]
        public ParentTask Parent { get; set; }

        [JsonProperty("deadline")]
        public long? Deadline { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("Bounds_minx")]
        public object BoundsMinX { get; set; }

        [JsonProperty("Bounds_miny")]
        public object BoundsMinY { get; set; }

        [JsonProperty("Bounds_maxx")]
        public object BoundsMaxX { get; set; }

        [JsonProperty("Bounds_maxy")]
        public object BoundsMaxY { get; set; }

        [JsonProperty("archive")]
        public string Archive { get; set; }

        [JsonProperty("confirmed_comment")]
        public object ConfirmedComment { get; set; }

        [JsonProperty("news_type_logo")]
        public string WorkTypeLogo { get; set; }

        [JsonProperty("Bounds")]
        public List<string> Bounds { get; set; }

        [JsonProperty("assigned_change_date")]
        public long? AssignedChangeDate { get; set; }

        [JsonProperty("update_date")]
        public long UpdateDate { get; set; }

        [JsonProperty("restricted")]
        public string Restricted { get; set; }

        [JsonProperty("assigned_status")]
        public TaskStatus AssignedStatus { get; set; }

        [JsonProperty("system_data")]
        public string SystemData { get; set; }

        [JsonProperty("lon")]
        public double? Longitude { get; set; }

        [JsonProperty("lat")]
        public double? Latitude { get; set; }

        [JsonProperty("custom_fields")]
        public string CustomFields
        {
            set
            {
                if (value != null)
                {
                    CustomFieldDictionary = JsonConvert.DeserializeObject<Dictionary<string, FieldData>>(value);
                }
                _customFields = value;

            }
            get { return _customFields; }
        }

        [JsonProperty("notice")]
        public int Notice { get; set; }


        [JsonProperty("num_main_photo")]
        public int? NumMainPhoto { get; set; }

        [JsonProperty("zoom")]
        public int? Zoom { get; set; }

        [JsonProperty("attachments")]
        public IEnumerable<FileEntry> Attachments { get; set; } //service_object_id=(null) service_object_layer_id=(null)

        [JsonProperty("service_object_layer_id")]
        public long? ServiceObjectLayerId { get; set; }

        [JsonProperty("service_object_layer_title")]
        public string ServiceObjectLayerTitle { get; set; }

        [JsonProperty("service_object_id")]
        public long? ServiceObjectId { get; set; }

        [JsonProperty("service_object_title")]
        public string ServiceObjectTitle { get; set; }

        [JsonProperty("is_template")]
        public bool IsTemplate { get; set; }

        [JsonProperty("category_id")]
        public int PriorityId { get; set; }

        [JsonProperty("category_name")]
        public string PriorityName { get; set; }

        [JsonProperty("department_id")]
        public int OrganizationId { get; set; }

        [JsonProperty("department_title")]
        public string OrganizationTitle { get; set; }

        [JsonProperty("news_type_id")]
        public int WorkTypeId { get; set; }

        [JsonProperty("news_type_name")]
        public string WorkTypeName { get; set; }

        [JsonProperty("news_type_icon")]
        public string WorkTypeIcon { get; set; }

        [JsonProperty("status_id")]
        public int StatusId { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("unread_message_count")]
        public int? UnreadMessageCount { get; set; }

        [JsonProperty("contract_id")]
        public int? ContractId { get; set; }

        [JsonProperty("contract_title")]
        public string ContractTitle { get; set; }

        [JsonProperty("sample_matching")]
        public double? SampleMatching { get; set; }

        [JsonProperty("favorite")]
        public bool? IsFavorite { get; set; }

        [JsonIgnore]
        public Dictionary<string, FieldData> CustomFieldDictionary { get; private set; }

        [JsonIgnore]
        public Configurations.Configuration Configuration { get; set; }

        [JsonIgnore]
        public ScheduleInfo Schedule { get; set; }

        public override string ToString()
        {
            return $"id ={Id}, Title = {Title}, Date = {TaskDate}, Type = {WorkTypeId}, Confirmed = {ConfirmedType}";
        }

        public object Clone()
        {
            var result = this.MemberwiseClone();
            return result;
        }
    }

    public class FieldData
    {
        [JsonProperty("field_id")]
        public int FieldId;

        [JsonProperty("value")]
        public dynamic Value;
    }
}
