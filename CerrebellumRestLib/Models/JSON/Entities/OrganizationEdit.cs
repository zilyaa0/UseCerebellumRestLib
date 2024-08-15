using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class OrganizationEdit : JsonBase
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("arm_view")]
        public bool ArmView { get; set; }

        [JsonProperty("map_extent_id")]
        public int? MapExtentId { get; set; }

        [JsonProperty("people_dep")]
        public bool PeopleDep { get; set; }

        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }

        [JsonProperty("workgroup_id")]
        public int? WorkgroupId { get; set; }

        [JsonProperty("cluster_id")]
        public int? ClusterId { get; set; }

        [JsonProperty("info")]
        public OrganizationInfo Info { get; set; }
    }
}