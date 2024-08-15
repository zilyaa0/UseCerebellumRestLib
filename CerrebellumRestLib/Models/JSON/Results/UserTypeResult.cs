using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    class UserTypeResult:JsonBase
    {
        [JsonProperty("items")]
        public List<UserType> UserTypes { get; set; }
    }
}
