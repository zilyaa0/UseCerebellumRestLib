using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class System
    {
        [JsonProperty("is_landing")]
        public bool IsLanding { get; set; }

        [JsonProperty("keys")]
        public Keys Keys { get; set; }
    }
    public class Keys
    {
        [JsonProperty("yandex_maps_api_key")]
        public string YandexMapsApiKey { get; set; }
    }
}
