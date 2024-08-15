using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface ISchedulesService
    {
        /// <summary>
        /// Получение списка расписании
        /// </summary>
        /// <param name="scheduleListRequest">Фильтр расписании</param>
        /// <returns></returns>
        Task<CountableList<Schedule>> GetSchedules(ScheduleListRequest scheduleListRequest);
        /// <summary>
        /// Получение конкретного засписания
        /// </summary>
        /// <param name="scheduleId">Id расписания</param>
        /// <returns></returns>
        Task<Schedule> GetSchedule(int scheduleId);
        /// <summary>
        /// Получение списка архивных расписании
        /// </summary>
        /// <param name="scheduleListRequest">Фильтр расписании</param>
        /// <returns></returns>
        Task<CountableList<Schedule>> GetArchiveSchedules(ScheduleListRequest scheduleListRequest);
        /// <summary>
        /// Получение списка шаблонов расписания
        /// </summary>
        /// <param name="scheduleId">Id расписания</param>
        /// <param name="scheduleTemplatesRequest">Фильтр расписании</param>
        /// <returns></returns>
        Task<ScheduleTemplateResult> GetScheduleTemplates(int scheduleId, ScheduleTemplatesRequest scheduleTemplatesRequest);
        /// <summary>
        /// Добавление нового расписания
        /// </summary>
        /// <param name="scheduleCreate">Новое расписание</param>
        /// <returns></returns>
        Task<ScheduleAdded> AddNewSchedule(ScheduleCreate scheduleCreate);
        /// <summary>
        /// Изменение расписания
        /// </summary>
        /// <param name="scheduleId">Id расписания</param>
        /// <param name="scheduleEdit">Измененное расписание</param>
        /// <returns></returns>
        Task<ScheduleAdded> UpdateSchedule(int scheduleId, ScheduleEdit scheduleEdit);
        /// <summary>
        /// Удаление расписания
        /// </summary>
        /// <param name="scheduleId">Id расписания</param>
        /// <returns></returns>
        Task DeleteSchedule(int scheduleId);
        /// <summary>
        /// Получение статистики по расписаниям
        /// </summary>
        /// <param name="scheduleStatRequest">Фильт расписании</param>
        /// <returns></returns>
        Task<ScheduleStat> GetSchedulesStat(ScheduleStatRequest scheduleStatRequest);
        /// <summary>
        /// Получение списка запусков расписаний 
        /// </summary>
        /// <param name="scheduleRunRequest">Фильт расписании</param>
        /// <returns></returns>
        Task<IEnumerable<ScheduleRun>> GetScheduleRuns(ScheduleRunRequest scheduleRunRequest);
        /// <summary>
        /// Получение списка заданий по расписанию 
        /// </summary>
        /// <param name="scheduleTaskRequest">Фильт расписании</param>
        /// <returns></returns>
        Task<IEnumerable<ScheduleTasks>> GetScheduleTasks(ScheduleTaskRequest scheduleTaskRequest);
        /// <summary>
        /// Получение списка дат запуска расписания
        /// </summary>
        /// <param name="scheduleId">Id расписания</param>
        /// <param name="from">Дата начала временного интервала</param>
        /// <param name="till">Дата окончания  временного интервала</param>
        /// <param name="page">Номер запрашиваемой страницы</param>
        /// <param name="limit">Количество записей на странице</param>
        /// <returns></returns>
        Task<ScheduleDates> GetScheduleDates(int scheduleId, DateTimeOffset from, DateTimeOffset till, int page = 1, int limit = 1000000);
    }
}