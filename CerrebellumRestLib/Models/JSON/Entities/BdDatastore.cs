using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class DbDatastore
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }

        [JsonProperty("database")]
        public string Database { get; set; }

        [JsonProperty("have_infrastructure")]
        public bool HaveInfrastructure { get; set; }
    }
}
