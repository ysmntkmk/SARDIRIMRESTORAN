using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NTierSardırımRes.DAL.Context;
using NTierSardırımRes.Entities.Entities;

public static class CustomIdentityService
{
    public static async Task<IServiceCollection> AddIdentityServicesAsync(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            // Şifre gereksinimleri
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 6; // Şifre uzunluğunu arttırdım
            options.Password.RequireNonAlphanumeric = false;

            // Giriş gereksinimleri
            options.SignIn.RequireConfirmedEmail = true;

            // Kullanıcı adı ve eposta gereksinimleri
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<SardirimContext>()
        .AddDefaultTokenProviders();

       
       


        return services; // IServiceCollection'ı döndürdüm
    }
}
