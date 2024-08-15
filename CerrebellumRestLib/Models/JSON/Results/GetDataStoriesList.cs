using System.Collections.Generic;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Results
{
    public class GetDataStoresList : JsonBase
    {
        [JsonProperty("saved_datastores")]
        public List<DbDatastore> SavedDatastores { get; set; }
    }
}