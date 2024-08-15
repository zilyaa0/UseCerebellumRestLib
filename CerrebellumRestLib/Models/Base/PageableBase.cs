using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.Base
{
    public class PageableBase<T>: JsonBase
    {
        [JsonProperty("items")]
        public IEnumerable<T> Items { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }
    }
}
