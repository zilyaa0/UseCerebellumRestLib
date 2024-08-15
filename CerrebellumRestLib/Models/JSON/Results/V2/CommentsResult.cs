using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Results.V2
{
    public class CommentsResult : JsonBase
    {
        [JsonProperty("items")]
        public Comment[] Comments { get; set; }
    }
}
