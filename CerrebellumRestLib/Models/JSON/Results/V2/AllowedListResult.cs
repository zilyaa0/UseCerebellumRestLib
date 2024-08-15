using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results.V2
{
    public class AllowedListResult : JsonBase
    {
        [JsonProperty("items")]
        public List<Allowed> AllowedList { get; set; }
    }
}
