using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.BLL.Services;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.ProductViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.TableViewModel;

namespace NTierSardırımRes.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TableController : Controller
    {
        private readonly ITableRepository _tablerepository;
        private readonly IMapper _mapper;
        public TableController(ITableRepository tableRepository, IMapper mapper)
        {
            _tablerepository = tableRepository;
            _mapper = mapper;
          
        }
        public async Task<IActionResult> Index()
        {
            var tables = await _tablerepository.GetAll();
            return View(tables);
        }
        // Create işlemi

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(TableCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var table = _mapper.Map<Table>(model);
                await _tablerepository.CreateAsync(table);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Update işlemi

        public async Task<IActionResult> Update(int id)
        {

            var table = await _tablerepository.GetByIdAsync(id);
            if (table.Item1 != null)
            {

                TableUpdateVM tableUpdate = _mapper.Map<TableUpdateVM>(table.Item1);


                return View(tableUpdate);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Update(TableUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var table = _mapper.Map<Table>(model);
                await _tablerepository.UpdateAsync(table);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // Delete işlemi
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tablerepository.GetByIdAsync(id);
            TableDeleteVM dtVm = _mapper.Map<TableDeleteVM>(deleted.Item1);

            return View(dtVm);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(TableDeleteVM model)
        {

            Table dt = (await _tablerepository.GetByIdAsync(model.ID)).Item1;
            await _tablerepository.DeleteAsync(dt);
            return RedirectToAction("Index");
        }
    }
}
