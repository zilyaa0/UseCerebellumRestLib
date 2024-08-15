using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services;

namespace CerebellumRestLib.Queries.Static
{
    public class OrganizationsRequest : OrganizationsService
    {
        public OrganizationsRequest(ICurrentUserProvider currentUser)
            : base(currentUser,
                  StaticBindingHelper.GetLogger<OrganizationsRequest>())
        {
        }
    }
}
