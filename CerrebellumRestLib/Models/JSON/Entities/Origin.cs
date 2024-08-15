using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class Origin
    {

        [JsonProperty("time")]
        public long? OriginTime { get; set; }

        [JsonProperty("time_provider")]
        public string OriginTimeProvider { get; set; }

        [JsonProperty("location")]
        public AttachmentInfoLocation OriginLocation { get; set; }
    }
}
