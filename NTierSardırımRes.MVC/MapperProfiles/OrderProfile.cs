using AutoMapper;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.IngredientViewModel;

namespace NTierSardırımRes.MVC.MapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, >().ReverseMap();

            CreateMap<Order, IngredientDeleteVM>().ReverseMap();

            CreateMap<Order, IngredientUpdateVM>().ReverseMap();
        }
    }
}
