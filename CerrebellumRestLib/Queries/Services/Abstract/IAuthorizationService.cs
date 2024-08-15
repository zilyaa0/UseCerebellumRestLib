using CerebellumRestLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IAuthorizationService
    {
        Task<User> Authorize(Uri url, string login, string password, string lang = null);
    }
}
