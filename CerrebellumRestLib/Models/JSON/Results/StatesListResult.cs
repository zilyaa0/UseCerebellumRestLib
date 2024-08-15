using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class StatesListResult: JsonBase
    {
        [JsonProperty("states")]
        public List<State> States { get; set; }
    }
}
