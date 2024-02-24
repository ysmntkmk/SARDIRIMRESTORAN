using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierSardırımRes.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.DAL.Configurations
{
    public class CustomerConfiguration:BaseConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
        }
    }
}
