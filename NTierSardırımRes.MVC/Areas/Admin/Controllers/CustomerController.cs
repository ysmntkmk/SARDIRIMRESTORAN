using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.Entities.Entities;

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
    }
}

