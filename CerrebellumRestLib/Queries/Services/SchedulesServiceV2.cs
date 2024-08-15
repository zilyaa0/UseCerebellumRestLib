using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class SchedulesServiceV2 : ISchedulesServiceV2
    {
        #region Fields
        private readonly ILogger<SchedulesServiceV2> _logger;
        private readonly ICurrentUserProvider _currentUser;
        private readonly ReadOnlyDictionary<string, string> _initParams;
        #endregion

        #region Constructor
        public SchedulesServiceV2(ILogger<SchedulesServiceV2> logger,
                                  ICurrentUserProvider currentUser)
        {
            _logger = logger;
            _currentUser = currentUser;
            var prms = new Dictionary<string, string>();
            prms.Add("apiVersion", "2.0");
            _initParams = new ReadOnlyDictionary<string, string>(prms);
        }
        #endregion

        #region ISchedulesServiceV2
        public async Task<IEnumerable<ScheduleRun>> GetScheduleRuns(ScheduleRunRequest scheduleRunRequest)
        {
            try
            {
                _logger.LogDebug("Get schedule runs");
                var result = await _currentUser.GetRequestHandler().GetJson<ScheduleRunResult>("schedules/runs", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value).Union(scheduleRunRequest.GetUrlParams()).ToDictionary(w => w.Key, w => w.Value));
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
                return await _currentUser.GetRequestHandler().GetJson<ScheduleStat>("schedules/stats", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value).Union(scheduleStatRequest.GetUrlParams()).ToDictionary(w => w.Key, w => w.Value));
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
                var result = await _currentUser.GetRequestHandler().GetJson<ScheduleTaskResult>("schedules/tasks", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value).Union(scheduleTaskRequest.GetUrlParams()).ToDictionary(w => w.Key, w => w.Value));
                return result.ScheduleTasks;
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
                var result = await _currentUser.GetRequestHandler().PatchJson<ScheduleAddedResult>($"schedules/{scheduleId}", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value), body: scheduleEdit.ToJson(true));
                return result.Schedule;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task RestartSchedule(int scheduleId, DateTime time)
        {
            try
            {
                _logger.LogDebug($"Restaer schedule: {scheduleId}");
                await _currentUser.GetRequestHandler().PostJson<ScheduleAddedResult>(
                    $"schedules/{scheduleId}/restart/{time:yyyy}/{time:MM}/{time:dd}/{time:HH}/{time:mm}", 
                    parameters: _initParams.ToDictionary(k => k.Key, v => v.Value),
                    body: "{}");
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
