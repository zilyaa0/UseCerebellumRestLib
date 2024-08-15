using System.Threading.Tasks;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IServiceObjectsService
    {
        Task<string> SeachServiceObject(string serchText, double? lan = null, double? lot = null);
    }
}
