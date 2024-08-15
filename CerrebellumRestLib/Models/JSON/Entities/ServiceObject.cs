using CerebellumRestLib.Models.Base;

namespace CerebellumRestLib.Models.JSON.Entities
{
    public class ServiceObject
    {
        public string Name { get; set; }

        public long Id { get; set; }

        public override string ToString()
        {
            return Name ?? string.Empty;
        }
    }
}
