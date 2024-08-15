using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class GetUserStandartDatastoreResult : JsonBase
    {
        [JsonProperty("store")]
        public StandartDatastore Store { get; set; }
    }
}
