using CerebellumRestLib.Models.JSON.Results.Timetables;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities.Timetables
{
    public class TimetablesEdit : Timetable
    {
        [JsonProperty("templates")]
        public TemplateEdit Templates { get; set; }
    }
}
