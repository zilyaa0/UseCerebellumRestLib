using System.Collections.Generic;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class StickerInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("news_type_ids")]
        public IList<int> WorkTypeIds { get; set; }
    }
}
