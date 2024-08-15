using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class AttachmentInfo
    {
        [JsonProperty("time")]
        public long? AttachmentTime { get; set; }

        [JsonProperty("time_provider")]
        public string AttachmentTimeProvider { get; set; }

        [JsonProperty("location")]
        public AttachmentInfoLocation AttachmentLocation { get; set; }
    }
}
