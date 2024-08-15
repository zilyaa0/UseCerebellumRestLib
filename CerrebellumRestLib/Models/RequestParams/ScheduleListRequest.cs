using CerebellumRestLib.Models.Base.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;

namespace CerebellumRestLib.Models
{
    public abstract class ScheduleRequestBase: PageableRequestBase
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

        /// <summary>
        /// Текстовый поиск по заголовку расписания (с начала строки)
        /// </summary>
        [Description("scheduleTitle")]
        public string ScheduleTitle { get; set; }

        [Description("contractId")]
        public int[] ContractIds { get; set; }
    }
    public class ScheduleListRequest : ScheduleRequestBase
    {
        /// <summary>
        /// Дата начала временного интервала (включительно)
        /// </summary>
        [Description("datesFrom")]
        public long? DatesFrom { get; set; }

        /// <summary>
        /// Дата окончания временного интервала (не включительно)
        /// </summary>
        [Description("datesTill")]
        public long? DatesTill { get; set; }

        /// <summary>
        /// Образцы шаблонов
        /// </summary>
        [Description("sampleTemplates")]
        public bool? SampleTemplates { get; set; }
    }
    public class ScheduleStatRequest : UrlRequestBase
    {
        /// <summary>
        /// /// Дата начала временного интервала (включительно)
        /// /// </summary>
        [Description("from")]
        public long? From { get; set; }

        /// <summary>
        /// Дата окончания временного интервала (не включительно)
        /// </summary>
        [Description("till")]
        public long? Till { get; set; }

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
        /// Id видов работ
        /// </summary>
        [Description("scheduleId")]
        public int[] ScheduleId { get; set; }

        /// <summary>
        /// Текстовый поиск по заголовку задания (с начала строки)
        /// </summary>
        [Description("taskTitle")]
        public string TaskTitle { get; set; }

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
    public class ScheduleRunRequest : ScheduleRequestBase
    {
        /// <summary>
        /// /// Дата начала временного интервала (включительно)
        /// /// </summary>
        [Description("from")]
        public long? From { get; set; }

        /// <summary>
        /// Дата окончания временного интервала (не включительно)
        /// </summary>
        [Description("till")]
        public long? Till { get; set; }

        /// <summary>
        /// Id видов работ
        /// </summary>
        [Description("scheduleId")]
        public int[] ScheduleId { get; set; }

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

    }
    public class ScheduleTaskRequest : ScheduleRequestBase
    {
        /// <summary>
        /// /// Дата начала временного интервала (включительно)
        /// /// </summary>
        [Description("from")]
        public long? From { get; set; }

        /// <summary>
        /// Дата окончания временного интервала (не включительно)
        /// </summary>
        [Description("till")]
        public long? Till { get; set; }

        /// <summary>
        /// Id расписании
        /// </summary>  
        [Description("scheduleId")]
        public int[] ScheduleId { get; set; }

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
    }
    public class ScheduleTemplatesRequest : PageableRequestBase
    {
        /// <summary>
        /// /// Дата начала временного интервала (включительно)
        /// /// </summary>
        [Description("from")]
        public long? From { get; set; }

        /// <summary>
        /// Дата окончания временного интервала (не включительно)
        /// </summary>
        [Description("till")]
        public long? Till { get; set; }

        /// <summary>
        /// Id организации шаблона
        /// </summary>
        [Description("organizationId")]
        public int[] OrganizationId { get; set; }

        /// <summary>
        /// Id видов работ
        /// </summary>
        [Description("typeId")]
        public int[] WorkTypeId { get; set; }

        /// <summary>
        /// Id назначенного пользователя
        /// </summary>
        [Description("assignedUserId")]
        public int[] AssignedUserId { get; set; }

        /// <summary>
        /// Текстовый поиск по заголовку задания (с начала строки)
        /// </summary>
        [Description("taskTitle")]
        public string TaskTitle { get; set; }

        /// <summary>
        /// Id организации; если у расписания задана организация, то фильтр накладывается на расписание, иначе на шаблоны
        /// </summary>
        [Description("assignedOrganizationId")]
        public int[] AssignedOrganizationId { get; set; }
    }

    public enum ScheduleStatusFilter
    {
        /// <summary>
        /// Выключенные задания
        /// </summary>
        [Description("off")]
        Off,
        /// <summary>
        /// Не создано из-за ошибок
        /// </summary>
        [Description("fail")]
        Fail,
        /// <summary>
        /// Создание просрочено (более 15 мин назад)
        /// </summary>
        [Description("missed")]
        Missed,
        /// <summary>
        /// Создающиеся задания
        /// </summary>
        [Description("creating")]
        Created,
        /// <summary>
        /// Запланированные задания
        /// </summary>
        [Description("planned")]
        Planned,
        /// <summary>
        /// Просроченные задания, находящиеся в стадии 2 - завершено
        /// </summary>
        [Description("done_expired")]
        DoneExpired,
        /// <summary>
        /// Непросроченные задания, находящиеся в стадии 2 - завершено
        /// </summary>
        [Description("done_not_expired")]
        DoneNotExpired,
        /// <summary>
        /// Просроченные задания, находящиеся в стадии 0 - отклонено
        /// </summary>
        [Description("rejected_expired")]
        RejectedExpired,
        /// <summary>
        /// Непросроченные задания, находящиеся в стадии 0 - отклонено
        /// </summary>
        [Description("rejected_not_expired")]
        RejectedNotExpired,
        /// <summary>
        /// Просроченные задания, находящиеся в стадии 1 - в работе
        /// </summary>
        [Description("working_expired")]
        WorkingExpired,
        /// <summary>
        /// Непросроченные задания, находящиеся в стадии 1 - в работе
        /// </summary>
        [Description("working_not_expired")]
        WorkingNotExpired
    }
}