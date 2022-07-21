using WebShop.Models;
using WebShop.Models.Binding;
using WebShop.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;


        public AdminApiController(IProductService productService, IMapper mapper)
        {
            this.mapper = mapper;
            this.productService = productService;
        }

        [Route("product-categorys")]
        public async Task<IActionResult> ProductCategorys()
        {
            return Ok(await productService.GetProductCategorysAsync());
        }


    }
}