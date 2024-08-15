using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.RequestParams;
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
    public class ClustersService: IClustersService
    {
        #region Fields
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<ClustersService> _logger;
        private readonly ReadOnlyDictionary<string, string> _initParams;
        #endregion

        #region Constructor
        public ClustersService(ICurrentUserProvider currentUser,
                    ILogger<ClustersService> logger)
        {
            _currentUser = currentUser;
            _logger = logger;
            var prms = new Dictionary<string, string>();
            prms.Add("apiVersion", "2.0");
            _initParams = new ReadOnlyDictionary<string, string>(prms);
        }
        #endregion

        #region IClustersService
        public async Task<IEnumerable<Cluster>> GetClusters(ClusterListRequest listRequest)
        {
            _logger.LogTrace("GetClusters");
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<PageableBase<Cluster>>(
                    $"clusters/list",
                    parameters: _initParams.ToDictionary(k => k.Key, v => v.Value).Union(listRequest.GetUrlParams()).ToDictionary(k => k.Key, v => v.Value));
                return result.Items;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        #endregion
    }
}
