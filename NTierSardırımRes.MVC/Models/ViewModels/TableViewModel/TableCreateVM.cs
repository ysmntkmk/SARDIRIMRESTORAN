using NTierSardırımRes.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.TableViewModel
{
    public class TableCreateVM

    {
        public TableCreateVM()
        {
            Status = DataStatus.Inserted;
        }
        public bool Available { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!")]
        public string TableNo { get; set; }
        public string Description { get; set; }
        public int? AppUserID { get; set; } //Simulasyonlarda kolaylık olması adına nullable int yapılmıstır...
        public DataStatus Status { get; set; }
    }
}
