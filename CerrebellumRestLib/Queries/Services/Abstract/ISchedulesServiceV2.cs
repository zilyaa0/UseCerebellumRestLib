using CerebellumRestLib.Models;
using CerebellumRestLib.Models.JSON.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface ISchedulesServiceV2
    {
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
        /// Изменение расписания
        /// </summary>
        /// <param name="scheduleId">Id расписания</param>
        /// <param name="scheduleEdit">Измененное расписание</param>
        /// <returns></returns>
        Task<ScheduleAdded> UpdateSchedule(int scheduleId, ScheduleEdit scheduleEdit);
        /// <summary>
        /// Перезапустить запуск
        /// </summary>
        /// <param name="scheduleId">Id расписания</param>
        /// <param name="time">Дата перезапуска</param>
        /// <returns></returns>
        Task RestartSchedule(int scheduleId, DateTime time);
    }
}
