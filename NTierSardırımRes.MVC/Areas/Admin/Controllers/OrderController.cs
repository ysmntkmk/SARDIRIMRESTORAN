using Microsoft.AspNetCore.Mvc;

namespace NTierSardırımRes.MVC.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
