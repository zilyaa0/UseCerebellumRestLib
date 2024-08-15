using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.Configurations;
using CerebellumRestLib.Models.RequestParams;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IConfigurationService
    {
        Task<Configuration> GetConfiguration();
        Task<ServiceObjects> GetServiceObjectsConfiguration();
        Task<PageableBase<ServiceObjects>> GetServiceObjectsConfigurations(MappingListRequest listRequest);
        Task<JObject> GetAllConfiguration();
        Task<JavaOptionsConfiguration> GetJavaOptionConfiguration();
    }
}
