using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Streams;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IFilesLoaderService
    {
        Task<string> UploadFiles(FileModel files, ProgressDelegate setProgressInfo = null);
    }
}
