using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class TasksPointResult : JsonBase
    {
        [JsonProperty("news_list")]
        public IEnumerable<TaskPoint> TasksPoint { get; set; }
    }
}
