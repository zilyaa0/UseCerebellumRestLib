using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Base;
using CerebellumRestLib.Models.Events;
using CerebellumRestLib.Streams;

namespace CerebellumRestLib
{
    public interface IRequestHandler
    {
        Task<T> GetJson<T>(string requestUrl, Dictionary<string, string> parameters = null) where T : JsonBase;
        Task PostJson(string requestUrl, Dictionary<string, string> parameters = null, string body = "");
        Task PostJson(string requestUrl, string body = "");
        Task<T> PostJson<T>(string requestUrl, Dictionary<string, string> parameters = null, string body = "") where T : JsonBase;
        Task PutJson(string requestUrl, string body = "");
        Task<T> PutJson<T>(string requestUrl, Dictionary<string, string> parameters = null, string body = "");
        Task<T> PatchJson<T>(string requestUrl, Dictionary<string, string> parameters = null, string body = "");
        Task Delete(string requestUrl);
        Task<T> UploadFilePut<T>(string requestUrl, Stream fileStream, string nameWithExtension = "file.jpg", CancellationToken? cancellationToken = null);
        Task<T> UploadFilePost<T>(string requestUrl, Stream fileStream, string nameWithExtension = "file.jpg", ProgressDelegate setProgressInfo = null, CancellationToken? cancellationToken = null);
        Task<Stream> DownloadFile(string requestUrl, bool restApi = true, Dictionary<string, string> parameters = null);
        Task<string> GetString(string requestUrl, bool restApi = true, Dictionary<string, string> parameters = null);

        void SetUser(User user, string langs);
        void SetCurrentClusterId(int? clusterId);
        int? GetCurrentClusterId();

        event EventHandler<DictionariesChangedEventArgs> DictionariesChanged;
    }
}