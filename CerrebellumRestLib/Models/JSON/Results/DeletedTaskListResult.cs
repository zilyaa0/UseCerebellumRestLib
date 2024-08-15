using System.Collections.Generic;
using Newtonsoft.Json;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class DeletedTaskListResult : JsonBase
    {
        [JsonProperty("deletions")]
        public List<DeletedTask> DeletedTasks { get; set; }
    }
}
