using System.Collections.Generic;
using Newtonsoft.Json;
using CerebellumRestLib.Models.Enums;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class AuthResult : UserBase
    {
        [JsonProperty("users_site_type")]
        public int UsersSiteType { get; set; }

        [JsonProperty("satellites_view")]
        public bool SatellitesView { get; set; }

        [JsonProperty("role_id")]
        public UserRole Role { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("matrix")]
        public string Matrix { get; set; }

        [JsonProperty("map_extent")]
        public IList<double> MapExtent { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
