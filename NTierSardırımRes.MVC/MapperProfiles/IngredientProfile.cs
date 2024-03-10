using AutoMapper;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.IngredientViewModel;

namespace NTierSardırımRes.MVC.MapperProfiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientCreateVM>().ReverseMap();

            CreateMap<Ingredient, IngredientDeleteVM>().ReverseMap();

            CreateMap<Ingredient, IngredientUpdateVM>().ReverseMap();

        }
    }
}
