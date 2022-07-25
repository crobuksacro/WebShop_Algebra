using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models.Dbo;
using WebShop.Models.ViewModel;
using WebShop.Services.Interface;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeAPIController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly UserManager<ApplicationUser> userManager;
        public HomeAPIController(ILogger<HomeController> logger, IProductService productService, UserManager<ApplicationUser> userManager)
        {
            this.productService = productService;
            this.userManager = userManager;
            _logger = logger;
        }



        [Route("products")]
        [ProducesResponseType(typeof(List<ProductViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Products()
        {
            return Ok(await productService.GetProductsAsync());
        }

      



    }
}