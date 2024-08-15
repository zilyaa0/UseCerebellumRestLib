using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class FieldsMapping : JsonBase
    {

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("fields")]
        public string[] Fields { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("field_id")]
        public int CustomFieldId { get; set; }
    }
}
