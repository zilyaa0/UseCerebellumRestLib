using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.UserLocation
{
    public class UserPoint
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("date")]
        public long? Date { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }
    }
}
