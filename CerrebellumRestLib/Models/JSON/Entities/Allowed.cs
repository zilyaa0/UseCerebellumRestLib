using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class Allowed : JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("capability_id")]
        public int CapabilityId { get; set; }

        [JsonProperty("states")]
        public int[] States { get; set; }
    }
}
