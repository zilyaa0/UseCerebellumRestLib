using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class ServiceObjectResult:JsonBase
    {
        [JsonProperty("service_objects")]
        public ServiceObjectsList ServiceObjects { get; set; }
    }

    public partial class ServiceObjectsList
    {
        [JsonProperty("hits")]
        public List<ServiceObject> ServiceObjects { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}
