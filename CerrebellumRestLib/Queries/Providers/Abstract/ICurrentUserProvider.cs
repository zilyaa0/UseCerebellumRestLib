using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace CerebellumRestLib.Queries.Providers.Abstract
{
    public interface ICurrentUserProvider
    {
        User GetCurrentUser();

        IRequestHandler GetRequestHandler();

        void UpdateUser(User user);

        string GetLang();

        void SetCurrentClusterId(int? clusterId);

        event EventHandler<TokenObsoletedEventArgs> TokenObsoleted;
        event EventHandler<TokenChangedEventArgs> TokenChanged;
        event EventHandler<DictionariesChangedEventArgs> DictionariesChanged;

    }
}
