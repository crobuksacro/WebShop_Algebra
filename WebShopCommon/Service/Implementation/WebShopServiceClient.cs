using Newtonsoft.Json;
using WebShopCommon.Models.Binding;
using WebShopCommon.Models.ViewModel;
using WebShopCommon.Service.Interface;

namespace WebShopCommon.Service.Implementation
{
    public class WebShopServiceClient : BaseServiceClient, IWebShopServiceClient
    {
        public WebShopServiceClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<TokenResponse> GetToken(TokenLoginBinding model)
        {
            string targetUrl = $"/api/UserApi/token";
            var response = await DoRequest(targetUrl, HttpMethod.Post, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Dohvat tokena nije uspio");
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TokenResponse>(content);
        }

        public async Task<List<ProductCategoryViewModel>> ProductCategorys(string token)
        {
            string targetUrl = $"/api/AdminApi/product-categorys";
            var response = await DoRequest(targetUrl, HttpMethod.Get, token);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProductCategoryViewModel>>(content);
        }

        public async Task<List<ProductViewModel>> GetProducts(string token)
        {
            string targetUrl = $"/api/homeapi/products";
            var response = await DoRequest(targetUrl, HttpMethod.Get, token);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProductViewModel>>(content);
        }

    }
}
