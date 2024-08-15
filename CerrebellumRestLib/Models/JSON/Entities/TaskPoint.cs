using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class TaskPoint
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("assigned_status")]
        public int AssignedStatus { get; set; }

        [JsonProperty("lon")]
        public double? Lon { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("fields")]
        public object CustomFields { get; set; }

        public double[] ToArray()
            => Lon.HasValue && Lat.HasValue
                ? new[] { Lon.Value, Lat.Value }
                : null;
    }
}
