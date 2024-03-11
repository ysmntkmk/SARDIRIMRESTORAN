using AutoMapper;
using NTierSardırımRes.MVC.MapperProfiles;

namespace NTierSardırımRes.MVC.UIDependencyResolver
{
    public static class AutoMapperInjection
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            MapperConfiguration mapperConf = new(opt =>
            {
                opt.AddProfile(new ProductProfile());
                opt.AddProfile(new CustomerProfile());
                opt.AddProfile(new IngredientProfile());
                opt.AddProfile(new TableProfile());
                opt.AddProfile(new ReservationProfile());
                opt.AddProfile(new OrderProfile());
            });

            IMapper mapper = mapperConf.CreateMapper();
            services.AddSingleton(mapper); 
            
               
            
        }
    }
}
