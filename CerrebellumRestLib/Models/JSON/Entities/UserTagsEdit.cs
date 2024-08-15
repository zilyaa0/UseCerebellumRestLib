using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class UserTagsEdit
    {
        [JsonProperty("add")]
        public List<Tag> Add { get; set; }

        [JsonProperty("remove")]
        public List<Tag> Remove { get; set; }
    }
}
