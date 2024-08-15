using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON
{
    public class Author
    {
        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("platform_version")]
        public string PlatformVersion { get; set; }

        [JsonProperty("application")]
        public string Application { get; set; }

        [JsonProperty("application_version")]
        public string ApplicationVersion { get; set; }
    }
}
