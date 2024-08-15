using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.V2
{
    public class CustomFieldValue
    {
        public CustomFieldValue(int fieldId, object value)
        {
            FieldId = fieldId;
            Value = value;
        }

        [JsonProperty("field_id")]
        public int FieldId { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
