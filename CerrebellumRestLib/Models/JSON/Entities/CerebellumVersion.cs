using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class CerebellumVersion : JsonBase
    {
        [JsonProperty("build")]
        public string Build { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("commit")]
        public string Commit { get; set; }

        [JsonProperty("branch")]
        public string Branch { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("cerebellum")]
        public string Cerebellum { get; set; }
    }
}
