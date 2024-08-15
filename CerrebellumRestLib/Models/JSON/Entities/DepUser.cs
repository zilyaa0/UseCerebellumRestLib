using Newtonsoft.Json;
using System.Data;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class DepUser: UserBase
    {
        [JsonProperty("role_id")]
        public int RoleId { get; set; }

        [JsonProperty("task_count")]
        public int TaskCount { get; set; }

        [JsonProperty("tracking")]
        public bool Tracking { get; set; }
    }
    public class CurrentUserInfo: DepUser
    {
        [JsonProperty("default_assigned_organization_id")]
        public int? DefaultAssignedOrganizationId { get; set; }
    }
}
