using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Requests
{
    class DeleteRequest : JsonBase
    {
        [JsonProperty("action")]
        public string Action => "delete";
    }
}
