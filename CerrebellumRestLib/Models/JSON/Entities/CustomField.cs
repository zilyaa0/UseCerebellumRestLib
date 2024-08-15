using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.Сontracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class CustomField : CustomFieldAdd
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("translit")]
        public string Translit { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("news_type_ids")]
        public int[] NewsTypeIds { get; set; }

        [JsonProperty("possible_values")]
        public new string PossibleValues { get; set; }

        [JsonProperty("cluster")]
        public ClusterInfo Cluster { get; set; }

        [JsonProperty("allow_add_num")]
        public bool? AllowAddNum { get; set; }

        [JsonProperty("multiselect")]
        public bool? Multiselect { get; set; }

        [JsonProperty("table_id")]
        public int? TableId { get; set; }
    }

    public class DataTemplateCustomFieldResult
    {
        [JsonProperty("table_id")]
        public int? TableId { get; set; }

        [JsonProperty("values")]
        public IEnumerable<DataTemplateCustomFieldValue> Values { get; set; }
    }

    public class DataTemplateCustomFieldValue
    {
        [JsonProperty("object_id")]
        public int ObjectId { get; set; }

        [JsonProperty("num")]
        public double? Num { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
