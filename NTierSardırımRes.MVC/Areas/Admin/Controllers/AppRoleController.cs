using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Areas.Admin.TempDataHelper;
using NTierSardırımRes.MVC.Models.ViewModels.AppRoleViewModel;
using System.Security.Claims;

namespace NTierSardırımRes.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AppRoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AppRoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {

            var RoleList = _roleManager.Roles.Select(x => new AppRoleVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(RoleList);
        }
        public IActionResult Create()
        {
            if (!CheckAuthorization(new[] { "admin" }))
            {
                TempData.NoAuthorizationMessage();
                return RedirectToAction("Index", "Home", new { area = "admin" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateVM roleVM)
        {

            if (!CheckAuthorization(new[] { "admin" }))
            {
                TempData.NoAuthorizationMessage();
                return RedirectToAction("Index", "Home", new { area = "admin" });
            }
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new AppRole()
                {
                    Name = roleVM.Name,
                });
                return RedirectToAction("Index", "User", new { area = "admin" });
            }
            return View(roleVM);
        }
        public async Task<IActionResult> Update(string id)
        {

            if (!CheckAuthorization(new[] { "admin"}))
            {
                TempData.NoAuthorizationMessage();
                return RedirectToAction("Index", "Home", new { area = "admin" });
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var roleUpdated = new AppRoleVM()
                {
                    Id = role.Id,
                    Name = role.Name
                };
                return View(roleUpdated);
            }

            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AppRoleVM approleVM)
        {

            if (!CheckAuthorization(new[] { "admin"}))
            {
                TempData.NoAuthorizationMessage();
                return RedirectToAction("Index", "Home", new { area = "admin" });
            }
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(approleVM.Id.ToString());
                if (role != null)
                {
                    role.Id = approleVM.Id;
                    role.Name = approleVM.Name;
                    var updatedEntity = await _roleManager.UpdateAsync(role);
                    return RedirectToAction("Index", "Role", new { area = "admin" });
                }

            }
            return View(approleVM);
        }

        private bool CheckAuthorization(string[] roles)
        {
            // Kullanıcının yetkilendirilip yetkilendirilmediğini kontrol etmek için kullanıcının rollerini alın
            var userRoles = HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            // Verilen rollerin kullanıcı rolleri içinde olup olmadığını kontrol edin
            foreach (var role in roles)
            {
                if (userRoles.Contains(role))
                {
                    return true; // Kullanıcı belirtilen rollerden birine sahipse true döndürün
                }
            }

            return false; // Kullanıcı belirtilen rollerden hiçbirine sahip değilse false döndürün
        }


        public async Task<IActionResult> Remove(string id)
        {

            if (!CheckAuthorization(new[] { "admin", "manager" }))
            {
                TempData.NoAuthorizationMessage();
                return RedirectToAction("Index", "Home", new { area = "manager" });
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                _roleManager.DeleteAsync(role);
                return RedirectToAction("Index", "Role", new { area = "manager" });

            }
            return View(id);
        }

        public async Task<IActionResult> AssignRole(string id)
        {
            if (!CheckAuthorization(new[] { "admin", "manager" }))
            {
                TempData.NoAuthorizationMessage();
                return RedirectToAction("Index", "Home", new { area = "admin" });
            }
            var selectedUser = await _userManager.FindByIdAsync(id);
            ViewData["UserId"] = id; // UserId'yi ViewData içine ekleyin
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(selectedUser);
            var roleViewModel = new List<RoleAssignVM>();

            foreach (var role in roles)
            {
                var assignRoleVM = new RoleAssignVM()
                {
                    Id = role.Id.ToString(),
                    Name = role.Name
                };

                if (userRoles.Contains(role.Name))
                {
                    assignRoleVM.Exist = true;
                }
                roleViewModel.Add(assignRoleVM);
            }
            return View(roleViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AssignRole(string userId, List<RoleAssignVM> requestList)
        {

            if (!CheckAuthorization(new[] { "admin", "admin" }))
            {
                TempData.NoAuthorizationMessage();
                return RedirectToAction("Index", "Home", new { area = "admin" });
            }
            var userToRole = await _userManager.FindByIdAsync(userId);

            if (userToRole == null)
            {

                return RedirectToAction("index", "role", new { area = "Admin" });
            }

            foreach (var role in requestList)
            {
                if (role.Exist)
                {
                    await _userManager.AddToRoleAsync(userToRole, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(userToRole, role.Name);
                }
            }

            return RedirectToAction("index", "user", new { area = "Admin" });
        }


    }
}
