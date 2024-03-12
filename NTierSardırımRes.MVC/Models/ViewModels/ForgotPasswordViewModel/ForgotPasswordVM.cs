using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.ForgotPasswordViewModel
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "E-posta adresi alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
    }
}
