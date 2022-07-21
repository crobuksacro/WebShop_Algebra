using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShop.Services.Interface;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    public class UserApiController : ControllerBase
    {
        private readonly IUserSevice userSevice;
        private readonly SignInManager<ApplicationUser> signInManager;
        public UserApiController(IUserSevice userSevice, SignInManager<ApplicationUser> signInManager)
        {
            this.userSevice = userSevice;
            this.signInManager = signInManager;
        }



        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registration([FromBody]UserBinding model)
        {
            return Ok(await userSevice.CreateApiUserAsync(model, Roles.BasicUser));
        }
    }
}
