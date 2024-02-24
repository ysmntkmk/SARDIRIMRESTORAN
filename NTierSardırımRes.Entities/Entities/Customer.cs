using NTierSardırımRes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class Customer:BaseEntitiy
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Relational Properties
        public virtual List<Order> Orders { get; set; } //Önceden Reservation olarak bir sipariş verilmediyse Customer'in masaya oturduktan sonraki verdigi siparişler burada yer alır
        public virtual List<Reservation> Reservations { get; set; }

    }
}
