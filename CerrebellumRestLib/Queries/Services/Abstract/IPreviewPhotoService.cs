using System.Threading.Tasks;
using System.IO;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IPreviewPhotoService
    {
        Task<Stream> DownloadPreviewFile(int taskId, int? width, int? height);
        Task<Stream> DownloadPreviewFile(int taskId);
    }
}
