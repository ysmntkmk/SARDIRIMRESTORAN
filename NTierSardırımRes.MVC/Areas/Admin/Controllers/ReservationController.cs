using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.BLL.Services;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.ProductViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.ReservationViewModel;

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

        // Create işlemi

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var reservation = _mapper.Map<Reservation>(model);
                await _reservationRepository.CreateAsync(reservation);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        // Update işlemi
        public async Task<IActionResult> Update(int id)
        {

            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation.Item1 != null)
            {

                ReservationUptadeVM reservationUpdate = _mapper.Map<ReservationUptadeVM>(reservation.Item1);


                return View(reservationUpdate);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Update(ReservationUptadeVM model)
        {
            if (ModelState.IsValid)
            {
                var reservation = _mapper.Map<Reservation>(model);
                await _reservationRepository.UpdateAsync(reservation);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete işlemi
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _reservationRepository.GetByIdAsync(id);
            ReservationDeleteVM rsVm = _mapper.Map<ReservationDeleteVM>(deleted.Item1);

            return View(rsVm);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteVM model)
        {

            Reservation rs = (await _reservationRepository.GetByIdAsync(model.ID)).Item1;
            await _reservationRepository.DeleteAsync(rs);
            return RedirectToAction("Index");
        }
    }



}

