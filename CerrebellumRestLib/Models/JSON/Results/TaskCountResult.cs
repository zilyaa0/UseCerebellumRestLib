using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class TaskCountResult : JsonBase
    {
        [JsonProperty("countNews")]
        public int Count { get; set; }
    }
}
