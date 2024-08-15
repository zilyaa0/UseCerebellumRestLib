using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.UserLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class UserTrackPointsResults : JsonBase
    {
        [JsonProperty("points")]
        public UserTrackPoint[] Points { get; set; }
    }
}
