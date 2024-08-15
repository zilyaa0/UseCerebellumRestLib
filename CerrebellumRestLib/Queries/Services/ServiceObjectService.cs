using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class ServiceObjectService : IServiceObjectsService
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ILogger<ServiceObjectService> _logger;

        public ServiceObjectService(ICurrentUserProvider currentUserProvider,
                           ILogger<ServiceObjectService> logger)
        {
            _currentUserProvider = currentUserProvider;
            _logger = logger;
        }

        public async Task<string> SeachServiceObject(string searchText, double? longitude = null, double? latitude = null)
        {
            _logger.LogTrace($"SeachServiceObject: {searchText}");
            var dic = new Dictionary<string, string>();
            dic.Add("q", $"{searchText.Trim().Replace(" ", "*+")}*");
            if (longitude.HasValue && latitude.HasValue)
            {
                dic.Add("lonLat",$"{longitude.ToString().Replace(",", ".")},{latitude.ToString().Replace(",", ".")}");
            }

            var result = await _currentUserProvider.GetRequestHandler().GetString("configuration/service_objects/search", parameters: dic);
            _logger.LogTrace($"SeachServiceObject Result:{result}");
            return result;
        }
    }
}
