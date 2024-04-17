using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.AppUserViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTierSardırımRes.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var userList = users.Select(user => new AppUserVM
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = _userManager.GetRolesAsync(user).Result.ToList()
            }).ToList();

            return View(userList);
        }

        public IActionResult Create()
        {
            var roleItems = _roleManager.Roles.Select(role => new SelectListItem
            {
                Text = role.Name,
                Value = role.Name
            }).ToList();

            var viewModel = new AppUserVM
            {
                RoleItems = roleItems
            };

            return View(viewModel);
        }
      
        [HttpPost]
        public async Task<IActionResult> Create(AppUserVM model, string selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(selectedRole))
                    {
                        await _userManager.AddToRoleAsync(user, selectedRole);
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            ViewBag.Roles = _roleManager.Roles.ToList();
            return View(model);
        }



        public async Task<IActionResult> Update(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var viewModel = new AppUserVM
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = userRoles.ToList()
            };

            ViewBag.Roles = _roleManager.Roles.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserVM model, List<string> selectedRoles)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı!";
                return RedirectToAction("Index");
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

           

            // Kullanıcının mevcut rollerini kaldır ve seçilen rolleri ekle
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, selectedRoles);

            // Kullanıcıyı güncelle
            var updateUser = await _userManager.UpdateAsync(user);
            if (updateUser.Succeeded)
            {
                // Oturumu kapat ve tekrar oturum aç
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Kullanıcı güncelleme hatası!";
                return RedirectToAction("Index");
            }
        }
    }
}
