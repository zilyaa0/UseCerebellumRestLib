using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Entities.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface ISystemService
    {
        Task<string> GetTitleAsync();

        Task<string> GetAppSettings();

        Task<CerebellumVersion> GetVersion();
    }
}
