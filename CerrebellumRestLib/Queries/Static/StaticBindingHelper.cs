using System.Net.Http;
using CerebellumRestLib.Helpers;
using Microsoft.Extensions.Logging;

namespace CerebellumRestLib.Queries.Static
{
    internal static class StaticBindingHelper
    {
        private static readonly LoggerFactory _loggerFactory;
        private static readonly HttpClient _httpClient = new HttpClient();

        static StaticBindingHelper()
        {
            _loggerFactory = new LoggerFactory();
            _loggerFactory
                .AddConsole()
                .AddDebug();
        }

        public static ILogger<T> GetLogger<T>() 
            => _loggerFactory.CreateLogger<T>();

        public static HttpClient GetHttpClient() 
            => _httpClient;
    }
}
