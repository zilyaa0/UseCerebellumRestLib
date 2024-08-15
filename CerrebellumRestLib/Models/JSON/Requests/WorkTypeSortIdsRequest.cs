using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Requests
{
    public class WorkTypeSortIdsRequest: JsonBase
    {
        [JsonProperty("ids")]
        public IEnumerable<int> Ids { get; set; }
    }
}
