using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTierSardırımRes.DAL.Configurations;
using NTierSardırımRes.Entities.Base;
using NTierSardırımRes.Entities.Entities;

namespace NTierSardırımRes.DAL.Context
{
    public partial class SardirimContext:IdentityDbContext<AppUser,AppRole,int,IdentityUserClaim<int>,AppUserRole,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
        public SardirimContext(DbContextOptions<SardirimContext> options):base(options)
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
            //ChangeTracker
            try
            {
                var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
                foreach (var entry in modifiedEntries)
                {
                    var entityRepository = entry.Entity as BaseEntitiy;

                    if (entry.State == EntityState.Modified)
                    {
                        //entityRepository.UpdatedDate = DateTime.Now;
                        //entityRepository.UpdatedIpAddress = IPAddressFinder.GetHostName();
                        //entityRepository.UpdatedComputerName = System.Environment.MachineName;
                        //entityRepository.UpdatedDate = DateTime.Now;
                        //entityRepository.UpdatedIpAddress = IPAddressFinder.GetHostName();
                        //entityRepository.UpdatedComputerName = System.Environment.MachineName;

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("server = YSMNTKMK\\SQLEXPRESS ;Database=SardirimDB;Trusted_Connection=True;TrustServerCertificate=True");


            base.OnConfiguring(optionsBuilder);
        }

    }
}
