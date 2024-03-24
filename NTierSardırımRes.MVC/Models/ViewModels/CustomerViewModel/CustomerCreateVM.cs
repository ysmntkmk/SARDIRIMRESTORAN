
using NTierSardırımRes.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.CustomerViewModel
{
    public class CustomerCreateVM
    {
        public CustomerCreateVM()
        {
            Status = DataStatus.Inserted;
        }

        [Required(ErrorMessage = "Adı boş geçilemez!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadı boş geçilemez!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adres boş geçilemez!")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Telefon boş geçilemez!")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Email boş geçilemez!")]
        public string Email { get; set; } // Email özelliği boş geçilemez
        public DataStatus Status { get; private set; }
    }


}
