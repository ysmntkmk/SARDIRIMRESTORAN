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
            });

            IMapper mapper = mapperConf.CreateMapper();
            services.AddSingleton(mapper); 
            
               
            
        }
    }
}
