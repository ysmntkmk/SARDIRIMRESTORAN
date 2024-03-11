using NTierSardırımRes.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.OrderViewModel
{
    public class OrderCreateVM

    {
        public OrderCreateVM() 
        {
            status = DataStatus.Inserted;
            Type = OrderPrefix.Normal;
        }
        [Required(ErrorMessage = "Boş geçilemez!")]
        public OrderPrefix Type { get; set; }
        public int? CustomerID { get; set; } //Order'in eger CustomerID'si bossa anlasılmalıdır ki bu Order zaten Reservation'da verilmiştir
        public int? ReservationID { get; set; } //Order'in ReservationID'si bos ise o zaman daha sipariş söylenmemiştir Customer özel olarak bu siparişi verecektir
        public int? AppUserID { get; set; } //Eger burası bos degilse anlasılmalıdır ki bu Order bizim Member'imizi sayesinde verilmiştir
        public decimal TotalPrice { get; set; } //Siparişin icerisindeki yapılarla birlikte toplam fiyatı
        public decimal VAT { get; set; } //Kdv (TotalPrice üzerinden hesaplanacak bir şekilde)

        public DataStatus status { get; set; }
    }
}
