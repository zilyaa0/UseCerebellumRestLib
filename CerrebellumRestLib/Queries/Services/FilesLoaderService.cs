using CerebellumRestLib.Helpers;
using CerebellumRestLib.Models.Enums;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using CerebellumRestLib.Streams;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class FilesLoaderService : IFilesLoaderService
    {
        #region Fields
        private readonly ICurrentUserProvider _currentUser;
        private readonly ILogger<FilesLoaderService> _logger;
        #endregion

        #region Constructor
        public FilesLoaderService(ICurrentUserProvider currentUser,
                                  ILogger<FilesLoaderService> logger)
        {
            _currentUser = currentUser;
            _logger = logger;
        }
        #endregion


        #region IFilesLoaderService
        public async Task<string> UploadFiles(FileModel fileModel, ProgressDelegate setProgressInfo = null)
        {
            try
            {
                return await fileModel.UseFile(async stream =>
                {
                    var result = await _currentUser.GetRequestHandler().UploadFilePost<UploadResponse>(
                        $"files/upload",
                        stream,
                        fileModel.FileName,
                        setProgressInfo);
                    return result.Name;
                });
            }
            catch (Exception e)
            {
                _logger.LogMethodError(e);
                throw;
            }
        }
        #endregion
    }
}
