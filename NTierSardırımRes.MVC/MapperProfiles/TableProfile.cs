using AutoMapper;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.IngredientViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.TableViewModel;

namespace NTierSardırımRes.MVC.MapperProfiles
{
    public class TableProfile :Profile
    {
        public TableProfile()
        {
            CreateMap<Table, TableCreateVM >().ReverseMap();

            CreateMap<Table, TableDeleteVM >().ReverseMap();

            CreateMap<Table, TableUpdateVM>().ReverseMap();
        }

    }
}
