using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.Entities.Entities;

namespace NTierSardırımRes.MVC.Controllers
{
    [Authorize] // Bu controllera sadece oturum açmış kullanıcılar erişebilir
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Kullanıcının profil bilgilerini al
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(); // Kullanıcı bulunamadıysa 404 hatası gönder
            }

            // Profil sayfasını görüntüle
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            // Kullanıcının profil bilgilerini al
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(); // Kullanıcı bulunamadıysa 404 hatası gönder
            }

            // Profil düzenleme sayfasını görüntüle
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUser model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcıyı güncelle
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound(); // Kullanıcı bulunamadıysa 404 hatası gönder
                }

                user.CustomerName = model.CustomerName;
                user.CustomerSurname = model.CustomerSurname;
                // Diğer profil bilgilerini güncelle

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index"); // Profil başarıyla güncellendiğinde profil sayfasına yönlendir
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Model geçerli değilse veya güncelleme başarısızsa, düzenleme sayfasını tekrar görüntüle
            return View(model);
        }
    }

}
