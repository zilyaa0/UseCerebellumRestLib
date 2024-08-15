using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class TaskUnitResult : JsonBase
    {
        [JsonProperty("news_data")]
        public TaskUnit TaskUnit { get; set; }
        [JsonProperty("configuration")]
        public CerebellumRestLib.Models.JSON.Entities.Configurations.Configuration Configuration { get; set; }
    }
}
