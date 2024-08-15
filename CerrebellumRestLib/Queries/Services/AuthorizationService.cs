using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Requests;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CerebellumRestLib.Queries.Services
{
    public class AuthorizationService: IAuthorizationService
    {
        private readonly ILogger<AuthorizationService> _logger;
        private readonly HttpClient _httpClient;

        public AuthorizationService(
            ILogger<AuthorizationService> logger, 
            HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<User> Authorize(Uri url, string login, string password, string lang = null)
        {
            try
            {
                var parametersString = new StringContent((new AuthRequest
                {
                    Login = login,
                    Password = password
                }).ToJson(), Encoding.UTF8, "application/json");

                _httpClient.SetUserAgent();

                var response = await _httpClient.PostAsync($@"{url}rest/authentication?apiVersion=1.3{(!string.IsNullOrWhiteSpace(lang)?"&lang="+lang:"")}", parametersString);
                await response.EnsureSuccessStatusCodeWithResponce();

                var result = await response.Content.ReadAsStringAsync();
                var authResult = JsonConvert.DeserializeObject<AuthResult>(result);

                var user = new User()
                {
                    Id = authResult.Id,
                    DepartamentId = authResult.DepartmentId,
                    FullName = authResult.Fio,
                    MapExtent = authResult.MapExtent.ToArray(),
                    Role = authResult.Role,
                    Token = authResult.Token,
                    Username = authResult.Login,
                    WorkgroupIds = authResult.WorkgroupIds,
                    AvatarUpdateDate = authResult.AvatarUpdateDate,
                    Tags = authResult.Tags,
                    UserInfo = authResult.UserInfo,
                    UserType = authResult.UserType,
                    Cluster = authResult.Cluster,
                    AvailableClusters = authResult.AvailableClusters
                };

                user.LastAuthDateTime = DateTime.Now;
                user.Password = password;
                user.Uri = url;
                user.Username = login;

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex);
                throw;
            }
        }
    }
}
