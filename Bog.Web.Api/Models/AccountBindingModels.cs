namespace Bog.Web.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    // Models used as parameters to AccountController actions.
    public class AddExternalLoginBindingModel
    {
        #region Public Properties

        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }

        #endregion
    }

    public class ChangePasswordBindingModel
    {
        #region Public Properties

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        #endregion
    }

    public class RegisterBindingModel
    {
        #region Public Properties

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }

    public class RegisterExternalBindingModel
    {
        #region Public Properties

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }

    public class RemoveLoginBindingModel
    {
        #region Public Properties

        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }

        #endregion
    }

    public class SetPasswordBindingModel
    {
        #region Public Properties

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        #endregion
    }
}