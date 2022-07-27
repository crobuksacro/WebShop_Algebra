using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models.Dbo;
using WebShop.Services.Interface;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeAPIController : ControllerBase
    {
        private readonly IUserSevice userSevice;
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly UserManager<ApplicationUser> userManager;
        public HomeAPIController(ILogger<HomeController> logger, IProductService productService,
            UserManager<ApplicationUser> userManager, IUserSevice userSevice)
        {
            this.userSevice = userSevice;
            this.productService = productService;
            this.userManager = userManager;
            _logger = logger;
        }


        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> Products()
        {
            return Ok(await productService.GetProductsAsync());
        }



        [ProducesResponseType(typeof(ApplicationUserViewModel), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("user-info")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await userSevice.GetUser(User));
        }

    }
}