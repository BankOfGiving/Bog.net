namespace Bog.Domain.Entities.Account
{
    using System.ComponentModel.DataAnnotations;

    public class AddExternalLoginBindingModel
    {
        #region Public Properties

        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }

        #endregion
    }
}