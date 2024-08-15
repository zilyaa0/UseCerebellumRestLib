using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Requests
{
    public class AuthRequest : JsonBase
    {
        [JsonProperty("action")]
        public string Action { get; set; } = "post";

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
