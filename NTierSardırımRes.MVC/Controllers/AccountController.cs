using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.Entities.Entities;
using System.Web;

namespace NTierSardırımRes.MVC.Controllers
{
    // Hesap işlemleri için Controller sınıfı
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Confirmation(int id, string token)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var decodeToken = HttpUtility.UrlDecode(token);
                var result = await _userManager.ConfirmEmailAsync(user, decodeToken);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            //eğer kullanıcı varsa ilgili kullanıcının EmailConfimation özelliğini true yap.
            return RedirectToAction("Index", "Home");

        }
    }
}



