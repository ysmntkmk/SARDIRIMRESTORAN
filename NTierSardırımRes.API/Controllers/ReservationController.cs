using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.ReservationViewModel;

namespace NTierSardırımRes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public ReservationController(IReservationRepository reservationRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _reservationRepository.GetAll();
            var reservationVMs = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationUptadeVM>>(reservations);
            return Ok(reservationVMs);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] ReservationCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _customerRepository.GetByIdAsync(model.CustomerID.Value);
            if (customer == null)
            {
                return BadRequest("Müşteri bulunamadı.");
            }

            var reservation = _mapper.Map<ReservationCreateVM, Reservation>(model);
            reservation.Customer = customer.Item1;

            var result = await _reservationRepository.CreateAsync(reservation);

            if (result == "Rezervasyon başarıyla oluşturuldu.")
            {
                return CreatedAtAction(nameof(GetReservations), new { id = reservation.ID }, reservation);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] ReservationUptadeVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingReservation = await _reservationRepository.GetByIdAsync(id);

            if (existingReservation == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetByIdAsync(model.CustomerID.Value);
            if (customer == null)
            {
                return BadRequest("Müşteri bulunamadı.");
            }

            var reservation = _mapper.Map<ReservationUptadeVM, Reservation>(model);
            reservation.ID = id; // URL'den ID'yi al
            reservation.Customer = customer.Item1;

            var result = await _reservationRepository.UpdateAsync(reservation);

            if (result == "Rezervasyon başarıyla güncellendi.")
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            var result = await _reservationRepository.DeleteAsync(reservation.Item1);

            if (result == "Rezervasyon başarıyla silindi.")
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
