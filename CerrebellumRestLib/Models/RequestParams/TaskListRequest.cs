using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;

namespace CerebellumRestLib.Models
{
    public class TaskListRequest
    {
        public TaskListRequest(int afterId = 0, int limit = 100)
        {
            AfterId = afterId;
            Limit = limit;
        }

        /// <summary>
        /// Id задания, после которой надо получить список заданий, по умолчанию 0.
        /// </summary>
        public int AfterId { get; set; }

        /// <summary>
        /// Номер задания
        /// </summary>
        [Description("no")]
        public long? No { get; set; }

        /// <summary>
        /// Количество заданий в запросе, по умолчанию 1000.
        /// </summary>
        [Description("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// 1 - в работе, 2 - завершено, 0 - отказано.
        /// </summary>
        [Description("confirmed")]
        public byte? Confirmed { get; set; }

        [Description("stage")]
        public byte? Stage { get; set; }

        /// <summary>
        /// При значении withAssigned=true в список добавляются не новые и не закрытые задания, назначенные пользователю, 
        /// либо его ведомству (если он админ) задания.
        /// </summary>
        [Description("withAssigned")]
        public bool? WithAssigned { get; set; }

        /// <summary>
        /// При значении withClosed=true в список добавляются задания со статусом выполнено, 
        /// назначенные пользователю, либо его ведомству (если он админ).
        /// </summary>
        [Description("withClosed")]
        public bool? WithClosed { get; set; }

        /// <summary>
        /// При значении withArchive=true, в список добавляются задания, которые в архиве (по умолчанию берутся текущие).
        /// </summary>
        [Description("withArchive")]
        public bool? WithArchive { get; set; }

        /// <summary>
        /// При значении onlyMy=true, в списке отображаются только задания, созданные пользователем. 
        /// Параметры withAssigned, withClosed, onlyStatus при этом игнорируются.
        /// </summary>
        [Description("onlyMy")]
        public bool? OnlyMy { get; set; }

        /// <summary>
        /// Отображаются задания с соответствующими статусами. 
        /// Id статусов передаются через запятую. Например, onlyStatus=2,3.
        /// </summary>
        [Description("onlyStatus")]
        public int[] OnlyStatus { get; set; }

        /// <summary>
        /// Отображаются задания, которые находятся в соответствующих состояниях. 
        /// Id статусов передаются через запятую. Например, onlyStates=6,11.
        /// </summary>
        [Description("onlyStates")]
        public int[] OnlyStates { get; set; }

        /// <summary>
        /// При значении onlyAssigned=true отображаются задания, которые не новые и не выполнены, но назначены.
        /// </summary>
        [Description("onlyAssigned")]
        public bool? OnlyAssigned { get; set; }


        /// <summary>
        /// Фильтр по родительским заданиям. Id заданий передаются через запятую. Например, parentId=3,4,5
        /// </summary>
        [Description("parentId")]
        public int[] ParentId { get; set; }

        /// <summary>
        /// Фильтр по категориям заданий. Id категорий передаются через запятую. Например, category_id=1,2.
        /// </summary>
        [Description("category_id")]
        public int[] CategoryId { get; set; }

        /// <summary>
        /// Фильтр по типам заданий. Id типов передаются через запятую. Например, type_id=3,4,5.
        /// </summary>
        [Description("type_id")]
        public int[] TypeId { get; set; }

        /// <summary>
        /// Отображаются задания, дата обновления которых больше указанной даты (дата указывается в Timestamp, например, gtUpdateDate=1440835402).
        /// </summary>
        [Description("gtUpdateDate")]
        public long? GreaterThanUpdateDate { get; set; }


        /// <summary>
        /// Для получения шаблонов
        /// </summary>
        [Description("isTemplate")]
        public bool? IsTemplate { get; set; }

        /// <summary>
        /// Отображаются задания, дата обновления которых меньше указанной даты (дата указывается в Timestamp, например, ltUpdateDate=1440835402).
        /// </summary>
        [Description("ltUpdateDate")]
        public long? LowerThanUpdateDate { get; set; }

        /// <summary>
        ///  Отображаются задания, дата создания которых больше указанной даты (дата указывается в Timestamp, например, gtCreateDate=1440835402).
        /// </summary>
        [Description("gtCreateDate")]
        public long? GreaterThanCreateDate { get; set; }

        /// <summary>
        /// Отображаются задания, дата создания которых меньше указанной даты (дата указывается в Timestamp, например, ltCreateDate=1440835402).
        /// </summary>
        [Description("ltCreateDate")]
        public long? LowerThanCreateDate { get; set; }

        /// <summary>
        /// Отображаются задания, параметр deadline которых больше указанной даты (дата указывается в Timestamp, например, gtDeadline =1440835402).
        /// </summary>
        [Description("gtDeadline")]
        public long? GreaterThanDeadline { get; set; }

        /// <summary>
        /// Отображаются задания, параметр deadline которых меньше указанной даты (дата указывается в Timestamp, например, ltDeadline =1440835402).
        /// </summary>
        [Description("ltDeadline")]
        public long? LowerThanDeadline { get; set; }

        /// <summary>
        /// Отображаются задания, которые назначены на указанные организации. Id организаций передаются через запятую. Например, assigned_organization_id=1,2,292.
        /// </summary>
        [Description("assignedOrganizationId")]
        public int[] AssignedOrganizationId { get; set; }

        /// <summary>
        /// Отображаются задания, которые назначены на указанных пользователей. Id пользователей передаются через запятую. Например, assigned_user_id=616,618.
        /// </summary>
        [Description("assignedUserId")]
        public int[] AssignedUserId { get; set; }

        /// <summary>
        /// Отображаются задания, созданные указанными пользователями. Id пользователей передаются через запятую. Например, user_id=616,618.
        /// </summary>
        [Description("creatorId")]
        public int[] UserId { get; set; }

        /// <summary>
        /// Отображаются задания, удовлетворяющие текстовому поиску указанного значения по значениям параметров id, text, title. Например, search=7891.
        /// </summary>
        [Description("search")]
        public string Search { get; set; }

        /// <summary>
        /// true / t - просроченные задания, т.е. такие, deadline которых уже прошел, а само задание находится в стадии В работе (confirmed = 1);
        /// false / f - просроченные задания для, т.е. такие, deadline которых еще не прошел, а само задание находится в стадии В работе (confirmed = 1);
        /// undefined - задания, для которых понятие просроченности не определено, т.е. такие, которые не имеют deadline'а, либо не находятся в стадии В работе.
        /// </summary>
        [Description("expired")]
        public string Expired { get; set; }

        /// <summary>
        /// true / t - отдаются только дочерние задания (parent_id IS NOT NULL);
        /// false / f - отдаются только задания без родителя (parent_id IS NULL);
        /// </summary>
        [Description("childTasks")]
        public bool? ChildTasks { get; set; }

        /// <summary>
        /// Поле, по которому осуществляется сортировка. По умолчанию - news_date.
        /// </summary>
        [Description("sortBy")]
        public string SortBy { get; set; }

        /// <summary>
        /// Номер страницы при запросе точек.
        /// </summary>
        [Description("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Направление сортировки (ASC, DESC). По умолчанию - DESC.
        /// </summary>
        [Description("sortDirection")]
        public string SortDirection { get; set; }

        /// <summary>
        /// customFields=[{"name":"Dop_pole_dlya_testov","op":"EQ","value":"12345"},{"name":"Telefon__int__88432000555__","op":"NOT NULL"}]
        /// </summary>
        [Description("customFields")]
        public string CustomFields { get; set; }

        /// <summary>
        /// Фильтр по объектам обслуживания. Id объектов обслуживания передаются через запятую. Например, serviceObjectId=1,2
        /// </summary>
        [Description("serviceObjectId")]
        public int[] ServiceObjectIds { get; set; }

        /// <summary>
        /// Фильтр по слоям объектов обслуживания
        /// </summary>
        [Description("serviceObjectLayerId")]
        public int? ServiceObjectLayerId { get; set; }

        /// <summary>
        /// Отображаются задания, созданные в указанных организациях. Id организаций передаются через запятую. Например, organizationId=1,2,292
        /// </summary>
        [Description("organizationId")]
        public int[] OrgCreatorsIds { get; set; }

        [Description("contractId")]
        public int[] ContractIds { get; set; }
        /// <summary>
        /// отображаются задания, у которых количество фото, добавленных после создания задания, больше указанного значения
        /// </summary>
        [Description("gtAddedPhotoCount")]
        public int? GtAddedPhotoCount { get; set; }
        /// <summary>
        /// отображаются задания, у которых количество фото, добавленных после создания задания, меньше указанного значения
        /// </summary>
        [Description("ltAddedPhotoCount")]
        public int? LtAddedPhotoCount { get; set; }
        /// <summary>
        /// отображаются задания, для которых процент совпадения фото с образцом меньше указанного значения
        /// </summary>
        [Description("ltSampleMatching")]
        public string LtSampleMatching { get; set; }
        /// <summary>
        /// отображаются задания, для которых процент совпадения фото с образцом больше указанного значения
        /// </summary>
        [Description("gtSampleMatching")]
        public string GtSampleMatching { get; set; }
        /// <summary>
        /// Получение задании без оценок
        /// </summary>
        [Description("noSampleMatching")]
        public bool? NoSampleMatching { get; set; }

        [Description("favorite")]
        public bool? IsFavorite { get; set; }
        /// <summary>
        /// Фильтр по расписаниям
        /// </summary>
        [Description("scheduleId")]
        public int[] ScheduleIds { get; set; }
        public Dictionary<string, string> GetUrlParams()
        {
            var requestParams = new Dictionary<string, string>();
            
            foreach (var propertyInfo in GetType().GetProperties())
            {
                var descriptions = propertyInfo
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .OfType<DescriptionAttribute>()
                    .ToList();

                if (!descriptions.Any())
                {
                    continue;
                }
                
                var value = propertyInfo.GetValue(this, null);

                if (value == null)
                {
                    continue;
                }

                var valueString = value is int[] array
                    ? String.Join(",", array)
                    : (value.GetType() == typeof(bool)? ConvertBool((bool)value) :value.ToString());
                if (!string.IsNullOrWhiteSpace(valueString))
                    requestParams.Add($"{descriptions.First().Description}", $"{WebUtility.UrlEncode(valueString)}");
            }
            
            return requestParams;
        }

        private string ConvertBool(bool value)
        {
            return value ? "true" : "false";
        }
    }
    public enum SortType
    {
        [Description("id")]
        ById = 0,
        [Description("title")]
        ByTitle = 1,
        [Description("news_date")]
        ByCreateDate = 2,
        [Description("update_date")]
        ByUpdate = 3,
        [Description("deadline")]
        ByDeadline = 4,
    }

    public enum SortDirection
    {
        [Description("desc")]
        Descending = 0,
        [Description("asc")]
        Ascending = 1
    }
}