using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class Sensor
    {
        [JsonProperty("port")]
        public long Port { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("analog_value")]
        public double? AnalogValue { get; set; }

        [JsonProperty("date")]
        public long? Date { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}
