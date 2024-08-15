using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class DesktopTasks
    {
        [JsonProperty("photo_distance")]
        public int? PhotoDistance { get; set; } = 200;

        [JsonProperty("default_rastr_layer")]
        public DefaultRastrLayer DefaultRastrLayer { get; set; }

        [JsonProperty("default_visible_layers")]
        public DefaultVisibleLayers DefaultVisibleLayers { get; set; }

        [JsonProperty("default_values")]
        public DefaultValues DefaultValues { get; set; }

        [JsonProperty("use_custom_types_sort")]
        public bool UseCustomWorkTypesSort { get; set; } = false;

        [JsonProperty("auto_apply_filter")]
        public bool AutoApplyFilter { get; set; } = true;

        [JsonProperty("plugins")]
        public Plugin[] Plugins { get; set; }

        [JsonProperty("task_print")]
        public TaskPrint TaskPrint { get; set; }

        [JsonProperty("desktop_app")]
        public DesktopApp DesktopApp { get; set; }
    }

    public class DesktopApp
    {
        [JsonProperty("plugins")]
        public Plugin[] Plugins { get; set; }
    }

    public class Plugin
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("enabledPlugin")]
        public bool? EnabledPlugin { get; set; }
    }
    public class DefaultVisibleLayers
    {
        [JsonProperty("gp_layer_ids")]
        public string LayerIds { get; set; }
    }

    public class DefaultValues
    {
        [JsonProperty("type_id")]
        public int? WorkTypeId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("creator_org_id")]
        public int? CreaterOrgId { get; set; }

        [JsonProperty("priority_id")]
        public int? PriorityId { get; set; }
    }

    public class DefaultRastrLayer
    {
        [JsonProperty("tms_url")]
        public string TmsUrl { get; set; }

        [JsonProperty("map_cache_folder")]
        public string MapCacheFolder { get; set; }

        [JsonProperty("proj_external_layer")]
        public string ProjExternalLayer { get; set; }
    }
    public class TaskPrint
    {
        [JsonProperty("show_map")]
        public bool? ShowMap { get; set; }
    }
}
