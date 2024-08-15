using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class CustomFieldResult : JsonBase
    {
        [JsonProperty("custom_field")]
        public CustomField CustomField { get; set; }
    }
}
