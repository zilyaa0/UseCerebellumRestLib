using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.Enums;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Requests;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CerebellumRestLib.Queries.Services
{
    public class DictionariesService : IDictionariesService
    {
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<DictionariesService> _logger;

        public DictionariesService(ICurrentUserProvider currentUser,
                                   ILogger<DictionariesService> logger)
        {
            _currentUser = currentUser;
            _logger = logger;
        }

        public async Task<CountableList<Priority>> GetPriorities()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<PrioritiesListResult>("category");
                return new CountableList<Priority>(result.Priorities, result.Count);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<CountableList<CustomField>> GetCustomFields()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<CustomFieldsListResult>("news/custom_fields");
                return new CountableList<CustomField>(result.CustomFields, result.Count);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<CountableList<Status>> GetStatuses()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<StatusesResult>("status");
                return new CountableList<Status>(result.Statuses, result.Count);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        [Obsolete("Use GetWorkTypesCompressed instead.")]
        public async Task<CountableList<WorkType>> GetWorkTypesForCurrentUser(bool useCache = true)
        {
            try
            {
                Dictionary<string, string> parametrs = null;
                if (!useCache)
                {
                    parametrs = new Dictionary<string, string>();
                    parametrs.Add("useCache", "false");
                }
                var result = await _currentUser.GetRequestHandler().GetJson<WorkTypesListResult>("newstype", parametrs);
                return new CountableList<WorkType>(result.WorkTypes, result.Count);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<CountableList<WorkType>> GetAllWorkTypes(bool useCache = true)
        {
            try
            {
                Dictionary<string, string> parametrs = null;
                if (!useCache)
                {
                    parametrs = new Dictionary<string, string>();
                    parametrs.Add("useCache", "false");
                }
                var result = await _currentUser.GetRequestHandler().GetJson<WorkTypesListResult>("newstype/all", parametrs);
                return new CountableList<WorkType>(result.WorkTypes, result.Count);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<WorkType> AddWorkType(WorkTypeEdit workType)
        {
            try
            {
                if (workType == null)
                    throw new ArgumentNullException(nameof(workType));


                var result = await _currentUser.GetRequestHandler().PostJson<WorkTypeResult>($"newstype", body: workType.ToJson());
                return result.WorkType;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<WorkType> EditWorkType(int id, WorkTypeEdit workType)
        {
            try
            {
                if (workType == null)
                    throw new ArgumentNullException(nameof(workType));


                var result = await _currentUser.GetRequestHandler().PutJson<WorkTypeResult>($"newstype/{id}", body: workType.ToJson());
                return result.WorkType;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<WorkType> SetWorkTypeIcon(int workTypeId, WorkTypeIconType iconType, string path)
        {
            try
            {
                string uri = "";
                switch (iconType)
                {
                    case WorkTypeIconType.Icon:
                        uri = "newstype/" + workTypeId.ToString() + "/icon";
                        break;
                    case WorkTypeIconType.Icon3D:
                        uri = "newstype/" + workTypeId.ToString() + "/icon3d";
                        break;
                    case WorkTypeIconType.MapIcon:
                        uri = "newstype/" + workTypeId.ToString() + "/mapIcon";
                        break;
                    case WorkTypeIconType.MapIconHighlight:
                        uri = "newstype/" + workTypeId.ToString() + "/mapIconHighlight";
                        break;
                    case WorkTypeIconType.Icon3DDone:
                        uri = "newstype/" + workTypeId.ToString() + "/icon3dDone";
                        break;
                    case WorkTypeIconType.IconDone:
                        uri = "newstype/" + workTypeId.ToString() + "/iconDone";
                        break;
                    case WorkTypeIconType.MapIconDone:
                        uri = "newstype/" + workTypeId.ToString() + "/mapIconDone";
                        break;
                    case WorkTypeIconType.MapIconHighlightDone:
                        uri = "newstype/" + workTypeId.ToString() + "/mapIconHighlightDone";
                        break;
                    case WorkTypeIconType.Iconmap:
                        uri = "newstype/" + workTypeId.ToString() + "/iconmap";
                        break;
                    case WorkTypeIconType.IconmapHighlight:
                        uri = "newstype/" + workTypeId.ToString() + "/iconmapHighlight";
                        break;
                    case WorkTypeIconType.IconmapDone:
                        uri = "newstype/" + workTypeId.ToString() + "/iconmapDone";
                        break;
                    case WorkTypeIconType.IconmapHighlightDone:
                        uri = "newstype/" + workTypeId.ToString() + "/iconmapHighlightDone";
                        break;
                    default:
                        uri = "newstype/" + workTypeId.ToString() + "/icon";
                        break;
                }

                var result = await _currentUser.GetRequestHandler().UploadFilePut<WorkTypeResult>(uri, new FileStream(path, FileMode.Open, FileAccess.Read), Path.GetFileName(path));
                return result.WorkType;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task DeleteWorkType(int id)
        {
            try
            {
                await _currentUser.GetRequestHandler().Delete($"/newstype/{id}");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<CountableList<WorkType>> SetWorkTypesSort(IEnumerable<int> ids)
        {
            try
            {
                var workTypesIds = new WorkTypeSortIdsRequest()
                {
                    Ids = ids
                };
                var result = await _currentUser.GetRequestHandler().PostJson<WorkTypesListResult>($"newstype/sort", body: workTypesIds.ToJson());
                return new CountableList<WorkType>(result.WorkTypes, result.Count);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<List<WorkTypeGroup>> GetWorkTypeGroups(bool useCache = true)
        {
            try
            {
                Dictionary<string, string> parametrs = null;
                if (!useCache)
                {
                    parametrs = new Dictionary<string, string>();
                    parametrs.Add("useCache", "false");
                }
                var result = await _currentUser.GetRequestHandler().GetJson<WorkTypeGroupsListResult>("newstype/group/list", parametrs);
                return result.Groups;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<WorkTypeGroup> AddWorkTypeGroup(string name)
        {
            try
            {
                var model = new WorkTypeGroupEdit { Name = name };

                var result = await _currentUser.GetRequestHandler().PostJson<CreateWorkTypeGroupResponse>("/newstype/group", body: JsonConvert.SerializeObject(model));
                return result.Group;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<WorkTypeGroup> EditWorkTypeGroup(int id, string newName)
        {
            try
            {
                var model = new WorkTypeGroupEdit { Name = newName };

                var result = await _currentUser.GetRequestHandler().PutJson<CreateWorkTypeGroupResponse>($"/newstype/group/{id}", body: JsonConvert.SerializeObject(model));
                return result.Group;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task DeleteWorkTypeGroup(int id)
        {
            try
            {
                await _currentUser.GetRequestHandler().Delete($"/newstype/group/{id}");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }

        public async Task<WorkType> GetWorkType(int workTypeId, bool useCache = true)
        {
            try
            {
                Dictionary<string, string> parametrs = null;
                if (!useCache)
                {
                    parametrs = new Dictionary<string, string>();
                    parametrs.Add("useCache", "false");
                }
                var result = await _currentUser.GetRequestHandler().GetJson<WorkTypeResult>($"newstype/{workTypeId}", parametrs);
                return result.WorkType;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<CustomField> AddCustomField(CustomFieldAdd customField)
        {
            try
            {
                if (customField == null)
                    throw new ArgumentNullException(nameof(customField));


                var result = await _currentUser.GetRequestHandler().PostJson<CustomFieldResult>($"custom_field", body: customField.ToJson());
                return result.CustomField;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<CustomField> EditCustomField(int customFieldId, CustomFieldEdit customField)
        {
            try
            {
                if (customField == null)
                    throw new ArgumentNullException(nameof(customField));


                var result = await _currentUser.GetRequestHandler().PutJson<CustomFieldResult>($"custom_field/{customFieldId}", body: customField.ToJson());
                return result.CustomField;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<CustomField> GetCustomField(int customFieldId, bool useCache = true)
        {
            try
            {
                Dictionary<string, string> parametrs = null;
                if (!useCache)
                {
                    parametrs = new Dictionary<string, string>();
                    parametrs.Add("useCache", "false");
                }
                var result = await _currentUser.GetRequestHandler().GetJson<CustomFieldResult>($"custom_field/{customFieldId}", parametrs);
                return result.CustomField;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task AttachCustomFieldToWorkType(int workTypeId, int customFieldId)
        {
            try
            {
                await _currentUser.GetRequestHandler().PostJson($"types/{workTypeId}/fields/{customFieldId}", body:"{}");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<CountableList<WorkTypeCompressed>> GetWorkTypesCompressed(bool useCache = true, bool defaultType = false)
        {
            try
            {
                Dictionary<string, string> parametrs = new Dictionary<string, string>();
                if (!useCache)
                {
                    parametrs.Add("useCache", "false");
                }
                if (defaultType)
                {
                    parametrs.Add("defaultType", "true");
                }
                var result = await _currentUser.GetRequestHandler().GetJson<WorkTypesCompressedListResult>("newstype/compressed", parametrs);
                return new CountableList<WorkTypeCompressed>(result.WorkTypeCompresseds, result.Count);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
    }
}