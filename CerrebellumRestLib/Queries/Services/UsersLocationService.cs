using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.JSON.Entities.UserLocation;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class UsersLocationService: IUsersLocationService
    {
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<UsersLocationService> _logger;

        public UsersLocationService(ICurrentUserProvider currentUser, ILogger<UsersLocationService> logger)
        {
            (_currentUser, _logger) = (currentUser, logger);
        }

        #region IUsersLocationService
        public async Task<UserLocation[]> GetUserLocations()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<UsersLocationResult>("geo4me/points");

                return result.Users;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<UserTrackPoint[]> GetUserTrack(int userId, DateTimeOffset startDateTimeOffset, DateTimeOffset endDateTimeOffset)
        {
            try
            {

                var dict = new Dictionary<string, string>
                {
                    { "dateFrom", startDateTimeOffset.ToUnixTimeSeconds().ToString() },
                    { "dateTo", endDateTimeOffset.ToUnixTimeSeconds().ToString() }
                };

                var result = await _currentUser.GetRequestHandler().GetJson<UserTrackPointsResults>($"users/{userId}/geo4me/track", dict);

                return result.Points;
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
