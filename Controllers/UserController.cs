using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShop.Services.Interface;

namespace WebShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IIdentityService identityService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(IIdentityService identityService, SignInManager<ApplicationUser> signInManager)
        {
            this.identityService = identityService;
            this.signInManager = signInManager;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserBinding model)
        {
            var result = await identityService.CreateUserAsync(model, Roles.BasicUser);
            await signInManager.SignInAsync(result, true);
            return RedirectToAction("Index", "Home");
        }
    }
}
