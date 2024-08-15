using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.Сontracts;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class ContractsService : IContractsService
    {
        #region Fields
        private ILogger<ContractsService> _logger;
        private readonly ICurrentUserProvider _currentUser;
        private readonly ReadOnlyDictionary<string, string> _initParams;
        #endregion

        #region Constructor
        public ContractsService(
            ICurrentUserProvider currentUser,
            ILogger<ContractsService> logger)
        {
            _currentUser = currentUser;
            _logger = logger;
            var prms = new Dictionary<string, string>();
            prms.Add("apiVersion", "2.0");
            _initParams = new ReadOnlyDictionary<string, string>(prms);
        }
        #endregion

        #region IContractsService
        public async Task<Contract> GetContract(long contractId)
        {
            _logger.LogDebug("GetСontracts");
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<Contract>($"contracts/{contractId}", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex);
                throw;
            }
        }

        public async Task<PageableBase<Contract>> GetСontracts(ContractListRequest listRequest)
        {
            _logger.LogDebug("GetСontracts");
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<PageableBase<Contract>>(
                    "contracts/list", 
                    parameters: _initParams.ToDictionary(k => k.Key, v => v.Value).Union(listRequest.GetUrlParams()).ToDictionary(k=>k.Key, v=>v.Value));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex);
                throw;
            }
        }
        #endregion
    }
}
