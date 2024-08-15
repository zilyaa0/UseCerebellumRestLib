using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class DeletedTask : JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("issue_id")]
        public int IssueId { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}