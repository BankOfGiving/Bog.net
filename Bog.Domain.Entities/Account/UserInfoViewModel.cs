namespace Bog.Domain.Entities.Account
{
    public class UserInfoViewModel
    {
        #region Public Properties

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
        public string UserName { get; set; }

        #endregion
    }
}