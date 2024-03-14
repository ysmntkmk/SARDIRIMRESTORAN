using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NTierSardırımRes.DAL.Context;
using NTierSardırımRes.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.IOC.DependencyResolvers
{
    public static class CustomIdentityService
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;
                x.Password.RequiredLength = 2;
                x.SignIn.RequireConfirmedEmail = true;
                x.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<SardirimContext>()
            .AddDefaultTokenProviders();

            return services;
     
    
        }
    }
}
