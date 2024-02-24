using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierSardırımRes.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.DAL.Configurations
{
    public class ReservationConfiguration:BaseConfiguration<Reservation>
    {
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);
        }
    }
}
