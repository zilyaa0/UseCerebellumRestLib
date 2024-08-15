using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class State : JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set;}

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("sign")]
        public string Sign { get; set; }

        [JsonProperty("field_from_session")]
        public string FieldFromSession { get; set; }
}
}
