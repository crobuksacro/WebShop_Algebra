using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShopClientApp.Models;
using WebShopCommon.Models.Binding;
using WebShopCommon.Service.Interface;

namespace WebShopClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWebShopServiceClient webShopServiceClient;
        private readonly string token;


        public HomeController(ILogger<HomeController> logger, IWebShopServiceClient webShopServiceClient)
        {
            this.webShopServiceClient = webShopServiceClient;

             token = webShopServiceClient.GetToken(
                new TokenLoginBinding
                {
                    UserName = "ivan@neostar.com",
                    Password = "Pa$$word321"

                }).Result.Token;

            var categorys = webShopServiceClient.ProductCategorys(token).Result;


            _logger = logger;
        }

        public async  Task<IActionResult> Index()
        {
            var products =await webShopServiceClient.GetProducts(token);


            return View(products);
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