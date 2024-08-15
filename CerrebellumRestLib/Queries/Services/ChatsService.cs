using CerebellumRestLib.Helpers;
using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services
{
    public class ChatsService : IChatsService
    {
        #region Fields
        private readonly ILogger<ChatsService> _logger;
        private readonly ICurrentUserProvider _currentUser;
        #endregion

        #region Constructor
        public ChatsService(ILogger<ChatsService> logger,
                            ICurrentUserProvider currentUser)
        {
            _logger = logger;
            _currentUser = currentUser;
        }
        #endregion

        #region IChatsService
        public async Task ReadMessage(int chatId, int messageId)
        {
            try
            {
                await _currentUser.GetRequestHandler().PostJson($"chats/{chatId}/messages/{messageId}/read", "{}");
            }
            catch (Exception ex)
            {
                _logger.LogMethodError(ex, nameof(ReadMessage));
                throw;
            }
        } 
        #endregion
    }
}
