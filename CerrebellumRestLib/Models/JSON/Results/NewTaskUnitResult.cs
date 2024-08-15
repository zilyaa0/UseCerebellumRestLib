using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class CreateTaskUnitResult : JsonBase
    {
        [JsonProperty("newsId")]
        public int TaskId { get; set; }
    }
}
