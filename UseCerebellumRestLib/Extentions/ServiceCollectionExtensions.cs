using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Providers;
using CerebellumRestLib.Queries.Services.Abstract;
using CerebellumRestLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UseCerebellumRestLib.Models.Settings;
using CerebellumRestLib.Queries.Services;
using MailKit;
using UseCerebellumRestLib.Services;

namespace UseCerebellumRestLib.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static ServiceProvider AddServices(this IServiceCollection serviceCollection, IConfigurationRoot configuration)
        {
            var appSettings = new AppSettings();
            configuration.GetSection("AppSettings").Bind(appSettings);
            serviceCollection.AddSingleton(appSettings);
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                loggingBuilder.AddNLog(configuration);
            });

            serviceCollection.AddHttpClient("CerebellumHttp", httpClint =>
            {
                httpClint.Timeout = TimeSpan.FromMinutes(30);
                httpClint.DefaultRequestHeaders.UserAgent.ParseAdd("MailIntegration/1.0.0.0");
            }).ConfigureHttpMessageHandlerBuilder((c) =>
                 new HttpClientHandler()
                 {
                     AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                     Proxy = WebRequest.DefaultWebProxy
                 });

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

            serviceCollection.AddSingleton<ICurrentUserProvider, CurrentUserProvider>(provider =>
            {
                var authRequests = provider.GetService<IAuthorizationService>();
                var requestHandler = provider.GetService<IRequestHandler>();
                var result = new CurrentUserProvider(provider.GetService<IRequestHandler>());
                var user = authRequests.Authorize(new Uri(appSettings.CerebellumSettings.Host), appSettings.CerebellumSettings.Login, appSettings.CerebellumSettings.Password).Result;
                result.UpdateUser(user); 
                return result;
            });

            serviceCollection.AddSingleton<ILetterService, LetterService>();
            serviceCollection.AddSingleton<IDbService, DbService>();
            serviceCollection.AddSingleton<IFileService, FileService>();
            serviceCollection.AddSingleton<ITaskCreateService, TaskCreateService>();
            serviceCollection.AddTransient<IRequestHandler, RequestHandler>();
            serviceCollection.AddSingleton<IAuthorizationService, AuthorizationService>();
            serviceCollection.AddTransient<IDictionariesService, DictionariesService>();
            serviceCollection.AddTransient<ITasksServiceV2, TasksServiceV2>();
            serviceCollection.AddSingleton<IOrganizationsService, OrganizationsService>();
            serviceCollection.AddSingleton<IContractsService, ContractsService>();
            serviceCollection.AddSingleton<IAttachmentsService, AttachmentsService>();
            serviceCollection.AddTransient<IUsersService, UsersService>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
