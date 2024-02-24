using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierSardırımRes.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.DAL.Configurations
{
    public class ReservedTableConfiguration:BaseConfiguration<ReservedTable>
    {
        public override void Configure(EntityTypeBuilder<ReservedTable> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.ReservationID,
                x.TableID
            });
        }
    }
}
