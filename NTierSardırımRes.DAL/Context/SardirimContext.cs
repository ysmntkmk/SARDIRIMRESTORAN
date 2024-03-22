using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NTierSardırımRes.Common;
using NTierSardırımRes.DAL.Configurations;
using NTierSardırımRes.Entities.Base;
using NTierSardırımRes.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.DAL.Context
{
    public class SardirimContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public SardirimContext(DbContextOptions<SardirimContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AppRoleConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppUserRoleConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new TableConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new ReservedTableConfiguration());
            builder.ApplyConfiguration(new IngredientConfiguration());
            builder.ApplyConfiguration(new ProductIngredientConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
        }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        public DbSet<ReservedTable> ReservedTables { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateEntityProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateEntityProperties()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as BaseEntitiy;

                //if (entry.State == EntityState.Modified)
                //{
                //    entity.UpdatedDate = DateTime.Now;
                //    entity.UpdatedIpAddress = IPAddressFinder.GetHostName();
                //    entity.UpdatedComputerName = System.Environment.MachineName;
                //}
                //else if (entry.State == EntityState.Added)
                //{
                //    entity.CreatedDate = DateTime.Now;
                //    entity.CreatedIpAddress = IPAddressFinder.GetHostName();
                //    entity.CreatedComputerName = System.Environment.MachineName;
                //}
            }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("server = YSMNTKMK\\SQLEXPRESS ;Database=SardirimDB;Trusted_Connection=True;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }



    }
}