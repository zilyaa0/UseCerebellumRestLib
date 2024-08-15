using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    internal class JavaOptionsConfigurationResult : JsonBase
    {
        [JsonProperty("configuration")]
        public JavaOptionsConfiguration Configuration { get; set; }
    }

    public class JavaOptionsConfiguration
    {
        [JsonProperty("onlyMyOrganization")]
        public bool? OnlyMyOrganization { get; set; }

        [JsonProperty("-Dfiles.localStorage")]
        public string DfilesLocalStorage { get; set; }

        [JsonProperty("filesLocalStorage")]
        public string FilesLocalStorage { get; set; }

        [JsonProperty("useCustomWorkTypesSort")]
        public bool? UseCustomWorkTypesSort { get; set; }

        [JsonProperty("taskSeparateNumeration")]
        public bool TaskSeparateNumeration { get; set; }

        [JsonProperty("gisEditorDefaultAccess")]
        public bool? GisEditorDefaultAccess { get; set; }

        [JsonProperty("issueZoneTrackingOn")]
        public bool? IssueZoneTrackingOn { get; set; }
    }

}
