using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.ForgotPasswordViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.LoginViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.RegisterViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.ResetPasswordViemModel;

namespace NTierSardırımRes.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                // Şifre ve şifre tekrar alanlarının eşleştiğini kontrol et
                if (model.Password != model.PasswordConfirmed)
                {
                    ModelState.AddModelError(string.Empty, "Şifreler uyuşmuyor.");
                    return View(model);
                }

                // Kullanıcı adının (Email) veritabanında kullanılıp kullanılmadığını kontrol et
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Bu e-posta adresi zaten kullanımda.");
                    return View(model);
                }

                // Yeni kullanıcıyı oluştur
                var user = new AppUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Başarılı bir şekilde kaydedilen kullanıcıyı oturum açma işlemine tabi tut
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Account");
                }

                // Kayıt işlemi başarısız olduysa, hata iletisini model state'e ekle
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // ModelState.IsValid false olduğunda veya kayıt işlemi başarısız olduğunda, aynı sayfayı tekrar göster
            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    // Kullanıcı bulunamadı
                    ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                    return View(model);
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    // Şifre sıfırlama başarılı oldu, kullanıcıyı giriş sayfasına yönlendir
                    TempData["SuccessMessage"] = "Şifre sıfırlama işlemi başarılı. Yeni şifrenizle giriş yapabilirsiniz.";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    // Şifre sıfırlama başarısız oldu, hata mesajlarını modele ekle
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            // Model geçersiz ise, formu tekrar göster
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                // Token veya email bilgisi yoksa, hata sayfasına yönlendir
                return RedirectToAction("Error", "Home");
            }

            var model = new ResetPasswordVM { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        // Şifre sıfırlama başarılı, kullanıcıyı giriş sayfasına yönlendir
                        return RedirectToAction("Login", "Account");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    // Kullanıcı bulunamadı
                    ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                }
            }
            // Model geçersizse, formu tekrar göster
            return View(model);
        }

    }
}

