using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class MobileAppConfig
    {
        [JsonProperty("webview")]
        public WebViewConfig WebViewConfig { get; set; }
        [JsonProperty("photo_comparison")]
        public PhotoComparison PhotoComparison { get; set; }
    }

    public class PhotoComparison
    {
        [JsonProperty("allowable_percentage")]
        public double? AllowablePercentage { get; set; }

        [JsonProperty("offline_url")]
        public string OfflineUrl { get; set; }

        [JsonProperty("online_url")]
        public string OnlineUrl { get; set; }
    }
}