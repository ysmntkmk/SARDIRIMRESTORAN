using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

using NTierSardırımRes.Common.EmailSender;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.ForgotPasswordViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.LoginViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.RegisterViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.ResetPasswordViemModel;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;
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


        public IActionResult Index()
        {
            return View();
        }

        // Giriş sayfasını GET isteği ile gösterir
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
                    if (!isEmailConfirmed)
                    {
                        ModelState.AddModelError(string.Empty, "Hesabınızı doğrulamak için lütfen e-posta adresinizi kontrol edin.");
                        return View(model);
                    }

                    var isLockedOut = await _userManager.IsLockedOutAsync(user);
                    if (isLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Hesabınız kilitlenmiştir. Lütfen daha sonra tekrar deneyin.");
                        return View(model);
                    }

                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        // Başarılı giriş işlemi tamamlandığında, returnUrl'i kontrol ederek istenilen sayfaya yönlendirme yapın
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home"); // Varsayılan olarak anasayfaya yönlendirme yapılacak
                        }
                    }
                    else if (result.RequiresTwoFactor)
                    {
                        // İki faktörlü kimlik doğrulama gerekiyorsa
                        // İkinci faktör doğrulama adımına yönlendirme yapabilirsiniz
                        // Örneğin: return RedirectToAction("TwoFactorAuthentication", "Account");
                        ModelState.AddModelError(string.Empty, "İki faktörlü kimlik doğrulama gereklidir.");
                        return View(model);
                    }
                    else
                    {
                        // Diğer giriş hatalarını işleyin
                        ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                        return View(model);
                    }
                }
                else
                {
                    // Kullanıcı bulunamadıysa
                    ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                    return View(model);
                }
            }

            // ModelState.IsValid false ise, model doğrulama hatası içeriyor demektir
            // Ancak, yukarıdaki hata kontrolü zaten geçersiz giriş denemesi, hesap kilitlenmesi gibi durumlar için ek hata eklemişti
            // Bu nedenle, ModelState.IsValid false ise, modelin diğer zaten tanımlı hatalarla birlikte gösterilmesi yeterlidir
            return View(model);
        }


        // Kayıt sayfasını GET isteği ile gösterir
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

                AppUser user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName,

                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var encodeToken = HttpUtility.UrlEncode(token.ToString());

                    string confirmationLink = Url.Action("Confirmation", "Account", new { id = user.Id, token = encodeToken }, Request.Scheme);



                    EmailSender.SendEmail(model.Email, "Üyelik Aktivasyon", $"Lütfen linki tıklayın. {confirmationLink}");

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return View(model);
                }


            }
            else
            {
                return View(model);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Confirmation(int id, string token)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var decodeToken = HttpUtility.UrlDecode(token);
                var result = await _userManager.ConfirmEmailAsync(user, decodeToken);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            //eğer kullanıcı varsa ilgili kullanıcının EmailConfimation özelliğini true yap.
            return RedirectToAction("Index", "Home");

        }

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

        //Şifremi unuttum işlemini POST isteği ile gerçekleştirir
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
                //await emailSender.SendEmailAsync(model.Email, "Şifre Sıfırlama", $"Şifrenizi sıfırlamak için lütfen linki tıklayın. {resetPasswordLink}");


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
