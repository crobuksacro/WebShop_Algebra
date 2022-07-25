using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Models.Binding;
using WebShop.Models.ViewModel;
using WebShop.Services.Interface;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(CorsPolicy.AllowAll)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
    public class AdminApiController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;


        public AdminApiController(IProductService productService, IMapper mapper)
        {
            this.mapper = mapper;
            this.productService = productService;
        }

        [Route("product-categorys")]
        [ProducesResponseType(typeof(List<ProductCategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductCategorysAsync()
        {
            return Ok(await productService.GetProductCategorysAsync());
        }


        [HttpPost]
        [Route("product")]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProductAsync(ProductBinding model)
        {
            return Ok(await productService.AddProductAsync(model));
        }

        [HttpPut]
        [Route("product")]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProductAsync(ProductUpdateApiBinding model)
        {
            return Ok(await productService.UpdateProductAsync(model));
        }

        [HttpGet]
        [Route("product/{id}")]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            return Ok(await productService.GetProductAsync(id));
        }

    }
}