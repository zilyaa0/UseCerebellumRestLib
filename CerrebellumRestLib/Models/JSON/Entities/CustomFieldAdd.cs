using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class CustomFieldAdd : CustomFieldEdit
    {
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
