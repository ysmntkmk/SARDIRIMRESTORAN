using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.ResetPasswordViemModel
{
    public class ResetPasswordVM
    {

        public string UserId { get; set; }
        public string Token { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        public string Email { get; internal set; }
    }
}
