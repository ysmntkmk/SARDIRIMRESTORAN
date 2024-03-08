using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.CustomerVİewModel
{
    public class CustomerCreateVM
    {
        [Required(ErrorMessage = " adı boş geçilemez!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " Soyadı boş geçilemez!")]
        public string LastName { get; set; }
       
    }
}
