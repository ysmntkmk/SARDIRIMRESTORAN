using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.BLL.Services;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.IngredientViewModel;


namespace NTierSardırımRes.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class IngredientController : Controller
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ingredients = await _ingredientRepository.GetAll();
            return View(ingredients);
        }

        // Create işlemi

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IngredientCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var ıngredient = _mapper.Map<Ingredient>(model);
                await _ingredientRepository.CreateAsync(ıngredient);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // Update işlemi


        public async Task<IActionResult> Update(int id)
        {

            var ıngredient = await _ingredientRepository.GetByIdAsync(id);
            if (ıngredient.Item1 != null)
            {

                IngredientUpdateVM ingredientUpdate = _mapper.Map<IngredientUpdateVM>(ıngredient.Item1);


                return View(ingredientUpdate);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(IngredientUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var ıngredient= _mapper.Map<Ingredient>(model);
                await _ingredientRepository.UpdateAsync(ıngredient);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete işlemi
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _ingredientRepository.GetByIdAsync(id);
            IngredientDeleteVM ingVm = _mapper.Map<IngredientDeleteVM>(deleted.Item1);

            return View(ingVm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(IngredientDeleteVM model)
        {

            Ingredient ing = (await _ingredientRepository.GetByIdAsync(model.ID)).Item1;
            await _ingredientRepository.DeleteAsync(ing);
            return RedirectToAction("Index");
        }

    }

}




   
  