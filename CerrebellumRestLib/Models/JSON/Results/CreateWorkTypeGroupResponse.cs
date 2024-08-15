using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class CreateWorkTypeGroupResponse : JsonBase
    {
        [JsonProperty("group")]
        public WorkTypeGroup Group { get; set; }
    }
}