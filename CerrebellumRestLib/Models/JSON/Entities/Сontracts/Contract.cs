using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.Сontracts
{
    public class Contract : JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("creation_date")]
        public long CreationDate { get; set; }

        [JsonProperty("start_date")]
        public long? StartDate { get; set; }

        [JsonProperty("finish_date")]
        public long? FinishDate { get; set; }

        [JsonProperty("grant_task_creation")]
        public bool GrantTaskCreation { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("cluster")]
        public ClusterInfo Cluster { get; set; }

        [JsonProperty("assigned_organization")]
        public ContractOrganizationInfo AssignedOrganization { get; set; }

        [JsonProperty("customer")]
        public ContractCustomer Customer { get; set; }

        [JsonProperty("groups")]
        public IEnumerable<Group> Groups { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title}";
        }
    }
    public class ClusterInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
    public class ContractOrganizationInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class ContractCustomer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Group
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("types")]
        public IEnumerable<TypeInfo> Types { get; set; }

        [JsonProperty("objects")]
        public IEnumerable<ObjectInfo> Objects { get; set; }
    }
    public class TypeInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
    public class ObjectInfo
    {
        [JsonProperty("object_id")]
        public long ObjectId { get; set; }

        [JsonProperty("layer_id")]
        public int LayerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
