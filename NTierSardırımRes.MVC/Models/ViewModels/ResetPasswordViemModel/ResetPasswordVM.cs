using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.ResetPasswordViemModel
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "UserId alanı gereklidir.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Token alanı gereklidir.")]
        public string Token { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar alanı gereklidir.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        public object Email { get; internal set; }
    }
}
