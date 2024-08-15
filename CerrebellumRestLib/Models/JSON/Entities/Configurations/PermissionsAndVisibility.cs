using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Models.JSON.Entities.Configurations
{
    public class PermissionsAndVisibility
    {
        [JsonProperty("allow_assign_tasks_to_client_organizations")]
        public AllowAssignTasksToClientOrganizations AllowAssignTasksToClientOrganizations { get; set; }
    }
    public class AllowAssignTasksToClientOrganizations
    {
        [JsonProperty("on")]
        public bool On { get; set; }
    }
}
