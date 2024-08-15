using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class WorkTypeGroupsListResult : JsonBase
    {
        [JsonProperty("groups")]
        public List<WorkTypeGroup> Groups { get; set; }
    }
}
