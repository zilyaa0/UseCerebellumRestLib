using System.Collections.Generic;
using System.Threading.Tasks;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.Enums;
using CerebellumRestLib.Models.JSON.Entities;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IDictionariesService
    {
        Task<WorkType> AddWorkType(WorkTypeEdit workType);
        Task<WorkType> EditWorkType(int id, WorkTypeEdit workType);
        Task<CountableList<WorkType>> GetAllWorkTypes(bool useCache = true);
        Task<WorkType> GetWorkType(int workTypeId, bool useCache = true);
        Task<CountableList<WorkType>> SetWorkTypesSort(IEnumerable<int> ids);
        Task<CountableList<CustomField>> GetCustomFields();
        Task<CountableList<Priority>> GetPriorities();
        Task<CountableList<Status>> GetStatuses();
        Task<List<WorkTypeGroup>> GetWorkTypeGroups(bool useCache = true);
        Task<CountableList<WorkType>> GetWorkTypesForCurrentUser(bool useCache = true);
        Task DeleteWorkType(int id);
        Task<WorkTypeGroup> AddWorkTypeGroup(string name);
        Task<WorkTypeGroup> EditWorkTypeGroup(int id, string newName);
        Task DeleteWorkTypeGroup(int id);
        Task<WorkType> SetWorkTypeIcon(int workTypeId, WorkTypeIconType iconType, string path);
        Task<CustomField> EditCustomField(int customFieldId, CustomFieldEdit customField);
        Task<CustomField> AddCustomField(CustomFieldAdd customField);
        Task<CustomField> GetCustomField(int customFieldId, bool useCache = true);
        Task AttachCustomFieldToWorkType(int workTypeId, int customFieldId);
        Task<CountableList<WorkTypeCompressed>> GetWorkTypesCompressed(bool useCache = true, bool defaultType = false);
    }
}