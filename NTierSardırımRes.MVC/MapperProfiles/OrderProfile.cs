using AutoMapper;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.OrderViewModel;

namespace NTierSardırımRes.MVC.MapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderCreateVM>().ReverseMap();

            CreateMap<Order, OrderDeleteVM>().ReverseMap();

            CreateMap<Order, OrderUpdateVM>().ReverseMap();
        }
    }
}
