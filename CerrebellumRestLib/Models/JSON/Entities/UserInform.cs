using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class UserInform
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("passport")]
        public string Passport { get; set; }
    }
}
