using AutoMapper;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.CustomerViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.ReservationViewModel;

namespace NTierSardırımRes.MVC.MapperProfiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile() 
        {
            CreateMap<Reservation, ReservationCreateVM>().ReverseMap();

            CreateMap<Reservation, ReservationDeleteVM>().ReverseMap();

            CreateMap<Reservation, ReservationUptadeVM>().ReverseMap();

        }
    }
}
