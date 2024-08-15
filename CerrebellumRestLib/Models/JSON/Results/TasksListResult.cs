using System;
using System.Collections.Generic;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class GetTasksListResult : JsonBase
    {
        [JsonProperty("news_list")]
        public List<TaskUnit> TasksList { get; set; }

        [JsonProperty("count_news")]
        public int CountTasks { get; set; }

        [JsonIgnore]
        public int Count
        {
            get
            {
                if (TasksList == null)
                {
                    return 0;
                }

                return CountTasks;
            }
        }
    }
}