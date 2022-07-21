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
        private readonly IUserSevice userSevice;
        private readonly SignInManager<ApplicationUser> signInManager;
        public UserController(IUserSevice userSevice, SignInManager<ApplicationUser> signInManager)
        {
            this.userSevice = userSevice;
            this.signInManager = signInManager;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserBinding model)
        {
            var result = await userSevice.CreateUserAsync(model, Roles.BasicUser);
            if(result != null)
            {
                await signInManager.SignInAsync(result, true);
                return RedirectToAction("Index", "Home");
            }


            return View();
        }
    }
}
