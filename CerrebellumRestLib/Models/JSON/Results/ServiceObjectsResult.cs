using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class ServiceObjectsResult : JsonBase
    {
        [JsonProperty("service_objects")]
        public ServiceObjects ServiceObjects { get; set; }
    }
}
