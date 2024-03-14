using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.ForgotPasswordViewModel
{
    public class ForgotPasswordVM
    {
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
       
    }
}
