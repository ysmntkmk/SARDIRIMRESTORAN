using NTierSardırımRes.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Adress { get; set; }
        
        public string? Phone { get; set; }
        
        public string Email { get; set; }

        //Relational Properties
        public virtual List<Order> Orders { get; set; } //Önceden Reservation olarak bir sipariş verilmediyse Customer'in masaya oturduktan sonraki verdigi siparişler burada yer alır
        public virtual List<Reservation> Reservations { get; set; }

    }
}
