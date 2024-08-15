using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.JSON.Entities.Timetables;
using CerebellumRestLib.Models.JSON.Results.Timetables;
using CerebellumRestLib.Models.RequestParams;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface ITimetableServices
    {
        Task<CountableList<Timetable>> GetTimeTables(TimetablesListRequest timetablesListRequest);

        Task<Timetable> GetTimeTable(int timetableId);

        Task<Timetable> AddNewTimeTable(TimetablesCreate timetablesCreate);
        Task<TimetablePreview> GetCreatePreviewTimetable(DateTime date, TimetablesCreate timetablesCreate);

        Task<Timetable> EditTimeTable(int id, TimetablesEdit timetablesEdit);

        Task<TimetablePreview> GetEditPreviewTimetable(int id, DateTime date, TimetablesEdit timetablesEdit);

        Task<TimetableTemplateResult> GetTimetableTemplates(int timetableId, TimetableTemplatesRequest timetableTemplatesRequest);

        Task DeleteTimetable(int timetableId);

        Task<IEnumerable<TimetableTaskInfo>> GetTimetableTasks(int scheduleId, DateTime date, TimetableTaskRequest timetableTaskRequest);

        Task RestartTimetable(int timetableId, DateTime time);

        Task<TimetableStatResult> GetTimetablesStat(DateTime date, TimetablesStatsRequest timetablesStatsRequest);

        Task<IEnumerable<TimetableRun>> GetTimetableRuns(DateTime date, TimetableRunRequest timetableRunRequest);
    }

}