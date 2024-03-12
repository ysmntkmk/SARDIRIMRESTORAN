using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.ProfileViewModel
{
    public class ProfileVM
    {
        [Required(ErrorMessage = "Müşteri adı gereklidir.")]
        [Display(Name = "Müşteri Ad")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Müşteri soyadı gereklidir.")]
        [Display(Name = "Müşteri Soyad")]
        public string CustomerSurname { get; set; }

        // Diğer profil bilgilerini buraya ekleyebilirsiniz
    }
}
