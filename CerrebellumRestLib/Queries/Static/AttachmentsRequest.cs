using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services;

namespace CerebellumRestLib.Queries.Static
{
    public class AttachmentsRequest : AttachmentsService
    {
        public AttachmentsRequest(ICurrentUserProvider currentUser)
            : base(currentUser, StaticBindingHelper.GetLogger<AttachmentsRequest>())
        {
        }
    }
}