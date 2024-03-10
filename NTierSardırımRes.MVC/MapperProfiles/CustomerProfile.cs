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

            //CreateMap<ProductUpdateVM, Product>().ForMember(dest => dest.ProductIngredients, opt => opt.Ignore()).ForMember(dest => dest.OrderDetails, opt => opt.Ignore()).ReverseMap();
            CreateMap<Customer,CustomerUpdateVM>().ReverseMap();

            CreateMap<Customer,CustomerDeleteVM >().ReverseMap();
          
        }


    }
}
