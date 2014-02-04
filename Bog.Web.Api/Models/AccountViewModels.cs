namespace Bog.Web.Api.Models
{
    using System.Collections.Generic;

    // Models returned by AccountController actions.
    public class ExternalLoginViewModel
    {
        #region Public Properties

        public string Name { get; set; }

        public string State { get; set; }
        public string Url { get; set; }

        #endregion
    }

    public class ManageInfoViewModel
    {
        #region Public Properties

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
        public string LocalLoginProvider { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }
        public string UserName { get; set; }

        #endregion
    }

    public class UserInfoViewModel
    {
        #region Public Properties

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
        public string UserName { get; set; }

        #endregion
    }

    public class UserLoginInfoViewModel
    {
        #region Public Properties

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        #endregion
    }
}