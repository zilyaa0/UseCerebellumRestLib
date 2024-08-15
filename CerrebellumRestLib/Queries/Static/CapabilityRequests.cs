using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services;

namespace CerebellumRestLib.Queries.Static
{
    public class CapabilityRequests : CapabilityService
    {
        public CapabilityRequests(ICurrentUserProvider currentUser) 
            : base(currentUser, StaticBindingHelper.GetLogger<CapabilityService>())
        {
        }
    }
}
