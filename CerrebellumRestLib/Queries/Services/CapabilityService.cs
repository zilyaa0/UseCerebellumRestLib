using System;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using CerebellumRestLib.Helpers;
using CerebellumRestLib.Queries.Static;
using CerebellumRestLib.Queries.Services.Abstract;
using CerebellumRestLib.Queries.Providers.Abstract;

namespace CerebellumRestLib.Queries.Services
{
    public class CapabilityService: ICapabilityService
    {
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<CapabilityService> _logger;

        public CapabilityService(ICurrentUserProvider currentUser,
                                 ILogger<CapabilityService> logger = null)
        {
            _currentUser = currentUser;
            _logger = logger ?? StaticBindingHelper.GetLogger<CapabilityService>();
        }

        public async Task<IEnumerable<Capability>> GetCapabilities()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<CapabilitiesListResult>("news/capabilities");
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
                var result = await _currentUser.GetRequestHandler().GetJson<AllowedListResult>("news/allowed");
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
                var result = await _currentUser.GetRequestHandler().GetJson<StatesListResult>("news/states");
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