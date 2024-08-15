using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface ITaskService
    {
        Task<Comment> AddComment(int taskId, string text, int? replyToId = null);
        Task<Comment[]> GetComments(int taskId);
        Task DeleteTaskUnit(int taskId);
        Task<List<DeletedTask>> GetDeletedTaskList(DateTimeOffset? lowerThen = null, DateTimeOffset? greaterThen = null);
        Task<TaskUnit> GetTask(int id);
        Task<int> GetTaskCount();
        Task<CountableList<TaskUnit>> GetTaskList(TaskListRequest request);
        Task<CountableList<TaskUnit>> GetTasks(TaskListRequest request);
        Task<int> AddTaskUnit(TaskUnitCreate task, TaskUnitPoint point);
        Task UpdateTaskUnit(int taskId, TaskUnitUpdate task, IEnumerable<string> setNullProps = null);
        Task<TaskDistribution> GetDistribution(TaskListRequest requestState);
        Task<IEnumerable<TaskPoint>> GetPointsList(TaskListRequest request, bool withCustomFieldGeom);
        Task<RatingM> GetRating(int taskId);
        Task<Comment[]> GetTaskCommentsList(int taskId, int page = 1, int limit = 25);
    }
}