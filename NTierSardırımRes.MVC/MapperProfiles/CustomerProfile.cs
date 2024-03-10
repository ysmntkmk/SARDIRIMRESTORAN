using AutoMapper;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.CustomerViewModel;


namespace NTierSardırımRes.MVC.MapperProfiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer,CustomerCreateVM>().ReverseMap();

            CreateMap<Customer,CustomerUpdateVM>().ReverseMap();

            CreateMap<Customer,CustomerDeleteVM >().ReverseMap();
          
        }


    }
}
