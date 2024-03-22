using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTierSardırımRes.DAL.Context;

namespace NTierSardırımRes.IOC.DependencyResolvers
{
    public static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();

            IConfiguration configuration = provider.GetService<IConfiguration>();
            services.AddDbContextPool<SardirimContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());
            return services;

        }
    }
}