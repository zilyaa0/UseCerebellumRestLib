using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CerebellumRestLib.Models;
using Newtonsoft.Json;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using CerebellumRestLib.Models.Events;
using System.Text;
using CerebellumRestLib.Streams;
using System.Threading;
using System.Net;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Models.JSON.Entities;

namespace CerebellumRestLib
{
    public class RequestHandler : IRequestHandler
    {
        private const string API_VERSION = "1.3";

        #region Fields
        private readonly ILogger<RequestHandler> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly Dictionary<string, string> _baseParameters = new Dictionary<string, string>();
        private User _currentUser;
        private HttpClient _client;
        private Dictionary<string, DictionariesChangedEventArgs> _dictionariesStates;
        #endregion

        #region Events
        public event EventHandler<DictionariesChangedEventArgs> DictionariesChanged;
        #endregion

        #region Constructors
        public RequestHandler(
            ILogger<RequestHandler> logger, 
            IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _dictionariesStates = new Dictionary<string, DictionariesChangedEventArgs>
            {
                {"X-Application-Environment-Version-Common", new DictionariesChangedEventArgs{ DictionaryType = EDictionaryType.Common} },
                {"X-Application-Environment-Version-Configuration", new DictionariesChangedEventArgs{ DictionaryType = EDictionaryType.Configuration} },
                {"X-Application-Environment-Version-Organizations", new DictionariesChangedEventArgs{ DictionaryType = EDictionaryType.Organizations} },
                {"X-Application-Environment-Version-Types", new DictionariesChangedEventArgs{ DictionaryType = EDictionaryType.WorkTypes} },
                {"X-Application-Environment-Version-Users", new DictionariesChangedEventArgs{ DictionaryType = EDictionaryType.Users} },
            };
            _baseParameters.Add("apiVersion", API_VERSION);
        }
        #endregion

        #region IRequestHandler
        public void SetUser(User user, string langs)
        {
            _currentUser = user;
            _client = _clientFactory.CreateClient("CerebellumHttp");
            _client.BaseAddress = _currentUser.Uri;
            UpdateToken(user.Token, langs);

            foreach (var item in _dictionariesStates)
            {
                item.Value.ChangedDate = null;
            }
        }
        public void SetCurrentClusterId(int? clusterId)
        {
            _logger.LogInformation($"SetCurrentClusterId: {clusterId}");
            if (clusterId.HasValue)
            {
                if (_baseParameters.ContainsKey("clusterId"))
                    _baseParameters["clusterId"] = clusterId.Value.ToString();
                else
                    _baseParameters.Add("clusterId", clusterId.Value.ToString());
            }
            else
            {
                if (_baseParameters.ContainsKey("clusterId"))
                    _baseParameters.Remove("clusterId");
            }
        }
        public int? GetCurrentClusterId()
        {
            _logger.LogInformation($"GetCurrentClusterId");
            if (_baseParameters.ContainsKey("clusterId"))
                return Convert.ToInt32(_baseParameters["clusterId"]);
            return null;
        }
        public async Task<T> GetJson<T>(string requestUrl, Dictionary<string, string> parameters = null) where T : JsonBase
        {
            _logger.LogTrace($"GET request {requestUrl}");

            _client.SetUserAgent();

            var response = await _client.GetAsync(ConstructUrl(requestUrl, parameters));
            CheckDictionariesChanged(response);
            await response.EnsureSuccessStatusCodeWithResponce();

            var result = await response.Content.ReadAsStringAsync();

            _logger.LogTrace($"GET response {result}");
            return JsonConvert.DeserializeObject<T>(result);
        }
        public async Task<string> GetString(string requestUrl, bool restApi = true, Dictionary<string, string> parameters = null)
        {
            _logger.LogTrace($"GET String request {requestUrl}");
            _client.SetUserAgent();

            var response = await _client.GetAsync(restApi ? ConstructUrl(requestUrl, parameters) : requestUrl);
            await response.EnsureSuccessStatusCodeWithResponce();

            var result = await response.Content.ReadAsStringAsync();

            _logger.LogTrace($"GET response {result}");
            return result;
        }
        public async Task<Stream> DownloadFile(string requestUrl, bool restApi = true, Dictionary<string, string> parameters = null)
        {
            _logger.LogTrace($"GET String request {requestUrl}");
            _client.SetUserAgent();

            var response = await _client.GetAsync(restApi ? ConstructUrl(requestUrl, parameters) : requestUrl);
            await response.EnsureSuccessStatusCodeWithResponce();

            var result = await response.Content.ReadAsStreamAsync();

            _logger.LogTrace($"GET response {result}");
            return result;
        }
        public async Task<T> PostJson<T>(string requestUrl,
                                         Dictionary<string, string> parameters = null,
                                         string body = "")
            where T : JsonBase
        {
            _logger.LogTrace($"POST request {requestUrl}. Body: {body}");
            _client.SetUserAgent();

            var parametersString = new StringContent(body, Encoding.UTF8, "application/json");
            var url = ConstructUrl(requestUrl, parameters);
            var response = await _client.PostAsync(url, parametersString);
            await response.EnsureSuccessStatusCodeWithResponce();

            var result = await response.Content.ReadAsStringAsync();


            _logger.LogTrace($"POST response {requestUrl}. Body: {result}");
            return JsonConvert.DeserializeObject<T>(result);
        }
        public Task PostJson(string requestUrl, string body = "")
        {
            return PostJson(requestUrl, null, body);
        }
        public async Task PostJson(string requestUrl, Dictionary<string, string> parameters = null, string body = "")
        {
            _logger.LogTrace($"POST request {requestUrl}. Body: {body}");
            _client.SetUserAgent();

            var parametersString = new StringContent(body, Encoding.UTF8, "application/json");
            parametersString.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync(ConstructUrl(requestUrl, parameters), parametersString);
            await response.EnsureSuccessStatusCodeWithResponce();
        }
        public async Task PutJson(string requestUrl, string body = "")
        {
            _logger.LogTrace($"PUT request {requestUrl}. Body: {body}");
            _client.SetUserAgent();

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(ConstructUrl(requestUrl), content);
            await response.EnsureSuccessStatusCodeWithResponce();
        }
        public async Task Delete(string requestUrl)
        {
            _logger.LogTrace($"DELETE request {requestUrl}");
            _client.SetUserAgent();

            var response = await _client.DeleteAsync(ConstructUrl(requestUrl));
            await response.EnsureSuccessStatusCodeWithResponce();
        }
        public async Task<T> PutJson<T>(string requestUrl, Dictionary<string, string> parameters = null, string body = "")
        {
            _logger.LogTrace($"PUT request {requestUrl}. Body: {body}");
            _client.SetUserAgent();

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(ConstructUrl(requestUrl, parameters), content);
            await response.EnsureSuccessStatusCodeWithResponce();

            var result = await response.Content.ReadAsStringAsync();

            _logger.LogTrace($"PUT response {requestUrl}. Body: {result}");
            return JsonConvert.DeserializeObject<T>(result);
        }
        public async Task<T> PatchJson<T>(string requestUrl, Dictionary<string, string> parameters = null, string body = "")
        {
            _logger.LogTrace($"PATCH request {requestUrl}. Body: {body}");
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, ConstructUrl(requestUrl, parameters));
            _client.SetUserAgent();

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await _client.SendAsync(request);
            await response.EnsureSuccessStatusCodeWithResponce();

            var result = await response.Content.ReadAsStringAsync();

            _logger.LogTrace($"PATCH response {requestUrl}. Body: {result}");
            return JsonConvert.DeserializeObject<T>(result);
        }
        public async Task<T> UploadFilePost<T>(
            string requestUrl, 
            Stream fileStream, 
            string nameWithExtension = "file.jpg", 
            ProgressDelegate setProgressInfo = null,
            CancellationToken? cancellationToken = null)
        {
            _logger.LogTrace($"UPLOAD request {requestUrl}. Filename: {nameWithExtension}");
            _client.SetUserAgent();
            using (var formContent = new MultipartFormDataContent())
            {
                formContent.Add(CreateFileContent(fileStream, nameWithExtension, setProgressInfo, cancellationToken));

                var response = await _client.PostAsync(ConstructUrl(requestUrl), formContent, cancellationToken ?? CancellationToken.None);
                await response.EnsureSuccessStatusCodeWithResponce();

                var result = await response.Content.ReadAsStringAsync();

                _logger.LogTrace($"UPLOAD response {requestUrl}. Body: {result}");
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
        public async Task<T> UploadFilePut<T>(
            string requestUrl, 
            Stream fileStream, 
            string nameWithExtension = "file.jpg",
            CancellationToken? cancellationToken = null)
        {
            _logger.LogTrace($"UPLOAD request {requestUrl}. Filename: {nameWithExtension}");
            _client.SetUserAgent();

            using (var formContent = new MultipartFormDataContent())
            {
                formContent.Add(CreateFileContent(fileStream, nameWithExtension, null, cancellationToken));

                var response = await _client.PutAsync(ConstructUrl(requestUrl), formContent, cancellationToken?? CancellationToken.None);
                await response.EnsureSuccessStatusCodeWithResponce();

                var result = await response.Content.ReadAsStringAsync();

                _logger.LogTrace($"UPLOAD response {requestUrl}. Body: {result}");
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
        #endregion

        #region Private methods
        private void CheckDictionariesChanged(HttpResponseMessage response)
        {
            foreach (var item in _dictionariesStates)
            {
                if (response.Headers.Contains(item.Key))
                {
                    var dateStr = response.Headers.GetValues(item.Key).FirstOrDefault(w => !string.IsNullOrWhiteSpace(w));
                    long unixTS = long.Parse(dateStr);

                    if (!item.Value.ChangedDate.HasValue)
                    {
                        item.Value.ChangedDate = unixTS;
                    }
                    else if (item.Value.ChangedDate != unixTS)
                    {
                        item.Value.ChangedDate = unixTS;
                        DictionariesChanged?.Invoke(_currentUser, new DictionariesChangedEventArgs
                        {
                            ChangedDate = item.Value.ChangedDate,
                            DictionaryType = item.Value.DictionaryType
                        });
                    }
                }
            }
        }
        private StreamContent CreateFileContent(
            Stream stream, 
            string nameWithExtension = "file.jpg", 
            ProgressDelegate setProgressInfo = null, 
            CancellationToken? cancellationToken = null)
        {
            //Из-за того, что сервер не мог получить расширение файла, при отправке файла не в кодировке ASCII,
            //сервер отправлял новое название файла без расширения (Из-за этой проблемы падали приложения на мобилках)
            nameWithExtension = $"Picture{Path.GetExtension(nameWithExtension)}";

            var fileContent = new ProgressStreamContent(stream, cancellationToken ?? CancellationToken.None);
            if (setProgressInfo != null)
                fileContent.Progress = setProgressInfo;
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"files\"",
                FileName = $"\"{nameWithExtension}\""
            };
            return fileContent;
        }

        private string ConstructUrl(string requestUrl, Dictionary<string, string> parameters = null)
        {
            parameters = parameters ?? new Dictionary<string, string>();

            var url = "rest/" + requestUrl + @"?" + GetString(parameters.ContainsKey("apiVersion")
                                                                ? parameters.Union(_baseParameters.Where(w => w.Key != "apiVersion")) :
                                                                  parameters.Union(_baseParameters));
            return url;
        }

        private string GetString(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            return String.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
        }

        private void UpdateToken(string usertoken, string langs)
        {
            if (_baseParameters.ContainsKey("token"))
            {
                _baseParameters.Remove("token");
            }
            _baseParameters.Add("token", usertoken);

            if(_baseParameters.ContainsKey("lang"))
            {
                _baseParameters.Remove("lang");
            }
            _baseParameters.Add("lang", langs);
        }
        #endregion Private methods
    }
}
