using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class UserRegister : JsonBase
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("paswd")]
        public string Password { get; set; }

        [JsonProperty("fio")]
        public string FIO { get; set; }

        [JsonProperty("organization_id")]
        public int OrganizationId { get; set; }

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
