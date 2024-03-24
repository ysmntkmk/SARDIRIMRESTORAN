using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.CustomerViewModel;


namespace NTierSardırımRes.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper ) 
        {

            _customerRepository = customerRepository;
            _mapper = mapper;
        }
       
        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetAll();
            return View(customers);
        }
        // Create işlemi

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(model);
                await _customerRepository.CreateAsync(customer);
                return RedirectToAction("Index");
            }

            // ModelState'deki hataları göster
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error.ErrorMessage);
            }

            return View(model);
        }

        // Update işlemi

        public async Task<IActionResult> Update(int id)
        {

            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer!= null)
            {

                CustomerUpdateVM customerUpdate = _mapper.Map<CustomerUpdateVM>(customer.Item1);


                return View(customerUpdate);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(model);
                await _customerRepository.UpdateAsync(customer);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // Delete işlemi
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _customerRepository.GetByIdAsync(id);
            CustomerDeleteVM csVm = _mapper.Map<CustomerDeleteVM>(deleted.Item1);

            return View(csVm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CustomerDeleteVM model)
        {

            Customer cs = (await _customerRepository.GetByIdAsync(model.ID)).Item1;
            await _customerRepository.DeleteAsync(cs);
            return RedirectToAction("Index");
        }

    }
}

