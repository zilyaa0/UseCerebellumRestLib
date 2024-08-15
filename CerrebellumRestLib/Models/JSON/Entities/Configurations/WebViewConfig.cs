using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class WebViewConfig
    {
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("urlTemplate")]
        public string Template { get; set; }

        [JsonProperty("label")]
        public LabelModule[] Label { get; set; }
    }
}