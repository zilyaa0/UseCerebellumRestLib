using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using CerebellumRestLib.Helpers;
using System.Threading.Tasks;
using System.IO;
using System;

namespace CerebellumRestLib.Queries.Services
{
    public class PreviewPhotoService : IPreviewPhotoService
    {
        #region Fields
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<PreviewPhotoService> _logger;
        #endregion


        #region Constructor
        public PreviewPhotoService(ILogger<PreviewPhotoService> logger,
                                   ICurrentUserProvider currentUser)
        {
            _logger = logger;
            _currentUser = currentUser;
        }
        #endregion

        #region IPreviewPhotoService
        public async Task<Stream> DownloadPreviewFile(int taskId)
        {
            try
            {
                var url = $"tasks/{taskId}/photos/main";

                return await _currentUser.GetRequestHandler().DownloadFile(url);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                return null;
            }
        }

        public async Task<Stream> DownloadPreviewFile(int taskId, int? width, int? height)
        {
            try
            {
                if (!width.HasValue)
                {
                    width = 100;
                }

                if (!height.HasValue)
                {
                    height = 100;
                }

                var url = $"tasks/{taskId}/photos/main/crop/w{width}/h{height}";

                return await _currentUser.GetRequestHandler().DownloadFile(url);
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                return null;
            }
        }
        #endregion
    }
}
