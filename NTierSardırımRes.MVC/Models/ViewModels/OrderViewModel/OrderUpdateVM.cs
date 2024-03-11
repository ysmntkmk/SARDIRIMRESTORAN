using NTierSardırımRes.Entities.Enums;

namespace NTierSardırımRes.MVC.Models.ViewModels.OrderViewModel
{
    public class OrderUpdateVM
    {
        public int ID { get; set; }
        public OrderPrefix Type { get; set; }
        public int? CustomerID { get; set; } 
        public int? ReservationID { get; set; } 
        public int? AppUserID { get; set; } 
        public decimal TotalPrice { get; set; } 

        public decimal VAT { get; set; }
    }
}
