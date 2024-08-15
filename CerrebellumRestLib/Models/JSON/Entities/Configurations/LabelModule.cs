using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class LabelModule
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
