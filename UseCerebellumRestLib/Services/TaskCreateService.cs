using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.JSON.Entities.V2;
using CerebellumRestLib.Queries.Services;
using CerebellumRestLib.Queries.Services.Abstract;
using MailKit;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCerebellumRestLib.Models.Settings;
using static System.Net.Mime.MediaTypeNames;

namespace UseCerebellumRestLib.Services
{
    #region Interface
    public interface ITaskCreateService
    {
        Task CreateTask(IMessageSummary messageSummary, IMailFolder mailFolder);
    }
    #endregion
    internal class TaskCreateService : ITaskCreateService
    {
        #region Fields
        private readonly ILogger<TaskCreateService> _logger;
        private readonly ITasksServiceV2 _tasksService;
        private readonly IOrganizationsService _organizationsService;
        private readonly IFileService _fileServices;
        private readonly IDbService _dbService;
        private readonly AppSettings _appSettings;
        #endregion

        #region Constructor
        public TaskCreateService(ILogger<TaskCreateService> logger, ITasksServiceV2 tasksService, IOrganizationsService organizationsService, IFileService fileServices, AppSettings appSettings, IDbService dbService)
        {
            _logger = logger;
            _tasksService = tasksService;
            _organizationsService = organizationsService;
            _fileServices = fileServices;
            _appSettings = appSettings;
            _dbService = dbService;
        }
        #endregion

        #region Public Metods
        public async Task CreateTask(IMessageSummary messageSummary, IMailFolder mailFolder)
        {
            _logger.LogInformation($"Create new task from letter: {messageSummary.UniqueId}");
            var organizations = await _organizationsService.GetOrganizations(true);
            var body = messageSummary.TextBody;
            var bodyPart = (TextPart)mailFolder.GetBodyPart(messageSummary.UniqueId, body);

            var taskCreate = new TaskCreate();
            taskCreate.TaskDate = DateTime.Now.GetUnixTime();
            taskCreate.WorkTypeId = _appSettings.WorkTypeGroupId;
            taskCreate.PriorityId = _appSettings.PriorityId;
            taskCreate.Title = messageSummary.Envelope.Subject;
            taskCreate.Text = bodyPart.Text.Replace(Environment.NewLine, " ");
            taskCreate.OrganizationId = organizations.FirstOrDefault().Id;
            taskCreate.Attachments = await _fileServices.UploadFiles(messageSummary);

            var createdTask = await _tasksService.AddTask(taskCreate);
            await _dbService.InsetTask(messageSummary.UniqueId.ToString(), createdTask.TaskId);
        }
        #endregion
    }
}
