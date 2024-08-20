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
using Microsoft.Extensions.Configuration;
using NLog;
using UseCerebellumRestLib.Extentions;

namespace UseCerebellumRestLib
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var logFactory = LogManager.Setup().LoadConfigurationFromFile(GetNlogConfig());
            var logger = logFactory.GetCurrentClassLogger();
            logger.Info("Init main");
            var serviceCollection = new ServiceCollection();
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("Configurations/AppSettings.json", true, true);
            var serviceProvider = serviceCollection.AddServices(configBuilder.Build());

#if !DEBUG
            try
            {
                serviceProvider.RunMonitoring();
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Error in send monitoring: {ex.Message}");
            }
#endif
            await Start(serviceProvider);
            Console.ReadLine();
        }
        public static async Task Start(ServiceProvider serviceProvider)
        {
            var letterService = serviceProvider.GetService<ILetterService>();
            letterService.ReadLetters();
        }
        private static string GetNlogConfig()
        {
#if DEBUG
            return "Configurations/nlog.debug.config";
#endif
            return "Configurations/nlog.config";
        }
    }
}
