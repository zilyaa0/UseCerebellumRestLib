using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services;

namespace CerebellumRestLib.Queries.Static
{
    public class UsersRequests : UsersService
    {
        public UsersRequests(ICurrentUserProvider currentUser) 
            : base(currentUser, 
                  StaticBindingHelper.GetLogger<UsersRequests>())
        {
        }
    }
}
