using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class Beacon
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }
        
        [JsonProperty("major")]
        public int Major { get; set; }

        [JsonProperty("minor")]
        public int Minor { get; set; }

        [JsonProperty("rssi")]
        public double Rssi { get; set; }

        [JsonProperty("distance")]
        public double Distance {  get; set; }
    }
}
