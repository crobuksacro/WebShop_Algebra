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

        public HomeController(ILogger<HomeController> logger, IWebShopServiceClient webShopServiceClient)
        {
            this.webShopServiceClient = webShopServiceClient;

            var token = webShopServiceClient.GetToken(
                new TokenLoginBinding
                {
                    UserName = "ivan@neostar.com",
                    Password = "Pa$$word321"

                }).Result;

            var categorys = webShopServiceClient.ProductCategorys(token.Token).Result;


            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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