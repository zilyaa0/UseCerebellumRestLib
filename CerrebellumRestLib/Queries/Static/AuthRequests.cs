using CerebellumRestLib.Queries.Services;

namespace CerebellumRestLib.Queries.Static
{
    public class AuthRequests : AuthorizationService
    {
        public AuthRequests() : 
            base(StaticBindingHelper.GetLogger<AuthorizationService>(), 
                 StaticBindingHelper.GetHttpClient())
        {
        }
    }
}
