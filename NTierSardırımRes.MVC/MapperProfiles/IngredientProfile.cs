using AutoMapper;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.CustomerViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.IngredientViewModel;

namespace NTierSardırımRes.MVC.MapperProfiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientCreateVM>().ReverseMap();

            ////CreateMap<ProductUpdateVM, Product>().ForMember(dest => dest.ProductIngredients, opt => opt.Ignore()).ForMember(dest => dest.OrderDetails, opt => opt.Ignore()).ReverseMap();
            //CreateMap<Customer, CustomerUpdateVM>().ReverseMap();

            //CreateMap<Customer, CustomerDeleteVM>().ReverseMap();

        }
    }
}
