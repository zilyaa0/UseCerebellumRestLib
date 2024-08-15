using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class WorkTypeResult : JsonBase
    {
        [JsonProperty("newstype")]
        public WorkType WorkType { get; set; }
    }
}