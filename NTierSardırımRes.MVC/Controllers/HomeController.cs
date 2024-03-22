using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.Common;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models;
using NTierSardırımRes.MVC.Models.ViewModels.LoginViewModel;
using NTierSardırımRes.MVC.Models.ViewModels.LoginViewModel;
using System.Diagnostics;
using System.Web;

namespace NTierSardırımRes.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
       
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
           
        }

        public async Task<IActionResult> Index()
        {
           
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }


    }
}
