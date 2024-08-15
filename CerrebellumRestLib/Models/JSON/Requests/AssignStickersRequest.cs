using System.Collections.Generic;
using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Requests
{
    public class AssignedSticker
    {
        [JsonProperty("file_id")]
        public int FileId { get; set; }

        [JsonProperty("sticker_id")]
        public int StickerId { get; set; }
    }

    class AssignStickersRequest : JsonBase
    {
        [JsonProperty("files")]
        public IEnumerable<AssignedSticker> AssignedStickers { get; set; }
    }
}
