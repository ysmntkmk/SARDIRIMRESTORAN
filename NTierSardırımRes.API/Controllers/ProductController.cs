using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.ProductViewModel;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace NTierSardırımRes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }
     


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<ProductCreateVM, Product>(model);
            var result = await _productRepository.CreateAsync(product);

            if (result == "Ürün başarıyla oluşturuldu.")
            {
                return CreatedAtAction(nameof(GetProducts), new { id = product.ID }, product);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            var product = _mapper.Map<ProductUpdateVM, Product>(model);
            product.ID = id; // URL'den ID'yi al
            var result = await _productRepository.UpdateAsync(product);

            if (result == "Ürün başarıyla güncellendi.")
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var result = await _productRepository.DeleteAsync(product.Item1);

            if (result == "Ürün başarıyla silindi.")
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
