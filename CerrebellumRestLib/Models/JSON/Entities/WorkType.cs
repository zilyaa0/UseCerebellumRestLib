using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class WorkType : WorkTypeEdit
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("order_key")]
        public int? OrderKey { get; set; }
    }
}
