using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services;

namespace CerebellumRestLib.Queries.Static
{
    public class TasksRequests : TaskService
    {
        public TasksRequests(ICurrentUserProvider currentUser) 
            : base(currentUser, StaticBindingHelper.GetLogger<TasksRequests>())
        {
        }
    }
}