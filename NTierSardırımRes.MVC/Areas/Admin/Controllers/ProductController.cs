using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.ProductViewModel;

namespace NTierSardırımRes.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        { 
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products=await _productRepository.GetAll();
            return View(products);
        }

        // Create işlemi

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                await _productRepository.CreateAsync(product);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Update işlemi

        [HttpGet]
        public async Task<IActionResult> Update(int id) 
        {
            var product = await _productRepository.GetByIdAsync(id);
            if ( product != null)
            {

                var productUpdate = _mapper.Map<ProductUpdateVM>(product);

                return View(productUpdate);
            }
           
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                await _productRepository.UpdateAsync(product);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete işlemi
        public async Task< IActionResult> Delete(int id)
        {
            var deleted = await _productRepository.GetByIdAsync(id);
            ProductDeleteVM pdVm = _mapper.Map <ProductDeleteVM> (deleted.Item1);

            return View(pdVm);
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteVM model)
        {
           
            Product pr = (await _productRepository.GetByIdAsync(model.Id)).Item1;
            await _productRepository.DeleteAsync(pr);
            return RedirectToAction("Index");
        }
    }
}
