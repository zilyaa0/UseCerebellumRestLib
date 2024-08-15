using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;

namespace CerebellumRestLib.Queries.Services
{
    public class UsersService : IUsersService
    {
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<UsersService> _logger;

        public UsersService(ICurrentUserProvider currentUser,
                            ILogger<UsersService> logger)
        {
            _currentUser = currentUser;
            _logger = logger;
        }
        
        public async Task RemoveUser(int userId)
        {
            try
            {
                await _currentUser.GetRequestHandler().Delete($"users/{userId}");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<int> GetUserCount()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<CountResult>("users/count");
                return result.Count;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<CurrentUserInfo> GetCurrentUser()
        {
            _logger.LogDebug("GetCurrentUser");
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<CurrentUserInfo>($"users/current");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<List<DepUser>> GetDepUsers()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<GetDepUsersResult>($"users");
                return result.Users;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<List<DepUser>> GetDepUsers(int? departmentId)
        {
            if (!departmentId.HasValue)
                return await GetDepUsers();

            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<GetDepUsersResult>($"departments/{departmentId}/users");
                return result.Users;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<UserInfo> UserRegister(UserRegister userRegister)
        {
            try
            {
                if (userRegister == null)
                    throw new ArgumentNullException(nameof(userRegister));

                var result = await _currentUser.GetRequestHandler().PostJson<UserInfo>($"users/register", body: userRegister.ToJson(true));
                return result;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<UserInfo> AddUser(UserEdit user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user));

                var result = await _currentUser.GetRequestHandler().PostJson<UserResult>($"users", body: user.ToJson(true));
                return result.User;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<DepUser> EditUser(int id, UserEdit user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user));

                var result = await _currentUser.GetRequestHandler().PatchJson<DepUser>($"users/{id}", body: user.ToJson(true));
                return result;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<StandartDatastore> GetStandartDatastore()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<GetUserStandartDatastoreResult>("users/standartStore");
                return result.Store;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<List<DbDatastore>> GetStoresList()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<GetDataStoresList>("datastores/saved");
                return result.SavedDatastores;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<List<City>> GetCities()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<GetCityResult>($"city");
                return result.Cities;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<System.IO.Stream> GetUserAvatar(int id)
        {
            try
            {
                return await _currentUser.GetRequestHandler().DownloadFile($"users/{id}/avatar");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<System.IO.Stream> GetUserAvatarCrop(int id, int width, int height)
        {
            try
            {
                return await _currentUser.GetRequestHandler().DownloadFile($"users/{id}/avatar/crop/w{width}/h{height}");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<List<Sensor>> GetSensorsValues()
        {
            try
            {
                var sensorsResult = await _currentUser.GetRequestHandler().GetJson<SensorsResult>($"users/gauges/values");
                return sensorsResult.Sensors;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<List<Sensor>> GetSensorsHistory(int userId, DateTimeOffset from, DateTimeOffset till)
        {
            try
            {
                var dict = new Dictionary<string, string>
                {
                    { "from", from.ToUnixTimeSeconds().ToString() },
                    { "till", till.ToUnixTimeSeconds().ToString() }
                };

                var sensorsResult = await _currentUser.GetRequestHandler().GetJson<SensorsResult>($"users/{userId}/gauges/history", dict);
                return sensorsResult.Sensors;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<List<Tag>> GetTagsList(int page = 1, int limit = 25)
        {
            try
            {
                var dict = new Dictionary<string, string>
                {
                    { "page", page.ToString() },
                    { "limit", limit.ToString() }
                };

                var tagsResult = await _currentUser.GetRequestHandler().GetJson<TagsResult>($"users/tags/list", dict);
                return tagsResult.Tags;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<Tag> GetTag(int tagId)
        {
            try
            {
                return await _currentUser.GetRequestHandler().GetJson<Tag>($"users/tags/{tagId}");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task DeleteAvatar(int userId)
        {
            try
            {
                await _currentUser.GetRequestHandler().Delete($"users/{userId}/avatar");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<List<UserType>> GetUserTypes(int page = 1, int limit = 25)
        {
            try
            {
                var dict = new Dictionary<string, string>
                {
                    { "page", page.ToString() },
                    { "limit", limit.ToString() }
                };
                var result = await _currentUser.GetRequestHandler().GetJson<UserTypeResult>($"users/types/list", dict);
                return result.UserTypes;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
    }
}