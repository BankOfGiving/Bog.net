namespace Bog.Domain.Entities.Account
{
    using System.ComponentModel.DataAnnotations;

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
}