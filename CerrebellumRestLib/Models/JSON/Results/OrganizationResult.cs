using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class OrganizationResult:JsonBase
    {
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
    }
}
