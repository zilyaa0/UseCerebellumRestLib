using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class UserInfo : JsonBase
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("fio")]
        public string Fio { get; set; }

        [JsonProperty("matrix")]
        public string Matrix { get; set; }

        [JsonProperty("uvd_department_id")]
        public int UvdDepartmentId { get; set; }

        [JsonProperty("users_site_type")]
        public int UsersSiteType { get; set; }

        [JsonProperty("satellites_view")]
        public bool SatellitesView { get; set; }

        [JsonProperty("role_id")]
        public int RoleId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("department_id")]
        public int DepartmentId { get; set; }
    }
}
