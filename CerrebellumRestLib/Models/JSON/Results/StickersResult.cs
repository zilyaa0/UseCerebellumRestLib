using System.Collections.Generic;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    class StickersResult : JsonBase
    {
        [JsonProperty("stickers")]
        public List<StickerInfo> Stickers { get; set; } = new List<StickerInfo>();
    }
}
