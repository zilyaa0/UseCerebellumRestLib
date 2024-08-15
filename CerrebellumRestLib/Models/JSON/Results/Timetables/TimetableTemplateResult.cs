using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CerebellumRestLib.Models.JSON.Results.Timetables
{
    public class TimetableTemplateResult : JsonBase
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("items")]
        public IEnumerable<TimetableTemplate> Templates { get; set; }
    }

    public class TimetableTemplate : TimetableTask
    {

    }
}