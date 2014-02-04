namespace Bog.Domain.Entities.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}