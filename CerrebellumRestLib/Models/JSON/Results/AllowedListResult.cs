using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class AllowedListResult : JsonBase
    {
        [JsonProperty("allowed")]
        public List<Allowed> AllowedList { get; set; }
    }
}
