using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.BLL.Abstracts;

namespace NTierSardırımRes.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;


        public ReservationController(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var reservations = await _reservationRepository.GetAll();
            return View(reservations);
        }


    }
}
