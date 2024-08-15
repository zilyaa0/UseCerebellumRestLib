using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class ErrorsResult
    {
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
