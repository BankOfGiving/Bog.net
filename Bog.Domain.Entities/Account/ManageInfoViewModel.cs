namespace Bog.Domain.Entities.Account
{
    using System.Collections.Generic;

    public class ManageInfoViewModel
    {
        #region Public Properties

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
        public string LocalLoginProvider { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }
        public string UserName { get; set; }

        #endregion
    }
}