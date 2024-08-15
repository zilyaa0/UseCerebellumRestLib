namespace CerebellumRestLib.Models.JSON.Entities
{
    public class TaskUnitPoint
    {
        public double Lon { get; set; }

        public double Lat { get; set; }

        public double[] ToArray() => new[] {Lon, Lat};
    }
}
