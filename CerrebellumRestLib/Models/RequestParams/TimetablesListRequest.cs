using CerebellumRestLib.Models.Base.Request;
using System.ComponentModel;

namespace CerebellumRestLib.Models.RequestParams
{
    public abstract class TimetablesRequestBase : PageableRequestBase
    {
        /// <summary>
        /// Id видов работ
        /// </summary>
        [Description("typeId")]
        public int[] WorkTypeId { get; set; }

        /// <summary>
        /// Id приоритетов
        /// </summary>
        [Description("priorityId")]
        public int[] PriorityId { get; set; }

        /// <summary>
        /// Id назначенной организации
        /// </summary>
        [Description("assignedOrganizationId")]
        public int[] AssignedOrganizationId { get; set; }

        /// <summary>
        /// Id назначенного пользователя
        /// </summary>
        [Description("assignedUserId")]
        public int[] AssignedUserId { get; set; }

        /// <summary>
        /// Id организации шаблона
        /// </summary>
        [Description("organizationId")]
        public int[] OrganizationId { get; set; }
        /// <summary>
        /// Текстовый поиск по заголовку задания (с начала строки)
        /// </summary>
        [Description("taskTitle")]
        public string TaskTitle { get; set; }
    }

    public class TimetablesListRequest : TimetablesRequestBase
    {
        /// <summary>
        /// id контракта расписания
        /// </summary>
        [Description("contractId")]
        public int[] ContractIds { get; set; }
        /// <summary>
        /// Текстовый поиск по заголовку расписания (с начала строки)
        /// </summary>
        [Description("scheduleTitle")]
        public string ScheduleTitle { get; set; }

        /// <summary>
        /// текстовый поиск по значениям параметров id, title расписания
        /// </summary>
        [Description("scheduleSearch")]
        public string ScheduleSearch { get; set; }

        /// <summary>
        /// default false — при значении archive=true отдаются только архивные расписания
        /// </summary>
        [Description("archive")]
        public bool? Archive { get; set; }
    }

    public class TimetableTemplatesRequest : TimetablesRequestBase
    {

    }

    public class TimetableTaskRequest : TimetablesRequestBase
    {

        [Description("contractId")]
        public int[] ContractIds { get; set; }

        [Description("status")]
        public ScheduleStatusFilter[] Status { get; set; }
        [Description("scheduleTitle")]
        public string ScheduleTitle { get; set; }
    }

    public class TimetablesStatsRequest : TimetablesRequestBase
    {
        /// <summary>
        /// Текстовый поиск по заголовку расписания (с начала строки)
        /// </summary>
        [Description("scheduleTitle")]
        public string ScheduleTitle { get; set; }

        /// <summary>
        /// Время запуска; формат передачи: time=HH:mm
        /// </summary>
        [Description("time")]
        public string Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Description("status")]
        public ScheduleStatusFilter[] Status { get; set; }

        [Description("contractId")]
        public int[] ContractIds { get; set; }
    }

    public class TimetableRunRequest : TimetablesRequestBase
    {
        /// <summary>
        /// id контракта расписания
        /// </summary>
        [Description("contractId")]
        public int[] ContractIds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("status")]
        public ScheduleStatusFilter[] Status { get; set; }

        /// <summary>
        /// Текстовый поиск по заголовку расписания (с начала строки)
        /// </summary>
        [Description("scheduleTitle")]
        public string ScheduleTitle { get; set; }
    }
}
