using AutoMapper;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.ProductViewModel;

namespace NTierSardırımRes.MVC.MapperProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductCreateVM>().ReverseMap();
            CreateMap<ProductUpdateVM, Product>().ForMember(dest => dest.ProductIngredients, opt => opt.Ignore()).ForMember(dest => dest.OrderDetails, opt => opt.Ignore()).ReverseMap();
            //CreateMap<Product, ProductUpdateVM>().ReverseMap();

            CreateMap<Product, ProductDeleteVM>().ReverseMap();
            //CreateMap<Deneme,DenemeVM>().ReverseMap();
        }

    }
}
