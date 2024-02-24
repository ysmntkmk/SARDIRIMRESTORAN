using NTierSardırımRes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class Table:BaseEntitiy
    {
        public bool Available { get; set; }
        public string TableNo { get; set; }
        public string Description { get; set; }
        public int? AppUserID { get; set; } //Simulasyonlarda kolaylık olması adına nullable int yapılmıstır...

        //Relational Properties
        public virtual List<ReservedTable> ReservedTables { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
