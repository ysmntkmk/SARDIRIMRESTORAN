using NTierSardırımRes.Entities.Base;
using NTierSardırımRes.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class Order:BaseEntitiy
    {
        public OrderPrefix Type { get; set; }
        public int? CustomerID { get; set; } //Order'in eger CustomerID'si bossa anlasılmalıdır ki bu Order zaten Reservation'da verilmiştir
        public int? ReservationID { get; set; } //Order'in ReservationID'si bos ise o zaman daha sipariş söylenmemiştir Customer özel olarak bu siparişi verecektir
        public int? AppUserID { get; set; } //Eger burası bos degilse anlasılmalıdır ki bu Order bizim Member'imizi sayesinde verilmiştir

        //Relational Properties
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual Customer Customer { get; set; } 
        public virtual Reservation Reservation { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
