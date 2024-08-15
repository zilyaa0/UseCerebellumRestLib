using System;
using System.IO;
using System.Threading.Tasks;
using CerebellumRestLib.Models.Enums;

namespace CerebellumRestLib.Queries
{
    public interface IFileModel
    {
        string Description { get; set; }
        string FileName { get; }
        FileType FileType { get; set; }
        bool? IsMainPhoto { get; set; }
        int? StickerId { get; set; }

        Task<T> UseFile<T>(Func<Stream, Task<T>> processor);
    }
}