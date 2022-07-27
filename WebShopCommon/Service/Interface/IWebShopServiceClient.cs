using WebShopCommon.Models.Binding;
using WebShopCommon.Models.ViewModel;

namespace WebShopCommon.Service.Interface
{
    public interface IWebShopServiceClient
    {
        Task<TokenResponse> GetToken(TokenLoginBinding model);
        Task<List<ProductCategoryViewModel>> ProductCategorys(string token);
        Task<List<ProductViewModel>> GetProducts(string token);
        Task<ApplicationUserViewModel> GetUser(string token);
    }
}