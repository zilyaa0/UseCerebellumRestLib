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

namespace UseCerebellumRestLib.Services
{
    #region interface
    public interface IImapService
    {
        void ReadLetters();
    }
    #endregion
    class ImapService : IImapService
    {
        #region fields
        private readonly ITasksServiceV2 tasksService;
        private readonly IOrganizationsService organizationsService;
        private readonly IContractsService contractsService;

        public ImapService(ITasksServiceV2 _tasksService, IOrganizationsService _organizationsService, IContractsService _contractsService)
        {
            tasksService = _tasksService;
            organizationsService = _organizationsService;
            contractsService = _contractsService;
        }
        #endregion


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

                            client.Authenticate(ConfigurationManager.AppSettings["Email"], ConfigurationManager.AppSettings["Password"]);

                            var inbox = client.Inbox;
                            inbox.Open(FolderAccess.ReadOnly);
                            var uids = inbox.Search(SearchQuery.All);
                            var items = inbox.Fetch(uids, MessageSummaryItems.Envelope | MessageSummaryItems.BodyStructure);
                            for (int i = 0; i < items.Count; i++)
                            {
                                var bodyPart = items[i].TextBody;
                                var body = (TextPart)inbox.GetBodyPart(items[i].UniqueId, bodyPart);
                                var organizations = await organizationsService.GetOrganizations(true);
                                var contracts = await contractsService.GetСontracts(new ContractListRequest() { Limit = 5, Page = 1 });
                                var task = new TaskCreate()
                                {
                                    Title = items[i].Envelope.Subject,
                                    Text = body.Text.Replace(Environment.NewLine, " "),
                                    WorkTypeId = Convert.ToInt32(ConfigurationManager.AppSettings["TypeId"]),
                                    PriorityId = Convert.ToInt32(ConfigurationManager.AppSettings["PriorityId"]),
                                    TaskDate = DateTime.Now.Ticks,
                                    OrganizationId = organizations.FirstOrDefault().Id
                                };
                                tasksService.AddTask(task);
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
    }
}
