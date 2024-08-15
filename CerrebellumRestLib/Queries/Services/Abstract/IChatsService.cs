using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IChatsService
    {
        Task ReadMessage(int chatId, int messageId);
    }
}
