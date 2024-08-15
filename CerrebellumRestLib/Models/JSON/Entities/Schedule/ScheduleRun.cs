using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ScheduleRun
    {
        [JsonProperty("time")]
        public ScheduleTime Time { get; set; }

        [JsonProperty("schedule")]
        public Schedule Schedule { get; set; }

        [JsonProperty("datetime")]
        public long Datetime { get; set; }

        [JsonProperty("taken")]
        public object Taken { get; set; }

        [JsonProperty("on")]
        public bool On { get; set; }

        [JsonProperty("stats")]
        public Stat Stats { get; set; }
    }
}