using CerebellumRestLib.Models.JSON.Entities.V2;
using CerebellumRestLib.Models;
using CerebellumRestLib.Queries.Services.Abstract;
using MailKit.Search;
using MailKit.Security;
using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using CerebellumRestLib.Queries;
using CerebellumRestLib.Models.JSON.Entities;
using System.IO;
using CerebellumRestLib.Models.Enums;
using Microsoft.Extensions.Logging;
using UseCerebellumRestLib.Models.Settings;

namespace UseCerebellumRestLib.Services
{
    #region Interface
    public interface ILetterService
    {
         void ReadLetters();
    }
    #endregion
    class LetterService : ILetterService
    {
        #region Fields
        private readonly ILogger<LetterService> _logger;
        private readonly ITaskCreateService _taskCreateService;
        private readonly IDbService _dbService;
        private readonly AppSettings _appSettings;
        #endregion

        #region Constructor
        public LetterService(ILogger<LetterService> logger, AppSettings appSettings, ITaskCreateService taskCreateService, IDbService dbService)
        {
            _logger = logger;
            _appSettings = appSettings;
            _taskCreateService = taskCreateService;
            _dbService = dbService;
        }
        #endregion

        #region Public Methods
        public void ReadLetters()
        {
            Thread thread = new Thread(async () =>
            {
                while (true)
                {
                    try
                    {
                        using (var client = new ImapClient())
                        {
                            client.Connect("imap.mail.ru", 993, SecureSocketOptions.SslOnConnect);

                            client.Authenticate(_appSettings.MailSettings.Email, _appSettings.MailSettings.Password);

                            var inbox = client.Inbox;
                            inbox.Open(FolderAccess.ReadOnly);
                            var uids = inbox.Search(SearchQuery.All);
                            var items = inbox.Fetch(uids, MessageSummaryItems.Envelope | MessageSummaryItems.BodyStructure);
                            for (int i = 0; i < items.Count; i++)
                            {
                                if (await _dbService.FindLetterByMessageId(items[i].UniqueId.ToString()) == false)
                                await _taskCreateService.CreateTask(items[i], inbox);
                            }
                            client.Disconnect(true);
                        }
                    }
                    catch
                    {
                        return;
                    }
                    Thread.Sleep(1000 * 60);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion
    }
}
