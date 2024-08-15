using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Entities.V2;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class TasksServiceV2 : ITasksServiceV2
    {
        #region Fields
        private ILogger<TasksServiceV2> _logger;
        private readonly ICurrentUserProvider _currentUser;
        private readonly ReadOnlyDictionary<string, string> _initParams;
        #endregion

        #region Constructor
        public TasksServiceV2(ICurrentUserProvider currentUser,
                           ILogger<TasksServiceV2> logger)
        {
            _currentUser = currentUser;
            _logger = logger;
            var prms = new Dictionary<string, string>();
            prms.Add("apiVersion", "2.0");
            _initParams = new ReadOnlyDictionary<string, string>(prms);
        }

        #endregion

        #region ITasksServiceV2
        public async Task<TaskEntity> AddTask(TaskCreate task, bool? copyServiceObjectFiles = null)
        {
            try
            {
                _logger.LogDebug($"AddTask: {task.Title}");
                if (task == null)
                {
                    throw new ArgumentNullException(nameof(task));
                }
                if (!task.IsValid())
                {
                    throw new ArgumentException("Task model must be valid.", nameof(task));
                }

                var @params = _initParams.ToDictionary(k => k.Key, v => v.Value);
                if (copyServiceObjectFiles.HasValue)
                    @params.Add("copyServiceObjectFiles", copyServiceObjectFiles.ToString().ToLower());

                var result = await _currentUser.GetRequestHandler().PostJson<TaskEntity>($"tasks", parameters: @params, body: task.ToJson(true));
                return result;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<TaskEntity> GetTask(long taskId)
        {
            _logger.LogDebug($"GetTask: {taskId}");
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<TaskEntityWithConfiguration>($"tasks/{taskId}", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value));
                if (result.Configuration != null)
                {
                    result.Task.Configuration = result.Configuration;
                }
                if (result.Schedule != null)
                {
                    result.Task.Schedule = result.Schedule;
                }
                return result.Task;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<TaskEntity> EditTask(long taskId, TaskEdit task, IEnumerable<string> setNullProps = null)
        {
            try
            {
                var body = task.ToJson(true);
                if (setNullProps != null)
                {
                    var jObj = Newtonsoft.Json.Linq.JObject.Parse(body);
                    foreach (var propName in setNullProps)
                    {
                        jObj.Add(propName, null);
                    }
                    body = jObj.ToString();
                }
                return await _currentUser.GetRequestHandler().PatchJson<TaskEntity>($"tasks/{taskId}", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value), body: body);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<CountableList<TaskEntity>> GetTasks(TaskListRequest request)
        {
            try
            {
                _logger.LogDebug($"GetTasks");
                var result = await _currentUser.GetRequestHandler().GetJson<TasksItemsResult>($"tasks",
                        parameters: _initParams.ToDictionary(k => k.Key, v => v.Value).Union(request.GetUrlParams()).ToDictionary(w => w.Key, w => w.Value));
                return new CountableList<TaskEntity>(result.Items != null ? new List<TaskEntity>(result.Items) : new List<TaskEntity>(), result.Count);
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex);
                throw;
            }
        }

        public async Task<CountableList<TaskEntity>> GetTaskList(TaskListRequest request)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<TasksItemsResult>($"tasks/listAfterId/{request.AfterId}/{request.Limit}",
                    parameters: _initParams.ToDictionary(k => k.Key, v => v.Value).Union(request.GetUrlParams()).ToDictionary(w => w.Key, w => w.Value));

                if (result.Schedules != null && result.Schedules.Any())
                {
                    var schedules = result.Schedules.ToDictionary(k => k.Id, v => v);
                    foreach (var item in result.Items)
                    {
                        if (item.ScheduleId.HasValue && schedules.ContainsKey(item.ScheduleId.Value))
                        {
                            item.Schedule = schedules[item.ScheduleId.Value];
                        }
                    }
                }

                return new CountableList<TaskEntity>(result.Items != null ? new List<TaskEntity>(result.Items) : new List<TaskEntity>(), result.Count);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task DeleteTask(long taskId)
        {
            try
            {
                _logger.LogDebug($"DeleteTask: {taskId}");
                await _currentUser.GetRequestHandler().Delete($"tasks/{taskId}");
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex);
                throw;
            }
        }
        public async Task<Comment[]> GetTaskCommentsList(int taskId, int page = 1, int limit = 25)
        {
            try
            {
                var dict = new Dictionary<string, string>
                {
                    { "page", page.ToString() },
                    { "limit", limit.ToString() },
                    { "apiVersion", "2.0"}
                };

                var result = await _currentUser.GetRequestHandler().GetJson<Models.JSON.Results.V2.CommentsResult>($"tasks/{taskId}/comments/list", dict);

                return result.Comments;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e, nameof(GetTaskCommentsList));
                throw;
            }
        }
        public async Task<Comment> AddComment(int taskId, string text, int? replyToId = null)
        {
            var url = replyToId.HasValue
                ? $"tasks/{taskId}/comments/" + replyToId
                : $"tasks/{taskId}/comments";


            var body = new Models.JSON.Requests.AddCommentRequest { Comment = text };

            try
            {
                var prms = new Dictionary<string, string>();
                prms.Add("apiVersion", "2.0");
                return await _currentUser.GetRequestHandler().PostJson<Comment>(url, parameters: prms, body: body.ToJson());
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<RatingM> GetRating(int taskId)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<RatingM>($"tasks/{taskId}/rating", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value));
                return result;
            }
            catch (WebException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex, nameof(GetRating));
                throw;
            }
        }
        public async Task<Models.JSON.Entities.V2.TaskDistribution> GetDistribution(TaskListRequest requestState)
        {
            try
            {
                var @params = requestState.GetUrlParams();
                @params.Add("apiVersion", "2.0");
                var result = await _currentUser.GetRequestHandler().GetJson<Models.JSON.Entities.V2.TaskDistribution>("tasks/distribution", @params);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<IEnumerable<TaskPoint>> GetPointsList(TaskListRequest request, bool withCustomFieldGeom)
        {
            try
            {
                var @params = request.GetUrlParams();
                @params.Add("apiVersion", "2.0");
                var result = !withCustomFieldGeom ?
                    await _currentUser.GetRequestHandler().GetJson<Models.JSON.Results.V2.TaskPointListResult>("tasks/points", @params)
                    :
                    await _currentUser.GetRequestHandler().GetJson<Models.JSON.Results.V2.TaskPointListResult>("tasks/geometry", @params);
                return result.Tasks;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e, nameof(GetPointsList));
                throw;
            }
        }
        public async Task SetFavorite(long taskId)
        {
            _logger.LogDebug($"SetFavorite:{taskId}");
            try
            {
                await _currentUser.GetRequestHandler().PostJson($"tasks/{taskId}/favorite", parameters: _initParams.ToDictionary(k => k.Key, v => v.Value), "{}");
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex);
                throw;
            }
        }
        public async Task DeleteFavorite(long taskId)
        {
            _logger.LogDebug($"DeleteFavorite:{taskId}");
            try
            {
                await _currentUser.GetRequestHandler().Delete($"tasks/{taskId}/favorite");
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex);
                throw;
            }
        }
        #endregion
    }
}
