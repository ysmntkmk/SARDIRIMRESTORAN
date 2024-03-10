
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

        [Required(ErrorMessage = " adı boş geçilemez!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " Soyadı boş geçilemez!")]
        public string LastName { get; set; }
        public string? Adress { get; set; }

        public string? Phone { get; set; }

        public string Email { get; set; }
        public DataStatus Status { get; set; }

    }
}
