using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.UserLocation
{
    public class UserLocation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("point")]
        public UserPoint Point { get; set; }
    }
}
