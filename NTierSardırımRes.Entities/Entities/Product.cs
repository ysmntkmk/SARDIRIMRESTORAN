using NTierSardırımRes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class Product:BaseEntitiy
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }

        //Relational Properties
        public virtual List<ProductIngredient> ProductIngredients { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }



    }
}
