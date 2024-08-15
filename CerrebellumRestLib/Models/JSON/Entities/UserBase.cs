using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public abstract class UserBase : JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("fio")]
        public string Fio { get; set; }

        [JsonProperty("department_id")]
        public int? DepartmentId { get; set; }

        [JsonProperty("workgroup_ids")]
        public IEnumerable<int> WorkgroupIds { get; set; }

        [JsonProperty("avatar_update_date")]
        public long? AvatarUpdateDate { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("user_info")]
        public UserInform UserInfo { get; set; }

        [JsonProperty("type")]
        public UserType UserType { get; set; }

        [JsonProperty("cluster")]
        public ClusterBase Cluster { get; set; }

        [JsonProperty("clusters")]
        public IEnumerable<ClusterBase> AvailableClusters { get; set; }

        [JsonProperty("blocked")]
        public bool Blocked { get; set; }
    }
}