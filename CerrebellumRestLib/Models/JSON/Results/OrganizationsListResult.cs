using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class OrganizationsListResult : JsonBase
    {
        [JsonProperty("departments")]
        public List<Organization> Organizations { get; set; }
    }
}
