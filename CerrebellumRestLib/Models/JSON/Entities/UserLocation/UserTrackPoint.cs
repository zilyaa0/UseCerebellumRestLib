using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.UserLocation
{
    public class UserTrackPoint
    {
        [JsonProperty("data")]
        public int Date { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("control")]
        public bool Control { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }
    }
}
