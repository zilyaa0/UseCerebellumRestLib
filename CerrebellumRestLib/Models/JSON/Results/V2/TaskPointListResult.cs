using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Results.V2
{
    public class TaskPointListResult : JsonBase
    {
        [JsonProperty("items")]
        public IEnumerable<TaskPoint> Tasks { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
