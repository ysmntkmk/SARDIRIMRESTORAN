using Microsoft.PowerBI.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace NTierSardırımRes.MVC.Models.ViewModels.AppRoleViewModel
{
    public class AppRoleVM
    {
        public int Id { get; set; } // Rolün benzersiz kimliği

        [Required(ErrorMessage = "Rol adı zorunludur.")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; } // Rol adı

        // Opsiyonel: Roller için açıklamalar veya diğer özellikler eklemeyi düşünüyorsanız
        [Display(Name = "Açıklama")]
        public string Description { get; set; } // Rol açıklaması
    }
}

