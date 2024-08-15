using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public abstract class BaseLocation
    {
        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("accuracy")]
        public double? Accuracy { get; set; }

        [JsonProperty("distance_to_task")]
        public double? DistanceToTask { get; set; }
    }

    public class AttachmentInfoLocation : BaseLocation
    {
        [JsonProperty("lonlat")]
        public double[] Coordinates { get; set; }
    }
}
