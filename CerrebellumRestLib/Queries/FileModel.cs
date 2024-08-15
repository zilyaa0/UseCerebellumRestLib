using System;
using System.IO;
using System.Threading.Tasks;
using CerebellumRestLib.Models.Enums;
using CerebellumRestLib.Models.JSON;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Queries
{
    public abstract class FileModel : IFileModel
    {
        private bool _isMainPhoto = false;


        public abstract string FileName { get; }

        public FileType FileType { get; set; }

        public bool? IsMainPhoto
        {
            get => FileType == FileType.Photo ? _isMainPhoto : (bool?)null;
            set => _isMainPhoto = value ?? false;
        }

        public int? StickerId { get; set; }

        public string Description { get; set; }

        public long? CreateDate { get; set; }
        
        public double? SampleMatching { get; set; }

        public long? ParentPhotoId { get; set; }

        public AttachmentInfo AttachmentInfo { get; set; }

        public Origin Origin { get; set; }

        public Author Author { get; set; }

        public abstract Task<T> UseFile<T>(Func<Stream, Task<T>> processor);
    }

    public class LocalFileModel : FileModel
    {
        public FileInfo FileInfo { get; set; }

        public override string FileName 
            => FileInfo.Name;

        public override async Task<T> UseFile<T>(Func<Stream, Task<T>> processor)
        {
            using (var stream = FileInfo.OpenRead())
            {
                return await processor(stream);
            }
        }
    }

    public class StreamFileModel : FileModel
    {
        public StreamFileModel(string fileName)
        {
            FileName = fileName;
        }

        public Stream FileStream { get; set; }

        public override string FileName { get; }

        public override Task<T> UseFile<T>(Func<Stream, Task<T>> processor)
        {
            return processor(FileStream);
        }
    }
}