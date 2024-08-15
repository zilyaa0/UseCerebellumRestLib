using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CerebellumRestLib.Models.Enums;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Requests;
using CerebellumRestLib.Streams;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IAttachmentsService
    {
        Task AddFiles(int taskUnitId, params FileModel[] files);
        Task AssignStickers(int taskUnitId, IEnumerable<AssignedSticker> stickers);
        Task<List<FileEntry>> GetAllFiles(int taskUnitId);
        Task<List<FileEntry>> GetFiles(int taskUnitId, FileType type);
        Task<List<StickerInfo>> GetStickers();
        Task RemoveFile(int taskUnitId, int fileId, FileType fileType);
        Task<IEnumerable<Attachment>> UploadFiles(FileModel[] files, ProgressDelegate setProgressInfo = null, CancellationToken? cancellationToken = null);
        Task<Stream> DownloadFile(string url);

        Task AssignAttachments(int taskUnitId, IEnumerable<Attachment> attachments);
    }
}