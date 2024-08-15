using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class Tag:JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
