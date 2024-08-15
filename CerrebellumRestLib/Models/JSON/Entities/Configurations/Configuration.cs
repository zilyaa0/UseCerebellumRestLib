using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class Configuration:JsonBase
    {
        [JsonProperty("system")]
        public System System { get; set; }

        [JsonProperty("interface")]
        public Interface Interface { get; set; }

        [JsonProperty("permissions_and_visibility")]
        public PermissionsAndVisibility PermissionsAndVisibility { get; set; }

        [JsonProperty("desktop")]
        public DesktopTasks DesktopTasks { get; set; }

        [JsonProperty("mobileapp")]
        public MobileAppConfig MobileAppConfig { get; set; }
    }
}
