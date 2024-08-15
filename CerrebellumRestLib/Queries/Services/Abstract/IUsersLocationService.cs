using CerebellumRestLib.Models.JSON.Entities.UserLocation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IUsersLocationService
    {
        Task<UserTrackPoint[]> GetUserTrack(int userId, DateTimeOffset startDateTimeOffset, DateTimeOffset endDateTimeOffset);
        Task<UserLocation[]> GetUserLocations();
    }
}
