using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class GetDepartmentNameResult : JsonBase
    {
        [JsonProperty("department_name")]
        public string  DepartmentName { get; set; }
        
    }
}
