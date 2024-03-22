using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierSardırımRes.Common;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.MVC.Models.ViewModels.LoginViewModel;

namespace NTierSardırımRes.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                //branch oluşturup bu işlemi gönderin.
                //kullanıcı veritabanında var mı?
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return Unauthorized();
                //kullacının şifre kontrolü
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!passwordCheck)
                    return Unauthorized();

                //kullanıcıya ait token oluşturulacak.
                var token = JwtProvider.GetJWT(user);

                return Ok(token);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
