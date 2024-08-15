using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.Enums;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Requests;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Queries.Services.Abstract;
using Static = CerebellumRestLib.Queries.Static;
using Microsoft.Extensions.Logging;
using CerebellumRestLib.Queries.Providers.Abstract;
using System.IO;
using CerebellumRestLib.Streams;
using System.Threading;

namespace CerebellumRestLib.Queries.Services
{
    public class AttachmentsService : IAttachmentsService
    {
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<AttachmentsService> _logger;

        public AttachmentsService(ICurrentUserProvider currentUser,
                                  ILogger<AttachmentsService> logger = null)
        {
            _currentUser = currentUser;
            _logger = logger ?? Static.StaticBindingHelper.GetLogger<AttachmentsService>();
        }

        #region IAttachmentsService
        public async Task AddFiles(int taskUnitId, params FileModel[] files)
        {
            try
            {
                var attachments = new List<Attachment>();

                foreach (var fileModel in files)
                {
                    var loadedName = await UploadFile(fileModel, fileModel.FileType);
                    attachments.Add(MapFileModelToAttachment(fileModel, loadedName));
                }

                await AssignAttachments(taskUnitId, attachments);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<IEnumerable<Attachment>> UploadFiles(
            FileModel[] files, 
            ProgressDelegate setProgressInfo = null, 
            CancellationToken? cancellationToken = null)
        {
            try
            {
                var attachments = new List<Attachment>();

                foreach (var fileModel in files)
                {
                    var loadedName = await UploadFile(fileModel, fileModel.FileType, setProgressInfo, cancellationToken);
                    attachments.Add(MapFileModelToAttachment(fileModel, loadedName));
                }

                return attachments;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<Stream> DownloadFile(string url)
        {
            try
            {
                return await _currentUser.GetRequestHandler().DownloadFile(url, false);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task RemoveFile(int taskUnitId, int fileId, FileType fileType)
        {
            try
            {
                await _currentUser.GetRequestHandler().PostJson($"news/{taskUnitId}/{GetFilePath(fileType)}/{fileId}", body: "{ \"action\": \"delete\" }");
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<List<FileEntry>> GetFiles(int taskUnitId, FileType type)
        {
            try
            {
                var url = $"news/{taskUnitId}/{GetFilePath(type)}";

                FilesBase filesContainer;
                switch (type)
                {
                    default:
                    case FileType.File:
                        filesContainer = await _currentUser.GetRequestHandler().GetJson<Files>(url);
                        break;
                    case FileType.Photo:
                        filesContainer = await _currentUser.GetRequestHandler().GetJson<Photos>(url);
                        break;
                    case FileType.Sound:
                        filesContainer = await _currentUser.GetRequestHandler().GetJson<Sounds>(url);
                        break;
                    case FileType.Video:
                        var videos = await _currentUser.GetRequestHandler().GetJson<Videos>($"news/{taskUnitId}/{GetFilePath(type)}");
                        var difvideos = await _currentUser.GetRequestHandler().GetJson<DifVideos>($"news/{taskUnitId}/difvideo");

                        filesContainer = new Videos();
                        filesContainer.FileEntries = videos.FileEntries.Union(difvideos.FileEntries).GroupBy(w=>w.Id).Select(w=>w.First()).ToList();
                        break;
                }

                filesContainer.FileEntries.ForEach(x => x.FileType = type);

                return filesContainer.FileEntries;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<List<FileEntry>> GetAllFiles(int taskUnitId)
        {
            try
            {
                var tasks = ((FileType[])Enum.GetValues(typeof(FileType))).Select(x => GetFiles(taskUnitId, x)).ToList();

                await Task.WhenAll(tasks);

                return tasks.SelectMany(x => x.Result).ToList();
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task<List<StickerInfo>> GetStickers()
        {
            try
            {
                var result = await _currentUser.GetRequestHandler().GetJson<StickersResult>("sticker/list");

                return result.Stickers;
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        /// <summary>
        /// Full assignment is requered, all others assignments will be removed.
        /// </summary>
        /// <param name="taskUnitId">Task id.</param>
        /// <param name="stickers">Set of file-sticker pair. Only one sticker can be assigned to one file.</param>
        public async Task AssignStickers(int taskUnitId, IEnumerable<AssignedSticker> stickers)
        {
            try
            {

                var assignStickersRequest = new AssignStickersRequest { AssignedStickers = stickers };
                await _currentUser.GetRequestHandler().PutJson($"news/{taskUnitId}/stickers", assignStickersRequest.ToJson());
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        public async Task AssignAttachments(int taskUnitId, IEnumerable<Attachment> attachments)
        {
            var requestBody = new AttachmentsRequest { Attachments = attachments.ToArray() };

            await _currentUser.GetRequestHandler().PostJson($"news/{taskUnitId}/update/", body: requestBody.ToJson());
        }
        #endregion

        #region Private Methods
        private static Attachment MapFileModelToAttachment(FileModel fileModel, string loadedName)
    => new Attachment
    {
        Description = fileModel.Description,
        File = loadedName,
        FileName = fileModel.FileName,
        FileType = fileModel.FileType,
        MainPhoto = fileModel.IsMainPhoto,
        StickerId = fileModel.StickerId,
        AttachmentInfo = fileModel.AttachmentInfo,
        Author = fileModel.Author,
        CreateDate = fileModel.CreateDate,
        Origin = fileModel.Origin,
        SampleMatching = fileModel.SampleMatching,
        ParentPhotoId = fileModel.ParentPhotoId,
    };
        private async Task<string> UploadFile(
            FileModel fileModel, 
            FileType type, 
            ProgressDelegate setProgressInfo = null,
            CancellationToken? cancellationToken = null)
        {
            return await fileModel.UseFile(async stream =>
            {
                var result = await _currentUser.GetRequestHandler().UploadFilePost<UploadResponse>(
                    $"upload/{GetFilePathNew(type)}", 
                    stream, 
                    fileModel.FileName, 
                    setProgressInfo,
                    cancellationToken);
                return result.Name;
            });
        }
        private static string GetFilePathNew(FileType type)
        {
            string path;
            switch (type)
            {
                default:
                case FileType.File:
                    path = "files";
                    break;
                case FileType.Photo:
                    path = "photos";
                    break;
                case FileType.Sound:
                    path = "sounds";
                    break;
                case FileType.Video:
                    path = "videos";
                    break;
            }

            return path;
        }
        private static string GetFilePath(FileType type)
        {
            string path;
            switch (type)
            {
                default:
                case FileType.File:
                    path = "files";
                    break;
                case FileType.Photo:
                    path = "photos";
                    break;
                case FileType.Sound:
                    path = "sounds";
                    break;
                case FileType.Video:
                    path = "video";
                    break;
            }

            return path;
        } 
        #endregion
    }
}