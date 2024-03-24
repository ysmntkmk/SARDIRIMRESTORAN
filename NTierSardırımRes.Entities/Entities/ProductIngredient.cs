using NTierSardırımRes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    //1 Ingredient (sogan) => n Product
    //1 Product (Kebap) => n Ingredient
    public class ProductIngredient:BaseEntity
    {
        public int ProductID { get; set; } //1 Kebap
        public int IngredientID { get; set; } //1 Kırmızı Et
        public string Value { get; set; } //250 gr

        //Relational Properties
        public virtual Product Product { get; set; }
        public virtual Ingredient Ingredient { get; set; }


    }
}
