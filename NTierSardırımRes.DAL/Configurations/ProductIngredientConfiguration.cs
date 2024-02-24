using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierSardırımRes.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.DAL.Configurations
{
    public class ProductIngredientConfiguration:BaseConfiguration<ProductIngredient>
    {
        public override void Configure(EntityTypeBuilder<ProductIngredient> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.ProductID,
                x.IngredientID
            });
        }
    }
}
