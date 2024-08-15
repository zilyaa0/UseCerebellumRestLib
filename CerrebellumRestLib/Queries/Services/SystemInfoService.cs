using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Entities.Configurations;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using CerebellumRestLib.Queries.Static;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class SystemInfoService : ISystemService
    {
        #region Fields
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<SystemInfoService> _logger;
        #endregion

        #region Constructor
        public SystemInfoService(ICurrentUserProvider currentUser,
                   ILogger<SystemInfoService> logger = null)
        {
            _currentUser = currentUser;
            _logger = logger ?? StaticBindingHelper.GetLogger<SystemInfoService>();
        }
        #endregion

        #region ISystemService
        public async Task<string> GetAppSettings()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetString($"files/config/mapmessages", restApi:false);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e, nameof(GetAppSettings));
                throw;
            }
        }

        public async Task<string> GetTitleAsync()
        {
            try
            {
                var result =  await _currentUser.GetRequestHandler().GetString($"", restApi: false);

                var match = Regex.Match(result, "<title(.*?)>(.*?)</title>");
                return Regex.Replace(match.Value, "<[^>]+>", String.Empty);
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex, nameof(GetTitleAsync));
                return String.Empty;
            }
        }

        public async Task<CerebellumVersion> GetVersion()
        {
            {
                try
                {
                    var result = await _currentUser.GetRequestHandler().GetJson<CerebellumVersion>($"version");
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogMethodError(ex, nameof(GetVersion));
                    throw;
                }
            }
        }
        #endregion
    }
}
