using System.Diagnostics;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    [DebuggerDisplay("host={Host}:{Port} | db={Database}")]
    public class StandartDatastore
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }

        [JsonProperty("database")]
        public string Database { get; set; }

        [JsonProperty("scheme")]
        public string Scheme { get; set; }
    }
}