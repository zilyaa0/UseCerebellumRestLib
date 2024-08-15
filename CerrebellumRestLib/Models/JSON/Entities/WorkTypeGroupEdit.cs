using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class WorkTypeGroupEdit
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
