using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class WorkTypeCompressed:WorkType
    {
        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("included_organizations")]
        public List<int> IncludedOrganizations { get; set; }

        [JsonProperty("excluded_organizations")]
        public List<int> ExcludedOrganizations { get; set; }
    }
}
