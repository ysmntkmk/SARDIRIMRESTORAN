using NTierSardırımRes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class Reservation : BaseEntitiy
    {
        //DateTime.Now.Month
        public int Day { get; set; }
        public int Month { get; set; }
        public int Date { get; set; }
        public float Hour { get; set; }

        public int? CustomerID { get; set; }
        public int? AppUserID { get; set; }



        //Relational Properties
        public virtual List<Order> Orders { get; set; } //Eger Resercation siparişli bir halde verildiyse siparişler o Reservation'a ait oldugu görülmesi acısından buradaki koleksiyonda yer alır...
        public virtual Customer Customer { get; set; }
        public virtual List<ReservedTable> ReservedTables { get; set; }
        public virtual AppUser AppUser { get; set; }




    }
}
