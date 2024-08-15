using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.Configurations;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Models.RequestParams;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class ConfigurationService: IConfigurationService
    {
        #region Fields
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<ConfigurationService> _logger;
        private readonly ReadOnlyDictionary<string, string> _initParams;
        #endregion

        #region Constructors
        public ConfigurationService(ICurrentUserProvider currentUser,
                   ILogger<ConfigurationService> logger)
        {
            _currentUser = currentUser;
            _logger = logger;
            var prms = new Dictionary<string, string>();
            prms.Add("apiVersion", "2.0");
            _initParams = new ReadOnlyDictionary<string, string>(prms);
        }
        #endregion

        #region IConfigurationService
        public async Task<Configuration> GetConfiguration()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<GetConfigurationResult>($"configuration/flexible");
                return result.Configuration;
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex, nameof(GetConfiguration));
                throw;
            }
        }
        public async Task<ServiceObjects> GetServiceObjectsConfiguration()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<ServiceObjectsResult>($"configuration");
                return result.ServiceObjects;
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex, nameof(GetServiceObjectsConfiguration));
                throw;
            }
        }
        public async Task<PageableBase<ServiceObjects>> GetServiceObjectsConfigurations(MappingListRequest listRequest)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<PageableBase<ServiceObjects>>(
                    $"service-objects/mappings/list",
                    parameters: _initParams.ToDictionary(k => k.Key, v => v.Value).Union(listRequest.GetUrlParams()).ToDictionary(k => k.Key, v => v.Value));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex, nameof(GetServiceObjectsConfigurations));
                throw;
            }
        }
        public async Task<JObject> GetAllConfiguration()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetString($"configuration/flexible");
                return JObject.Parse(result);
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex, nameof(GetAllConfiguration));
                throw;
            }
        }
        public async Task<JavaOptionsConfiguration> GetJavaOptionConfiguration()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<JavaOptionsConfigurationResult>($"configuration/java-options");
                return result.Configuration;
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex, nameof(GetJavaOptionConfiguration));
                throw;
            }
        }
        #endregion
    }
}
