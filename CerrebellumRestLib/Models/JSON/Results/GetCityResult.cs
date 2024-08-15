using System.Collections.Generic;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class GetCityResult: JsonBase
    {
        [JsonProperty("cities")]
        public List<City> Cities { get; set; }
    }
}
