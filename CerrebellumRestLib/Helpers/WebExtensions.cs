using CerebellumRestLib.Models.JSON.Results;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace CerebellumRestLib.Helpers
{
    public class WebException : Exception
    {
        public WebException(string stringResponse, Exception exception, HttpStatusCode statusCode)
            : base(stringResponse, exception)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }

    public static class WebExtensions
    {
        /// <summary>
        /// Строка для подстановки в Заголовок http запроса.
        /// Формат: AppName/AppVersion
        /// </summary>
        public static string UserAgent { get; set; } = Assembly.GetExecutingAssembly().GetName().FullName;
        public static async Task EnsureSuccessStatusCodeWithResponce(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ErrorsResult>(stringResponse);
                    try
                    {
                        response.EnsureSuccessStatusCode();
                    }
                    catch (Exception e)
                    {
                        throw new WebException(result.ErrorDescription, e, response.StatusCode);
                    }
                }
                catch (WebException)
                {
                    throw;
                }
                catch (Exception)
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }
        public static void SetUserAgent(this HttpClient httpClient)
        {
            if (!httpClient.DefaultRequestHeaders.Contains("User-Agent"))
            {
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
            }
        }
    }
}
