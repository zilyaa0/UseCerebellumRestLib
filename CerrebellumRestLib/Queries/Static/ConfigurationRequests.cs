using CerebellumRestLib.Queries.Providers.Abstract;
using CerebellumRestLib.Queries.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Queries.Static
{
    public class ConfigurationRequests : ConfigurationService
    {
        public ConfigurationRequests(ICurrentUserProvider currentUser)
            : base(currentUser, StaticBindingHelper.GetLogger<ConfigurationRequests>())
        {
        }
    }
}
