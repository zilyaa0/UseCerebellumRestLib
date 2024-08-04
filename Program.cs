using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CerebellumRestLib;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Queries;
using CerebellumRestLib.Queries.Static;
using CerebellumRestLib.Helpers;
using System.Linq;
using CerebellumRestLib.Queries.Providers;
using CerebellumRestLib.Queries.Services.Abstract;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Microsoft.Extensions.Logging;
using UseCerebellumRestLib.Services;

namespace UseCerebellumRestLib
{
    internal class Program
    {
        private static ILogger<Program> _logger;
        private static IServiceProvider ServiceProvider { get; set; }

        static async Task Main(string[] args)
        {
            //var serviceCollection = new ServiceCollection();
            //var serviceProvider = serviceCollection.BuildServiceProvider();
            //_taskLogger = serviceProvider.GetService<ILogger<TaskService>>();
            await Test();
            Console.ReadLine();
        }
        public static async Task Test()
        {
            ConfigureServices();
            _logger = ServiceProvider.GetService<ILogger<Program>>();
            Console.WriteLine("Start program");

            var serv = ServiceProvider.GetService<IImapService>();
            serv.ReadLetters();
        }
        private static void ConfigureServices()
        {


            var serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient("CerebellumHttp", httpClint =>
            {
                httpClint.Timeout = TimeSpan.FromMinutes(30);
                httpClint.DefaultRequestHeaders.UserAgent.ParseAdd("TestProject/1.0.0.0");
            }).ConfigureHttpMessageHandlerBuilder((c) =>
                 new HttpClientHandler()
                 {
                     AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                     Proxy = WebRequest.DefaultWebProxy
                 }
);
            serviceCollection.AddSingleton<HttpClient>(provider =>
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
                var httpClint = new HttpClient(handler);
                httpClint.Timeout = TimeSpan.FromMinutes(30);
                httpClint.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.106 Safari/537.36");
                return httpClint;
            });

            serviceCollection.AddSingleton<IImapService, ImapService>();
            serviceCollection.AddTransient<IRequestHandler, RequestHandler>();
            serviceCollection.AddSingleton<IAuthorizationService, AuthorizationService>();
            serviceCollection.AddSingleton<ICurrentUserProvider, CurrentUserProvider>(provider =>
            {
                var authRequests = provider.GetService<IAuthorizationService>();
                var requestHandler = provider.GetService<IRequestHandler>();
                var result = new CurrentUserProvider(provider.GetService<IRequestHandler>());
                var user = authRequests.Authorize(new Uri("https://am544.test.geo4.pro/"), "m_zilyaa", "12345678").Result;
                result.UpdateUser(user);

                _logger.LogDebug("Complited.");
                return result;
            });
            serviceCollection.AddTransient<IDictionariesService, DictionariesService>();
            serviceCollection.AddTransient<ITasksServiceV2, TasksServiceV2>();
            serviceCollection.AddSingleton<IOrganizationsService, OrganizationsService>();
            serviceCollection.AddSingleton<IContractsService, ContractsService>();
            serviceCollection.AddTransient<IUsersService, UsersService>();

            serviceCollection.AddOptions();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
