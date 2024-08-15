using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class CommentsResult: JsonBase
    {
        [JsonProperty("comments")]
        public Comment[] Comments { get; set; }
    }
}
