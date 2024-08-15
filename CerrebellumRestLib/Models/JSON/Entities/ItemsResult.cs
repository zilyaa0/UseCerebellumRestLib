using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.V2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ItemsResult<T> : JsonBase
    {

        [JsonProperty("items")]
        public IEnumerable<T> Items { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
    public class TasksItemsResult: ItemsResult<TaskEntity>
    {
        [JsonProperty("schedules")]
        public IEnumerable<ScheduleInfo> Schedules { get; set; }
    }
}
