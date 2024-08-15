using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.JSON.Requests;
using Newtonsoft.Json;
using CerebellumRestLib.Queries.Services.Abstract;
using System.Threading;
using CerebellumRestLib.Queries.Providers.Abstract;

namespace CerebellumRestLib.Queries.Services
{
    public class TaskService : ITaskService
    {
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<TaskService> _logger;

        public TaskService(ICurrentUserProvider currentUser,
                           ILogger<TaskService> logger)
        {
            _currentUser = currentUser;
            _logger = logger;
        }

        /// <summary>
        /// Получить список задач с установленными параметрами, в том числе параметрами фильтрации (listAfterId).
        /// </summary>
        /// <returns>Список задач и общее количество задач по данному фильтру.</returns>
        public async Task<CountableList<TaskUnit>> GetTaskList(TaskListRequest request)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<GetTasksListResult>($"news/listAfterId/{request.AfterId}/{request.Limit}", request.GetUrlParams());

                return new CountableList<TaskUnit>(result.TasksList, result.CountTasks);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        /// <summary>
        /// Получить список задач с установленными параметрами, в том числе параметрами фильтрации.
        /// </summary>
        /// <returns>Список задач и общее количество задач по данному фильтру.</returns>
        public async Task<CountableList<TaskUnit>> GetTasks(TaskListRequest request)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<GetTasksListResult>($"tasks", request.GetUrlParams());

                return new CountableList<TaskUnit>(result.TasksList, result.CountTasks);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<TaskUnit> GetTask(int id)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<TaskUnitResult>($"news/{id}");
                if (result.Configuration != null)
                {
                    result.TaskUnit.Configuration = result.Configuration;
                }
                return result.TaskUnit;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        /// <summary>
        /// Получить количество всех задач пользователя.
        /// </summary>
        /// <returns>Количество задач.</returns>
        public async Task<int> GetTaskCount()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<TaskCountResult>("news/count");
                return result.Count;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        /// <summary>
        /// Получение списка удаленных заданий.
        /// </summary>
        /// <param name="lowerThen">Задание должно быть удалено ранее чем данный параметр.</param>
        /// <param name="greaterThen">Задание должно быть удалено позднее чем данный параметр.</param>
        /// <returns>A list of the deleted tasks in this period.</returns>
        public async Task<List<DeletedTask>> GetDeletedTaskList(DateTimeOffset? lowerThen = null, DateTimeOffset? greaterThen = null)
        {
            try
            {
                var url = $"news/deletions";

                var dict = new Dictionary<string, string>
                {
                    { "ltDeleteDate", (lowerThen ?? DateTimeOffset.MaxValue).ToUnixTimeSeconds().ToString() },
                    { "gtDeleteDate", (greaterThen ?? DateTimeOffset.MaxValue).ToUnixTimeSeconds().ToString() }
                };

                var result = await _currentUser.GetRequestHandler().GetJson<DeletedTaskListResult>(url, dict);
                return result.DeletedTasks;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        /// <summary>
        /// Добавить задание.
        /// </summary>
        /// <param name="task">Добавляемое задание.</param>
        /// <param name="point">Геометрические координаты нового задания.</param>
        /// <returns>Ид созданного задания</returns>
        public async Task<int> AddTaskUnit(TaskUnitCreate task, TaskUnitPoint point)
        {
            try
            {
                if (task == null)
                {
                    throw new ArgumentNullException(nameof(task));
                }
                if (!task.IsValid())
                {
                    throw new ArgumentException("Task model must be valid.", nameof(task));
                }

                var request = new CreateTaskUnitRequest
                {
                    TaskUnit = task,
                    Point = point?.ToArray()
                };

                var result = await _currentUser.GetRequestHandler().PostJson<CreateTaskUnitResult>($"news", body: request.ToJson(true));
                return result.TaskId;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        /// <summary>
        /// Обновить задание.
        /// </summary>
        /// <param name="taskId">Id обновляемого задания.</param>
        /// <param name="task">Информация</param>
        public async Task UpdateTaskUnit(int taskId, TaskUnitUpdate task, IEnumerable<string> setNullProps = null)
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
                await _currentUser.GetRequestHandler().PostJson($"news/{taskId}/update", body);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        /// <summary>
        /// Удалить задание.
        /// </summary>
        /// <param name="taskId">Id удаляемого задания.</param>
        public async Task DeleteTaskUnit(int taskId)
        {
            try
            {
                await _currentUser.GetRequestHandler().PostJson($"news/{taskId}", new DeleteRequest().ToJson());
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        /// <summary>
        /// Добавить комментарий.
        /// </summary>
        /// <param name="taskId">Id задания, к которому добавляется комментарий.</param>
        /// <param name="text">Текст добовляемого комментария.</param>
        /// <param name="replyToId">Id комментария, которому отвечает текущий.</param>
        public async Task<Comment> AddComment(int taskId, string text, int? replyToId = null)
        {
            var url = replyToId.HasValue
                ? $"news/{taskId}/comments/" + replyToId
                : $"news/{taskId}/comments";


            var body = new AddCommentRequest { Comment = text };

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

        public async Task<Comment[]> GetComments(int taskId)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<CommentsResult>($"news/{taskId}/comments");
                return result.Comments;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<TaskDistribution> GetDistribution(TaskListRequest requestState)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<TaskDistribution>("news/distribution", requestState.GetUrlParams());
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
                var result = !withCustomFieldGeom ?
                    await _currentUser.GetRequestHandler().GetJson<TasksPointResult>("news/points", request.GetUrlParams())
                    :
                    await _currentUser.GetRequestHandler().GetJson<TasksPointResult>("news/geometry", request.GetUrlParams());
                return result.TasksPoint;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e, nameof(GetPointsList));
                throw;
            }
        }

        public async Task<RatingM> GetRating(int taskId)
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<RatingM>($"news/{taskId}/rating");
                return result;
            }
            catch (Exception ex) when (ex.Message == "Оценки не существует.")
            {
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex, nameof(GetRating));
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
                    { "limit", limit.ToString() }
                };

                var result = await _currentUser.GetRequestHandler().GetJson<CommentsResult>($"news/{taskId}/comments/list", dict);

                return result.Comments;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e, nameof(GetTaskCommentsList));
                throw;
            }
        }
    }
}