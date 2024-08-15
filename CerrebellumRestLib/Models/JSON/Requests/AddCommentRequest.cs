using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Requests
{
    class AddCommentRequest : JsonBase
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}