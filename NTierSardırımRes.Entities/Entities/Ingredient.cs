using NTierSardırımRes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class Ingredient:BaseEntity
    {
        public string Name { get; set; }
        public int UnitsInStock { get; set; }

        //Relational Properties
        public virtual List<ProductIngredient> ProductIngredients { get; set; }


    }
}
