using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class ServiceObjects : JsonBase
    {

        [JsonProperty("search_params")]
        public string SearchParams { get; set; }

        [JsonProperty("search_field")]
        public string SearchField { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("layer")]
        public Layer Layer { get; set; }

        [JsonProperty("geo_json_field")]
        public string GeoJsonField { get; set; }

        [JsonProperty("title_format")]
        public string TitleFormat { get; set; }

        [JsonProperty("fields")]
        public string[] Fields { get; set; }

        [JsonProperty("title_fields")]
        public string[] TitleFields { get; set; }

        [JsonProperty("field_mappings")]
        public FieldsMapping[] FieldsMapping { get; set; }
    }
}
