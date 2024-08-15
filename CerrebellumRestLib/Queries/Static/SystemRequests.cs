using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Queries.Static
{
    public class SystemRequests: SystemInfoService
    {
        public SystemRequests(ICurrentUserProvider currentUser)
            : base(currentUser, StaticBindingHelper.GetLogger<SystemRequests>())
        {
        }
    }
}
