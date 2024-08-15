using CerebellumRestLib.Models;
using CerebellumRestLib.Models.Events;
using CerebellumRestLib.Queries.Providers.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace CerebellumRestLib.Queries.Providers
{
    public class TokenCurrentUserProvider : CurrentUserProvider
    {
        public TokenCurrentUserProvider(IRequestHandler requestHandler, User user, string lang = null) : base(requestHandler, lang)
        {
            UpdateUser(user);
        }

        public override IRequestHandler GetRequestHandler() => RequestHandler;
    }
    public class CurrentUserProvider : ICurrentUserProvider
    {
        #region Fields
        private readonly IRequestHandler _requestHandler;
        private User _currentUser;
        private string _lang; 
        #endregion

        #region Constructor
        public CurrentUserProvider(IRequestHandler requestHandler, string lang = null)
        {
            _requestHandler = requestHandler;
            _lang = lang;
        }
        #endregion

        #region ICurrentUserProvider
        public void SetCurrentClusterId(int? clusterId)
        {
            _requestHandler.SetCurrentClusterId(clusterId);
        }
        protected IRequestHandler RequestHandler => _requestHandler;

        public virtual IRequestHandler GetRequestHandler()
        {
            if (_currentUser.LastAuthDateTime < DateTime.Now.AddHours(-6))
                TokenObsoleted?.Invoke(this, new TokenObsoletedEventArgs { User = _currentUser });
            return _requestHandler;
        }

        public virtual string GetLang()
        {
            if (!string.IsNullOrWhiteSpace(_lang))
                return _lang;

            CultureInfo culture = CultureInfo.DefaultThreadCurrentUICulture ?? CultureInfo.CurrentUICulture;
            return culture.TwoLetterISOLanguageName;
        }

        public User GetCurrentUser() => _currentUser;

        public void UpdateUser(User user)
        {
            if (_requestHandler != null)
                _requestHandler.DictionariesChanged -= CurrentUserProvider_DictionariesChanged;

            _currentUser = user;
            _requestHandler.SetUser(user, GetLang());
            _requestHandler.DictionariesChanged += CurrentUserProvider_DictionariesChanged;
            TokenChanged?.Invoke(this, new TokenChangedEventArgs { Token = _currentUser.Token });
        }

        public event EventHandler<TokenObsoletedEventArgs> TokenObsoleted;
        public event EventHandler<TokenChangedEventArgs> TokenChanged;
        public event EventHandler<DictionariesChangedEventArgs> DictionariesChanged;
        #endregion

        #region Private Methods
        private void CurrentUserProvider_DictionariesChanged(object sender, DictionariesChangedEventArgs e)
        {
            DictionariesChanged?.Invoke(sender, e);
        } 
        #endregion
    }
}
