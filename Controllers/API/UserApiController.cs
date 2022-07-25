using Microsoft.AspNetCore.Authorization;
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

        //[AllowAnonymous]
        [Route("token")]
        [HttpPost]
        public async Task<IActionResult> Token([FromBody] TokenLoginBinding model)
        {
            if (ModelState.IsValid)
            {
                var token = await userSevice.GetToken(model);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return BadRequest(new
                    {
                        Msg = "Invalid username or password!",
                    });
                }

                return Ok(new { token = token });
            }

            return BadRequest();
        }


        //[AllowAnonymous]
        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registration([FromBody]UserBinding model)
        {
            return Ok(await userSevice.CreateApiUserAsync(model, Roles.BasicUser));
        }
    }
}
