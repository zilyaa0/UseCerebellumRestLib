using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface ITasksServiceV2
    {
        Task<TaskEntity> GetTask(long taskId);
        Task<TaskEntity> AddTask(TaskCreate task, bool? copyServiceObjectFiles = null);
        Task<TaskEntity> EditTask(long taskId, TaskEdit task, IEnumerable<string> setNullProps = null);
        Task<CountableList<TaskEntity>> GetTasks(TaskListRequest request);
        Task<CountableList<TaskEntity>> GetTaskList(TaskListRequest request);
        Task DeleteTask(long taskId);
        Task<Models.JSON.Entities.Comment[]> GetTaskCommentsList(int taskId, int page = 1, int limit = 25);
        Task<Models.JSON.Entities.Comment> AddComment(int taskId, string text, int? replyToId = null);
        Task<Models.JSON.Entities.RatingM> GetRating(int taskId);
        Task<Models.JSON.Entities.V2.TaskDistribution> GetDistribution(Models.TaskListRequest requestState);
        Task<IEnumerable<Models.JSON.Entities.TaskPoint>> GetPointsList(Models.TaskListRequest request, bool withCustomFieldGeom);
        Task SetFavorite(long taskId);
        Task DeleteFavorite(long taskId);
    }
}
