using System.Collections.Generic;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
        public class GetDepUsersResult : JsonBase
        {
            [JsonProperty("users")]
            public List<DepUser> Users { get; set; }
        }

}
