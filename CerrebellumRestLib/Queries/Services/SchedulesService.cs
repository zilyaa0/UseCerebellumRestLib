using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class SchedulesService : ISchedulesService
    {
        #region Fields
        private readonly ILogger<SchedulesService> _logger;
        private readonly ICurrentUserProvider _currentUser;
        #endregion

        #region Constructor
        public SchedulesService(ILogger<SchedulesService> logger,
                                ICurrentUserProvider currentUser)
        {
            _logger = logger;
            _currentUser = currentUser;
        }
        #endregion

        #region ISchedulesService
        public async Task<ScheduleAdded> AddNewSchedule(ScheduleCreate scheduleCreate)
        {
            try
            {
                _logger.LogDebug("Add new schedule");
                var result = await _currentUser.GetRequestHandler().PostJson<ScheduleAddedResult>("schedules",body:scheduleCreate.ToJson());
                return result.Schedule;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task DeleteSchedule(int scheduleId)
        {
            try
            {
                _logger.LogDebug($"Delete schedule: {scheduleId}");

                await _currentUser.GetRequestHandler().Delete($"schedules/{scheduleId}"); 
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<CountableList<Schedule>> GetArchiveSchedules(ScheduleListRequest scheduleListRequest)
        {
            try
            {
                _logger.LogDebug("Get archive schedules");
                var result = await _currentUser.GetRequestHandler().GetJson<SchedulesResult>("schedules/list/archive", scheduleListRequest.GetUrlParams());
                return new CountableList<Schedule>(result.Schedules, result.Total);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<Schedule> GetSchedule(int scheduleId)
        {
            try
            {
                _logger.LogDebug($"Get schedule: {scheduleId}");
                return await _currentUser.GetRequestHandler().GetJson<Schedule>($"schedules/{scheduleId}");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<ScheduleDates> GetScheduleDates(int scheduleId, DateTimeOffset from, DateTimeOffset till, int page = 1, int limit = 1000000)
        {
            try
            {
                _logger.LogDebug($"Get schedule dates: {scheduleId}");
                var dict = new Dictionary<string, string>
                {
                    { "from", from.ToUnixTimeSeconds().ToString() },
                    { "till", till.ToUnixTimeSeconds().ToString() },
                    { "page", page.ToString() },
                    { "limit", limit.ToString() }
                };
                return await _currentUser.GetRequestHandler().GetJson<ScheduleDates>($"schedules/{scheduleId}/dates", dict);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<CountableList<Schedule>> GetSchedules(ScheduleListRequest scheduleListRequest)
        {
            try
            {
                _logger.LogDebug("Get schedule stats");
                var result = await _currentUser.GetRequestHandler().GetJson<SchedulesResult>("schedules/list", parameters: scheduleListRequest.GetUrlParams());
                return new CountableList<Schedule>(result.Schedules, result.Total);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<IEnumerable<ScheduleRun>> GetScheduleRuns(ScheduleRunRequest scheduleRunRequest)
        {
            try
            {
                _logger.LogDebug("Get schedule runs");
                var result = await _currentUser.GetRequestHandler().GetJson<ScheduleRunResult>("schedules/runs", parameters: scheduleRunRequest.GetUrlParams());
                return result.ScheduleRuns;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<ScheduleStat> GetSchedulesStat(ScheduleStatRequest scheduleStatRequest)
        {
            try
            {
                _logger.LogDebug("Get schedules stat");
                return await _currentUser.GetRequestHandler().GetJson<ScheduleStat>("schedules/stats", parameters: scheduleStatRequest.GetUrlParams());
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<IEnumerable<ScheduleTasks>> GetScheduleTasks(ScheduleTaskRequest scheduleTaskRequest)
        {
            try
            {
                _logger.LogDebug("Get schedule tasks");
                var result = await _currentUser.GetRequestHandler().GetJson<ScheduleTaskResult>("schedules/tasks", parameters: scheduleTaskRequest.GetUrlParams());
                return result.ScheduleTasks;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<ScheduleTemplateResult> GetScheduleTemplates(int scheduleId, ScheduleTemplatesRequest scheduleTemplatesRequest)
        {
            try
            {
                _logger.LogDebug("Get schedule templates");
                var result = await _currentUser.GetRequestHandler().GetJson<ScheduleTemplateResult>($"schedules/{scheduleId}/templates", scheduleTemplatesRequest.GetUrlParams());
                return result;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<ScheduleAdded> UpdateSchedule(int scheduleId, ScheduleEdit scheduleEdit)
        {
            try
            {
                _logger.LogDebug($"Update schedule: {scheduleId}");
                var result = await _currentUser.GetRequestHandler().PatchJson<ScheduleAddedResult>($"schedules/{scheduleId}", body: scheduleEdit.ToJson(true));
                return result.Schedule;
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