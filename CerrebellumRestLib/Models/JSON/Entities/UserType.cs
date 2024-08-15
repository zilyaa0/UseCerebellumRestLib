using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class UserType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
