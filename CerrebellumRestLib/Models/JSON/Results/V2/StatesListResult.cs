using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results.V2
{
    public class StatesListResult : JsonBase
    {
        [JsonProperty("items")]
        public List<State> States { get; set; }
    }
}
