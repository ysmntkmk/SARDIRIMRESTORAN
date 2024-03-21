using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.RegisterViewModel
{
    public class RegisterVM
    {

        public string UserName { get; set; }
        [Required(ErrorMessage = "Müşteri adı alanı gereklidir.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Müşteri adı alanı gereklidir.")]
        [Display(Name = "Şifre Tekrar")]
        public string PasswordConfirmed { get; set; }
        [Required(ErrorMessage = "Müşteri adı alanı gereklidir.")]
        [Display(Name = "Email")]
        public string Email { get; set; }






    }
}
