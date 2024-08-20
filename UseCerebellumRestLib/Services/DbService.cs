using CerebellumRestLib.Queries.Services.Abstract;
using Dapper;
using MailKit;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UseCerebellumRestLib.Models.Db;
using UseCerebellumRestLib.Models.Settings;

namespace UseCerebellumRestLib.Services
{
    #region Interface
    public interface IDbService
    {
        Task InsetTask(string letterId, long taskId);
        Task<bool> FindLetterByMessageId(string letterId);
    }
    #endregion
    internal class DbService : IDbService
    {
        #region Fields
        private readonly ILogger<FileService> _logger;

        private readonly AppSettings _appSettings;
        #endregion

        #region Constructor
        public DbService(ILogger<FileService> logger, AppSettings appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }
        #endregion

        #region Public Methods
        public async Task InsetTask(string letterId, long taskId)
        {
            try
            {
                _logger.LogInformation("Insert db task");
                using (IDbConnection db = new NpgsqlConnection(_appSettings.DbSettings.BuildConnectionString()))
                {
                    var sql = $"INSERT INTO {_appSettings.DbSettings.CreateTaskTable} (letterid, activemapid) VALUES ('{letterId}','{taskId}');";
                    await db.QueryAsync(sql);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(InsetTask)}");
                throw;
            }
        }

        public async Task<bool> FindLetterByMessageId(string letterId)
        {
            var dbTasks = await GetDbTasksAsync();
            if (dbTasks.Any(w => w.LetterId == letterId))
                return true;
            else 
                return false;
        }
        #endregion

        #region Private Metods
        public async Task<IEnumerable<DbTask>> GetDbTasksAsync()
        {
            try
            {
                _logger.LogInformation("Get db object");
                using (IDbConnection db = new NpgsqlConnection(_appSettings.DbSettings.BuildConnectionString()))
                {
                    var sql = $"SELECT letterid LetterId, activemapid ActiveMapId FROM {_appSettings.DbSettings.CreateTaskTable};";
                    return await db.QueryAsync<DbTask>(sql);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetDbTasksAsync)}");
                throw;
            }
        }
        #endregion
    }
}
