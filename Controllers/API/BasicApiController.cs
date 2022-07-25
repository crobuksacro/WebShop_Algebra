using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShop.Models.ViewModel;
using WebShop.Services.Interface;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(CorsPolicy.AllowAll)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.BasicUser)]
    public class BasicApiController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public BasicApiController(IProductService productService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [Route("shopping-cart")]
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCartViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductCategorysAsync(ShoppingCartApiBinding model)
        {
            return Ok(await productService.AddShoppingCartAsync(model, userManager.GetUserId(User)));
        }




    }
}