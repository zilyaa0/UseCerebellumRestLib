using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class CustomFieldsListResult : JsonBase
    {
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
