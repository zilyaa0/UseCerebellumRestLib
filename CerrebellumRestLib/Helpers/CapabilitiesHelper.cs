using CerebellumRestLib.Models.JSON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using CerebellumRestLib.Models;
using CerebellumRestLib.Queries.Services.Abstract;
using System.Threading.Tasks;
using CerebellumRestLib.Queries.Providers.Abstract;
using Microsoft.Extensions.Logging;

namespace CerebellumRestLib.Helpers
{
    public interface ICapabilitiesHelper
    {
        Task Initialize(IEnumerable<Organization> orgs = null, IEnumerable<DepUser> users = null);
        Dictionary<string, bool> TaskUnitCapability(TaskUnit task);
    }
    public class CapabilitiesHelper : ICapabilitiesHelper
    {
        private readonly ILogger<CapabilitiesHelper> _logger;
        private readonly ICurrentUserProvider _userProvider;
        private readonly IUsersService _usersService;
        private readonly IOrganizationsService _organizationsService;
        private readonly ICapabilityServiceV2 _capabilitiesService;

        private List<MyCapabilities> _capabilities;
        private IEnumerable<Organization> _orgs;
        private IEnumerable<DepUser> _users;

        public CapabilitiesHelper(
            ICurrentUserProvider userProvider,
            IOrganizationsService organizationsService,
            IUsersService usersService,
            ICapabilityServiceV2 capabilitiesService,
            ILogger<CapabilitiesHelper> logger)
        {
            _logger = logger;
            _userProvider = userProvider;
            _organizationsService = organizationsService;
            _usersService = usersService;
            _capabilitiesService = capabilitiesService;
        }

        #region ICapabilitiesHelper
        public async Task Initialize(IEnumerable<Organization> orgs = null, IEnumerable<DepUser> users = null)
        {
            if (orgs == null)
                _orgs = (await _organizationsService.GetOrganizations(true));
            else
                _orgs = orgs;

            if (users == null)
                _users = (await _usersService.GetDepUsers());
            else
                _users = users;

            await FillCaps();
        }
        public Dictionary<string, bool> TaskUnitCapability(TaskUnit task)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();

            if (task.Id == 0)
            {
                task.ConfirmedType = Models.Enums.TaskConfirmedType.InProgress;
                task.UserId = _userProvider.GetCurrentUser().Id;
                task.OrganizationId = _userProvider.GetCurrentUser().DepartamentId ?? 0;
            }

            MyTaskUnit myNu = new MyTaskUnit(task, new MyUser(_userProvider), _orgs, _users);
            foreach (var item in this._capabilities)
            {
                result.Add(item.Name, myNu.CalcCapability(item));
                _logger.LogTrace(item.Name + ": " + result[item.Name]);
            }
            return result;
        }
        #endregion


        private async Task FillCaps()
        {
            var allowed = await _capabilitiesService.GetAllowed();
            var capabilities = await _capabilitiesService.GetCapabilities();
            var states = await _capabilitiesService.GetStates();


            var caps = new List<MyCapabilities>();

            foreach (var item in capabilities)
            {
                var capabilitie = new MyCapabilities();

                capabilitie.Id = item.Id;
                capabilitie.Name = item.Name;

                capabilitie.Allowed = new List<MyAllowed>();

                caps.Add(capabilitie);

                var alloweds = allowed.Where(w => w.CapabilityId == item.Id);

                foreach (var allowedItem in alloweds)
                {
                    var myallowed = new MyAllowed();

                    myallowed.Id = allowedItem.Id;
                    myallowed.States = new List<MyStates>();

                    capabilitie.Allowed.Add(myallowed);

                    if (allowedItem.States != null)
                    {
                        foreach (var state in allowedItem.States)
                        {
                            var currentState = states.FirstOrDefault(w => w.Id == state);
                            if (currentState is null)
                                continue;
                            myallowed.States.Add(new MyStates
                            {
                                Id = currentState.Id,
                                Name = currentState.Name,
                                Field = currentState.Field,
                                FieldFromSession = currentState.FieldFromSession,
                                Sign = currentState.Sign,
                                Value = currentState.Value
                            });
                        }
                    }
                }
            }

            _capabilities = caps;
        }

    }
    #region Classes
    public class MyCapabilities
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<MyAllowed> Allowed { get; set; }
    }
    public class MyAllowed
    {
        public int Id { get; set; }
        public List<MyStates> States { get; set; }
    }
    public class MyStates
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public string Sign { get; set; }
        public string FieldFromSession { get; set; }
    }
    public class MyUser
    {
        private ICurrentUserProvider _userProvider;
        public MyUser(ICurrentUserProvider userProvider)
        {
            _userProvider = userProvider;
        }
        public object this[string fieldname]
        {
            get
            {
                switch (fieldname)
                {
                    case "id":
                        return _userProvider.GetCurrentUser().Id;
                    case "login":
                        return _userProvider.GetCurrentUser().Username;
                    case "fio":
                        return _userProvider.GetCurrentUser().FullName;
                    case "role_id":
                        return (int)_userProvider.GetCurrentUser().Role;
                    case "department_id":
                        return _userProvider.GetCurrentUser().WorkgroupIds;
                    default:
                        return null;
                }
            }
        }
    }
    public class MyTaskUnit
    {
        private TaskUnit _task;
        private MyUser _user;
        private readonly IEnumerable<Organization> _orgs;
        private readonly IEnumerable<DepUser> _users;
        public MyTaskUnit(TaskUnit task, MyUser user, IEnumerable<Organization> orgs, IEnumerable<DepUser> users)
        {
            _task = task;
            _user = user;
            _orgs = orgs;
            _user = user;
            _users = users;
        }
        public object this[string fieldname]
        {
            get
            {
                switch (fieldname)
                {
                    case "id":
                        return this._task.Id;
                    case "department_id":
                        return this._task.OrganizationId;
                    case "department_logo":
                        return this._task.OrganizationLogo;
                    case "news_date":
                        return this._task.TaskDate;
                    case "confirmed":
                        return (int)this._task.ConfirmedType;
                    case "title":
                        return this._task.Title;
                    case "text":
                        return this._task.Text;
                    case "news_type_id":
                        return this._task.WorkTypeId;
                    case "category_id":
                        return this._task.PriorityId;
                    case "assigned_to":
                        return this._task.AssignedTo;
                    case "assigned_department_name":
                        return this._task.AssignedOrganizationName;
                    case "assigned_status":
                        return (int)this._task.AssignedStatus;
                    case "status_name":
                        return this._task.StatusName;
                    case "assigned_to_user":
                        return this._task.AssignedToUser;
                    case "assigned_user_fio":
                        return this._task.AssignedUserFio;
                    case "assigned_change_date":
                        return this._task.AssignedChangeDate;
                    case "restricted":
                        return this._task.Restricted;
                    case "notice":
                        return this._task.Notice;
                    case "news_type_icon":
                        return this._task.WorkTypeIcon;
                    case "news_type_name":
                        return this._task.WorkTypeName;
                    case "num_main_photo":
                        return this._task.NumMainPhoto;
                    case "archive":
                        return this._task.Archive;
                    case "category_name":
                        return this._task.PriorityName;
                    case "system_data":
                        return this._task.SystemData;
                    case "lon":
                        return this._task.Longitude;
                    case "lat":
                        return this._task.Latitude;
                    case "zoom":
                        return this._task.Zoom;
                    case "custom_fields":
                        return this._task.CustomFields;
                    case "department_title":
                        return this._task.OrganizationTitle;
                    case "user_id":
                        return this._task.UserId;
                    case "user_fio":
                        return this._task.UserFio;
                    case "is_template":
                        return this._task.IsTemplate;
                    default:
                        return null;
                }
            }
        }
        public bool CalcCapability(MyCapabilities caps)
        {
            if (caps.Allowed.Count == 0)
            {
                return true;
            }
            foreach (var allow in caps.Allowed)
            {
                bool result = true;
                foreach (var state in allow.States)
                {
                    result = result && this.CalcState(state);
                }
                if (!result)
                {
                    continue;
                }
                return result;
            }
            return false;
        }
        private bool CalcState(MyStates state)
        {
            if (state.Field == "assigned_user_id")
            {
                state.Field = "assigned_to_user";
            }
            if (state.Field == "assigned_organization_id")
            {
                state.Field = "assigned_to";
            }
            if (state.Field == "assigned_status_id")
            {
                state.Field = "assigned_status";
            }
            if (state.Field == "organization_id")
            {
                state.Field = "department_id";
            }
            object comparison_value = null;
            object news_value = null;
            if (state.Name == "people_department")
            {
                state.Field = "department_id";
                int value = this.GetPeopleDepartmentId();
                if (value == -1)
                {
                    return false;
                }
                comparison_value = value.ToString();
            }
            if (state.Name == "not_people_department")
            {
                state.Field = "department_id";
                state.Sign = "!=";
                int value = this.GetPeopleDepartmentId();
                if (value == -1)
                {
                    return false;
                }
                comparison_value = value.ToString();
            }
            news_value = this[state.Field];


            if (state.Name == "user_from_people_dep")
            {
                state.Sign = "=";
                int value = this.GetPeopleDepartmentId();
                if (value == -1)
                {
                    return false;
                }
                news_value = value;
                state.Value = "department_id";
            }
            if (state.Name == "user_not_from_people_dep")
            {
                state.Sign = "!=";
                int value = this.GetPeopleDepartmentId();
                if (value == -1)
                {
                    return false;
                }
                news_value = value;
                state.FieldFromSession = "department_id";
            }

            if (state.FieldFromSession != null)
            {
                if (state.FieldFromSession == "department_id")
                {
                    var currUserWorkGroups = this._user[state.FieldFromSession] as IEnumerable<int>;
                    //Получаем ид организаций, которые сопоставляются с рабочими группами пользователя
                    var orgs = _orgs.Where(w => currUserWorkGroups.Any(q => q == w.WorkgroupId));
                    //if (state.Field == "assigned_to" && this["assigned_to_user"]!=null)
                    //{
                    //    var assignedUserId = this["assigned_to_user"] as int?;
                    //    if (assignedUserId.HasValue)
                    //    {
                    //        var assignedUser = _users.FirstOrDefault(w => w.Id == assignedUserId.Value);
                    //        if (assignedUser != null)
                    //            orgs = orgs.Union(_orgs.Where(w => assignedUser.WorkgroupIds.Any(q => q == w.WorkgroupId)));
                    //    }
                    //}
                    comparison_value = orgs.Select(w => w.Id);
                }
                else
                    comparison_value = this._user[state.FieldFromSession];
            }
            else
            {
                if (comparison_value == null)
                {
                    comparison_value = state.Value;
                }
            }

            switch (state.Sign)
            {
                case null:
                    return EqualsValue(news_value, comparison_value);
                case "=":
                    return EqualsValue(news_value, comparison_value);
                case "!=":
                    return NotEqualsValue(news_value, comparison_value);
                default:
                    break;
            }
            return false;
        }
        private bool EqualsValue(object first_value, object second_value)
        {
            if (first_value == null)
            {
                return (second_value == null || second_value.ToString().ToUpper() == "NULL");
            }
            if (typeof(int) == first_value.GetType())
            {
                try
                {
                    if (second_value is IEnumerable<int> list)
                    {
                        return list.Any(w => w == Convert.ToInt32(first_value));
                    }
                    else
                        return (Convert.ToInt32(first_value) == Convert.ToInt32(second_value));
                }
                catch
                {
                    return false;
                }
            }
            else if (typeof(bool) == first_value.GetType())
            {
                try
                {
                    return (Convert.ToBoolean(first_value) == (second_value.ToString() == "t" ? true : false));
                }
                catch
                {
                    return false;
                }
            }
            else if (typeof(string) == first_value.GetType())
            {
                try
                {
                    return (Convert.ToString(first_value) == Convert.ToString(second_value));
                }
                catch
                {
                    return false;
                }
            }
            else if (typeof(DateTime) == first_value.GetType())
            {
                try
                {
                    return (Convert.ToDateTime(first_value) == Convert.ToDateTime(second_value));
                }
                catch
                {
                    return false;
                }
            }
            else if (typeof(double) == first_value.GetType())
            {
                try
                {
                    return (Convert.ToDouble(first_value) == Convert.ToDouble(second_value));
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        private bool NotEqualsValue(object first_value, object second_value)
        {
            if (first_value == null)
            {
                return (second_value != null && second_value.ToString().ToUpper() == "NULL");
            }
            if (typeof(int) == first_value.GetType())
            {
                try
                {
                    if (second_value is IEnumerable<int> list)
                    {
                        return !list.Any(w => w == Convert.ToInt32(first_value));
                    }
                    else
                        return (Convert.ToInt32(first_value) != Convert.ToInt32(second_value));
                }
                catch
                {
                    return false;
                }
            }
            else if (typeof(bool) == first_value.GetType())
            {
                try
                {
                    return (Convert.ToBoolean(first_value) != (second_value.ToString() == "t" ? true : false));
                }
                catch
                {
                    return false;
                }
            }
            else if (typeof(string) == first_value.GetType())
            {
                try
                {
                    return (Convert.ToString(first_value) != Convert.ToString(second_value));
                }
                catch
                {
                    return false;
                }
            }
            else if (typeof(DateTime) == first_value.GetType())
            {
                try
                {
                    return (Convert.ToDateTime(first_value) != Convert.ToDateTime(second_value));
                }
                catch
                {
                    return false;
                }
            }
            else if (typeof(double) == first_value.GetType())
            {
                try
                {
                    return (Convert.ToDouble(first_value) != Convert.ToDouble(second_value));
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        private int GetPeopleDepartmentId()
        {
            foreach (var item in this._orgs)
            {
                if (item.PeopleDep)
                {
                    return Convert.ToInt32(item.Id);
                }
            }
            return -1;
        }
    }
    #endregion
}
