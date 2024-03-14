using Castle.Core.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NTierSardırımRes.Common.EmailSender;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.ForgotPasswordViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.LoginViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.RegisterViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.ResetPasswordViemModel;
using System.Text.Encodings.Web;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NTierSardırımRes.MVC.Controllers
{
    // Hesap işlemleri için Controller sınıfı
    public class AccountController : Controller
    {
        // Kullanıcı yönetimi işlemleri için UserManager ve SignInManager nesneleri
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly EmailSender _emailSender;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, EmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender; // EmailSender bağımlılığını enjekte edin
        }

        // Kayıt sayfasını GET isteği ile gösterir
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Kayıt işlemini POST isteği ile gerçekleştirir
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = encodedToken }, Request.Scheme);

                    // Doğrulama e-postası gönderme işlemi
                    await _emailSender.SendEmailAsync(model.Email, "Hesabınızı doğrulayın", $"Lütfen hesabınızı doğrulamak için <a href='{HtmlEncoder.Default.Encode(confirmationLink)}'>buraya tıklayın</a>.");

                    // Kullanıcıyı bilgilendirme mesajı
                    ViewBag.Message = "Kaydınız başarıyla oluşturuldu. Lütfen e-posta adresinize gönderilen doğrulama bağlantısını kullanarak hesabınızı doğrulayın.";
                    return View("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }



        // Giriş sayfasını GET isteği ile gösterir
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Giriş işlemini POST isteği ile gerçekleştirir
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        // Giriş başarılıysa ana sayfaya yönlendir
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            // Giriş başarısız ise, geçersiz giriş denemesi hatası ekle
            ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            return View(model);
        }


        // E-posta doğrulama işlemi için Confirmation metodunu GET isteği ile gösterir
        [HttpGet]
        public async Task<IActionResult> Confirmation(int id, string token)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                var decodeToken = System.Web.HttpUtility.UrlDecode(token);
                var result = await _userManager.ConfirmEmailAsync(user, decodeToken);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login), "Account");
                }
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        // Kullanıcıyı çıkış yapmaya yönlendirir
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        // Şifremi unuttum sayfasını GET isteği ile gösterir
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // Şifremi unuttum işlemini POST isteği ile gerçekleştirir
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                    return View(model);
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var encodedToken = System.Web.HttpUtility.UrlEncode(token.ToString());
                string resetPasswordLink = Url.Action(nameof(ResetPassword), "Account", new { token = encodedToken, email = user.Email }, Request.Scheme);

                var emailSender = new EmailSender(); // EmailSender sınıfının bir örneğini oluşturun
                await emailSender.SendEmailAsync(model.Email, "Şifre Sıfırlama", $"Şifrenizi sıfırlamak için lütfen linki tıklayın. {resetPasswordLink}");


                TempData["SuccessMessage"] = "Şifre sıfırlama bağlantısı e-posta adresinize gönderildi.";
                return RedirectToAction(nameof(Login), "Account");
            }

            return View(model);
        }

        // Şifre sıfırlama sayfasını GET isteği ile gösterir
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                return RedirectToAction(nameof(Error), "Home");
            }

            var model = new ResetPasswordVM { Token = token, Email = email };
            return View(model);
        }

        // Şifre sıfırlama işlemini POST isteği ile gerçekleştirir
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
                        return RedirectToAction(nameof(Login), "Account");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                }
            }

            return View(model);
        }
    }
}
