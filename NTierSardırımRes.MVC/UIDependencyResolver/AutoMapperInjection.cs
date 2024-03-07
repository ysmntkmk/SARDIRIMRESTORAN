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
            });

            IMapper mapper = mapperConf.CreateMapper();
            services.AddSingleton(mapper); 
            
               
            
        }
    }
}
