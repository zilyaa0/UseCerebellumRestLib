using System.Diagnostics;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    [DebuggerDisplay("id={Id}, name={Name}")]
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("matrix")]
        public string Matrix { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("for_main_page")]
        public bool IsForMainPage { get; set; }
    }
}
