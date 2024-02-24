using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierSardırımRes.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.DAL.Configurations
{
    public class TableConfiguration:BaseConfiguration<Table>
    {
        public override void Configure(EntityTypeBuilder<Table> builder)
        {
            base.Configure(builder);
        }
    }
}
