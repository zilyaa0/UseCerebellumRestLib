using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ClusterBase: JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
    public class Cluster : ClusterBase
    {
        [JsonProperty("defaults")]
        public bool Defaults { get; set; }

        [JsonProperty("creation_date")]
        public long CreationDate { get; set; }

        [JsonProperty("created_by")]
        public ClusterUser CreatedBy { get; set; }
    }
    public class ClusterUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fio")]
        public string FIO { get; set; }
    }
}
