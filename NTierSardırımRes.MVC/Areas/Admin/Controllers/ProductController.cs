using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        // Index action'ı, tüm ürünleri listeler
        public async Task<IActionResult> Index(string returnUrl)
        {
          
            var products = await _productRepository.GetAll();
            return View(products);
        }

        // Create işlemi için Get ve Post action'ları
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                product.CreatedDate = DateTime.Now; // Oluşturma tarihini kaydet
                await _productRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index)); // RedirectToAction parametresi string olarak action adını almaktadır.
            }
            return View(model);
        }
        

        // Update işlemi için Get ve Post action'ları
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product.Item1 != null)
            {
                ProductUpdateVM productUpdate = _mapper.Map<ProductUpdateVM>(product.Item1);
                return View(productUpdate);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                product.UpdatedDate = DateTime.Now; // Güncelleme tarihini kaydet
                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index)); // RedirectToAction parametresi string olarak action adını almaktadır.
            }
            return View(model);
        }

        // Delete işlemi için Get ve Post action'ları
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productRepository.GetByIdAsync(id);
            if (deleted.Item1 != null)
            {
                ProductDeleteVM pdVm = _mapper.Map<ProductDeleteVM>(deleted.Item1);
                return View(pdVm);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProductDeleteVM model)
        {
            Product pr = (await _productRepository.GetByIdAsync(model.ID)).Item1;
            await _productRepository.DeleteAsync(pr);
            return RedirectToAction(nameof(Index)); // RedirectToAction parametresi string olarak action adını almaktadır.
        }
    }
}
