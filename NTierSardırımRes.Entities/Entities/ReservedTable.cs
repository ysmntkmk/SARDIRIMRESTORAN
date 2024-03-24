using NTierSardırımRes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class ReservedTable:BaseEntity
    {
        public int ReservationID { get; set; }
        public int TableID { get; set; }


        //Relational Properties
        public virtual Reservation Reservation { get; set; }
        public virtual Table Table { get; set; }

    }
}
