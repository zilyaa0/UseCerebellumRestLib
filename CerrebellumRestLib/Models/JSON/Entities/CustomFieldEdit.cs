using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class CustomFieldEdit: JsonBase
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }

        [JsonProperty("possible_values")]
        public string[] PossibleValues { get; set; }

        [JsonProperty("regexp")]
        public string Regexp { get; set; }

        [JsonProperty("min_length")]
        public int MinLength { get; set; }

        [JsonProperty("max_length")]
        public int MaxLength { get; set; }

        [JsonProperty("is_required")]
        public bool IsRequired { get; set; }

        [JsonProperty("default_value")]
        public string DefaultValue { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("is_for_all")]
        public bool IsForAll { get; set; }
    }
}
