using NTierSardırımRes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class OrderDetail:BaseEntitiy
    {
        //OID              PID               Value
        //1                 1(Iskender)      50
        //1                 2 (Beyti)        70

        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal Value { get; set; }

        //Relational Properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
