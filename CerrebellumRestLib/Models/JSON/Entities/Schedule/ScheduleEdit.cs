using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ScheduleEdit : ScheduleBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("times")]
        public IEnumerable<ScheduleTime> Times { get; set; }

        [JsonProperty("templates")]
        public TemplateEdit Templates { get; set; }

        [JsonProperty("dates")]
        public Dates Dates { get; set; }
    }

    public class Dates
    {
        [JsonProperty("add")]
        public IEnumerable<long> Add { get; set; }

        [JsonProperty("remove")]
        public IEnumerable<long> Remove { get; set; }
    }

    public class TemplateEdit
    {
        [JsonProperty("add")]
        public IEnumerable<TemplateId> Add { get; set; }

        [JsonProperty("remove")]
        public IEnumerable<TemplateId> Remove { get; set; }
    }
    public class TemplateId
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
