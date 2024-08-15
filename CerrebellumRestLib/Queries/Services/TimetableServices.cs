using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.Timetables;
using CerebellumRestLib.Models.JSON.Results.Timetables;
using CerebellumRestLib.Models.RequestParams;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class TimetableServices : ITimetableServices
    {
        #region Fields
        private readonly ILogger<TimetableServices> _logger;
        private readonly ICurrentUserProvider _currentUserProvider;
        #endregion

        #region Constructor
        public TimetableServices(ILogger<TimetableServices> logger, ICurrentUserProvider currentUserProvider)
        {
            _logger = logger;
            _currentUserProvider = currentUserProvider;
        }
        #endregion

        #region ITimetableServices
        public async Task<CountableList<Timetable>> GetTimeTables(TimetablesListRequest timetablesListRequest)
        {
            try
            {
                _logger.LogDebug("Get timetables");
                var result = await _currentUserProvider.GetRequestHandler().GetJson<TimetableListResult>("timetables/list", parameters: timetablesListRequest.GetUrlParams());
                return new CountableList<Timetable>(result.Items, result.Total);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetTimeTables)}");
                throw;
            }
        }

        public async Task<Timetable> GetTimeTable(int timetableId)
        {
            try
            {
                _logger.LogDebug($"Get timetable {timetableId}");
                return await _currentUserProvider.GetRequestHandler().GetJson<Timetable>($"timetables/{timetableId}");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetTimeTable)}");
                throw;
            }
        }

        public async Task<Timetable> AddNewTimeTable(TimetablesCreate timetablesCreate)
        {
            try
            {
                _logger.LogDebug("Add new timetable");
                var result = await _currentUserProvider.GetRequestHandler().PostJson<Timetable>("timetables", body: timetablesCreate.ToJson());
                return result;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddNewTimeTable)}");
                throw;
            }
        }

        public async Task<Timetable> EditTimeTable(int id, TimetablesEdit timetablesEdit)
        {
            try
            {
                _logger.LogDebug($"Edit timetable: {id}");
                var result = await _currentUserProvider.GetRequestHandler().PatchJson<Timetable>($"timetables/{id}", body: timetablesEdit.ToJson(true));
                return result;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EditTimeTable)}");
                throw;
            }
        }

        public async Task<TimetablePreview> GetEditPreviewTimetable(int id, DateTime date, TimetablesEdit timetablesEdit)
        {
            try
            {
                _logger.LogDebug($"Get preview timetable runs: {id}");
                return await _currentUserProvider.GetRequestHandler().PostJson<TimetablePreview>($"timetables/{id}/preview/{date:yyyy-MM}", body: timetablesEdit.ToJson());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetEditPreviewTimetable)}");
                throw;
            }
        }

        public async Task<TimetablePreview> GetCreatePreviewTimetable(DateTime date, TimetablesCreate timetablesCreate)
        {
            try
            {
                _logger.LogDebug("Get create preview timetable runs");
                return await _currentUserProvider.GetRequestHandler().PostJson<TimetablePreview>($"timetables/preview/{date:yyyy-MM}", body: timetablesCreate.ToJson());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetCreatePreviewTimetable)}");
                throw;
            }
        }

        public async Task<TimetableTemplateResult> GetTimetableTemplates(int timetableId, TimetableTemplatesRequest timetableTemplatesRequest)
        {
            try
            {
                _logger.LogDebug($"Get timetable templates: {timetableId}");
                var result = await _currentUserProvider.GetRequestHandler().GetJson<TimetableTemplateResult>($"timetables/{timetableId}/templates", parameters: timetableTemplatesRequest.GetUrlParams());
                return result;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetTimetableTemplates)}");
                throw;
            }
        }

        public async Task DeleteTimetable(int timetableId)
        {
            try
            {
                _logger.LogDebug($"Delete timetable: {timetableId}");
                await _currentUserProvider.GetRequestHandler().Delete($"timetables/{timetableId}");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteTimetable)}");
                throw;
            }
        }

        public async Task<IEnumerable<TimetableTaskInfo>> GetTimetableTasks(int scheduleId, DateTime date, TimetableTaskRequest timetableTaskRequest)
        {
            try
            {
                _logger.LogDebug("Get timetable tasks");
                var result = await _currentUserProvider.GetRequestHandler().GetJson<TimetableTasksResult>($"timetables/{scheduleId}/tasks/{date:yyyy-MM-dd}", parameters: timetableTaskRequest.GetUrlParams());
                return result.Items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetTimetableTasks)}");
                throw;
            }
        }

        public async Task RestartTimetable(int timetableId, DateTime time)
        {
            try
            {
                _logger.LogDebug($"Restart timetable: {timetableId}");
                await _currentUserProvider.GetRequestHandler().PostJson($"timetables/{timetableId}/restart/{time:yyyy-MM-dd}/@/{time:HH-mm}", body: "{}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(RestartTimetable)}");
                throw;
            }
        }

        public async Task<TimetableStatResult> GetTimetablesStat(DateTime date, TimetablesStatsRequest timetablesStatsRequest)
        {
            try
            {
                _logger.LogDebug("Get timetables stat");
                return await _currentUserProvider.GetRequestHandler().GetJson<TimetableStatResult>($"timetables/stats/{date:yyyy-MM}", parameters: timetablesStatsRequest.GetUrlParams());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetTimetablesStat)}");
                throw;
            }
        }

        public async Task<IEnumerable<TimetableRun>> GetTimetableRuns(DateTime date, TimetableRunRequest timetableRunRequest)
        {
            try
            {
                _logger.LogDebug("Get timetable runs");
                var result = await _currentUserProvider.GetRequestHandler().GetJson<TimetableRunsResult>($"timetables/runs/{date:yyyy-MM-dd}", parameters: timetableRunRequest.GetUrlParams());
                return result.Items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetTimetableRuns)}");
                throw;
            }
        }
        #endregion
    }
}