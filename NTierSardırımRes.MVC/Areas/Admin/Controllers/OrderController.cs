using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.BLL.Services;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.OrderViewModel;


namespace NTierSardırımRes.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAll();
            return View(orders);
        }

        // Create işlemi

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(model);
                await _orderRepository.CreateAsync(order);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Update işlemi
        public async Task<IActionResult> Update(int id)
        {

            var order = await _orderRepository.GetByIdAsync(id);
            if (order.Item1 != null)
            {
               OrderUpdateVM orderUpdate = _mapper.Map<OrderUpdateVM>(order.Item1);


                return View(orderUpdate);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Update(OrderUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(model);
                await _orderRepository.UpdateAsync(order);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete işlemi
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _orderRepository.GetByIdAsync(id);
            OrderDeleteVM orVm = _mapper.Map<OrderDeleteVM>(deleted.Item1);

            return View(orVm);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(OrderDeleteVM model)
        {

            Order or = (await _orderRepository.GetByIdAsync(model.ID)).Item1;
            await _orderRepository.DeleteAsync(or);
            return RedirectToAction("Index");
        }
    }
}

