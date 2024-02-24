using Microsoft.AspNetCore.Identity;
using NTierSardırımRes.Entities.Enums;
using NTierSardırımRes.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public AppUser() 
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;

        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        // Relation Properties
        public virtual List<AppUserRole> UserRoles { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Table> Tables { get; set; }//Garson rolündeki AppUser'larimizin masalarla ilgilenebilmesi adına olusturulmus bir ilişki


    }
}
