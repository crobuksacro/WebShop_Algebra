using WebShop.Models;
using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShop.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebShop.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly UserManager<ApplicationUser> userManager;
        public HomeController(ILogger<HomeController> logger, IProductService productService, UserManager<ApplicationUser> userManager)
        {
            this.productService = productService;
            this.userManager = userManager;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> SuspendShoppingCartItem(int id)
        {
           await productService.SuspendShoppingCartItem(id);
            return RedirectToAction("ShoppingCart");
        }


        [HttpGet]
        public async Task<IActionResult> SuspendShoppingCart(int id)
        {
            var shoppingCart = await productService.SuspendShoppingCart(id);
            return RedirectToAction("ShoppingCart");
        }


        public IActionResult Index()
        {
            return View(productService.GetProductsAsync().Result);
        }

        [Authorize]
        public async Task<IActionResult> ItemView(int id)
        {
            var product = await productService.GetProductAsync(id);

            return View(product);
        }


        [Authorize]
        public async Task<IActionResult> ShoppingCart()
        {
            var shoppingCart = await productService.GetShoppingCartAsync(userManager.GetUserId(User));
            return View(shoppingCart);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ShoppingCart(OrderBinding model)
        {
            var order = await productService.AddOrder(model);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ItemView(ShoppingCartBinding model)
        {
            model.UserId = userManager.GetUserId(User);
            var product = await productService.AddShoppingCartAsync(model);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}