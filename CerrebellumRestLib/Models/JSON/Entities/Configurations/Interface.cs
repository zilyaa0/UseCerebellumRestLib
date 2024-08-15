using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class Interface
    {
        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }

    public class Fields
    {
        [JsonProperty("rating")]
        public Rating Rating { get; set; }
    }

    public class Rating
    {
        [JsonProperty("emotional")]
        public bool? Emotional { get; set; } = true;

        [JsonProperty("scale")]
        public int? Scale { get; set; } = 4;

        [JsonProperty("visible")]
        public bool? Visible { get; set; } = false;
    }
}
