using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.UserLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class UsersLocationResult: JsonBase
    {
        [JsonProperty("users")]
        public UserLocation[] Users { get; set; }
    }
}
