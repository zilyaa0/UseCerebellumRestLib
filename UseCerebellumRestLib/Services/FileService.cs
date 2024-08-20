using CerebellumRestLib.Models.Enums;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Queries.Services;
using CerebellumRestLib.Queries;
using CerebellumRestLib.Queries.Services.Abstract;
using MailKit;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UseCerebellumRestLib.Services
{
    #region Interface
    public interface IFileService
    {
        Task<IEnumerable<Attachment>> UploadFiles(IMessageSummary messageSummary, IMailFolder mailFolder);
    }
    #endregion
    internal class FileService : IFileService
    {
        #region Fields
        private readonly ILogger<FileService> _logger;
        private readonly IAttachmentsService _attachmentsService;
        #endregion

        #region Constructor
        public FileService(ILogger<FileService> logger, IAttachmentsService attachmentsService)
        {
            _logger = logger;
            _attachmentsService = attachmentsService;
        }
        #endregion

        #region Public Methods
        public async Task<IEnumerable<Attachment>> UploadFiles(IMessageSummary messageSummary, IMailFolder mailFolder)
        {
            var files = new List<StreamFileModel>();
            foreach (var attachment in messageSummary.Attachments.OfType<BodyPartBasic>())
            {
                var fileModel = new StreamFileModel(attachment.FileName) { FileType = Path.GetExtension(attachment.FileName) == ".jpg" || Path.GetExtension(attachment.FileName) == ".png" ? FileType.Photo : FileType.File };
                var part = (MimePart)mailFolder.GetBodyPart(messageSummary.UniqueId, attachment);
                var stream = new MemoryStream();
                await part.Content.DecodeToAsync(stream);
                stream.Position = 0;
                fileModel.FileStream = stream;
                files.Add(fileModel);
            }

            return await _attachmentsService.UploadFiles(files.ToArray());
        }
        #endregion
    }
}
