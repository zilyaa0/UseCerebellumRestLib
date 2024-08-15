using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class Organization : OrganizationEdit
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("right_id")]
        public int RightId { get; set; }

        [JsonProperty("users_count")]
        public int? UsersCount { get; set; }
    }
    public class OrganizationInfo
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("inn")]
        public string Inn { get; set; }

        [JsonProperty("kpp")]
        public string Kpp { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("bank_kpp")]
        public string BankKpp { get; set; }

        [JsonProperty("bank_bik")]
        public string BankBik { get; set; }

        [JsonProperty("bank_account")]
        public string BankAccount { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("head_fio")]
        public string HeadFio { get; set; }

        [JsonProperty("accountant_fio")]
        public string AccountantFio { get; set; }
    }
}
