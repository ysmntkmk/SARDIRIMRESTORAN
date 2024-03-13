using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.RegisterViewModel
{
    public class RegisterVM
    {
        internal string SuccessMessage;
        [Required(ErrorMessage = "Müşteri adı alanı gereklidir.")]
        [Display(Name = "Müşteri Ad")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Müşteri adı alanı gereklidir.")]
        [Display(Name = "Müşteri Soyad")]
        public string CustomerSurname { get; set; }
        [Required(ErrorMessage = "Müşteri adı alanı gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
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

        [Display(Name = "Cep No")]
        public string PhoneNumber { get; set; }

       


    }
}
