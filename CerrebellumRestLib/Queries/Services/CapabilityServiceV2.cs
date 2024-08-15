using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results.V2;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using CerebellumRestLib.Queries.Static;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class CapabilityServiceV2 : ICapabilityServiceV2
    {
        #region Fields
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<CapabilityServiceV2> _logger;
        private readonly ReadOnlyDictionary<string, string> _initParams;
        #endregion

        #region Constructor
        public CapabilityServiceV2(ICurrentUserProvider currentUser,
                           ILogger<CapabilityServiceV2> logger = null)
        {
            _currentUser = currentUser;
            _logger = logger ?? StaticBindingHelper.GetLogger<CapabilityServiceV2>();
            var prms = new Dictionary<string, string>();
            prms.Add("apiVersion", "2.0");
            _initParams = new ReadOnlyDictionary<string, string>(prms);
        } 
        #endregion

        public async Task<IEnumerable<Capability>> GetCapabilities()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<CapabilitiesListResult>("tasks/capabilities", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value));
                return result.Capabilities ?? new List<Capability>();
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<IEnumerable<Allowed>> GetAllowed()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<AllowedListResult>("tasks/allowed", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value));
                return result.AllowedList ?? new List<Allowed>();
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<StatesListResult>("tasks/states", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value));
                return result.States ?? new List<State>();
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
    }
}
