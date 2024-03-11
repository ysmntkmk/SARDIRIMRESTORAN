using NTierSardırımRes.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.ReservationViewModel
{
    public class ReservationCreateVM
    {
        public ReservationCreateVM()
        {
            Status = DataStatus.Inserted;
        }
        [Required(ErrorMessage = "Boş geçilemez!")]
        public int Day { get; set; }
        [Required(ErrorMessage = "Boş geçilemez!")]
        public int Month { get; set; }
        [Required(ErrorMessage = "Boş geçilemez!")]
        public int Date { get; set; }
        [Required(ErrorMessage = "Boş geçilemez!")]
        public float Hour { get; set; }


        public int? CustomerID { get; set; }
        public int? AppUserID { get; set; }


        public DataStatus Status { get; set; }
    }
}
