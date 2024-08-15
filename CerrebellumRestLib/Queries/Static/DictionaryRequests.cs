using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services;

namespace CerebellumRestLib.Queries.Static
{
    public class DictionaryRequests : DictionariesService
    {
        public DictionaryRequests(ICurrentUserProvider currentUser) 
            : base(currentUser, StaticBindingHelper.GetLogger<DictionariesService>())
        {

        }
    }
}
