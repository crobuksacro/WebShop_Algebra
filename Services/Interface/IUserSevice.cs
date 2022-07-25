using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShop.Models.ViewModel;

namespace WebShop.Services.Interface
{
    public interface IUserSevice
    {
        Task<ApplicationUser?> CreateUserAsync(UserBinding model, string role);
        Task<ApplicationUserViewModel?> CreateApiUserAsync(UserBinding model, string role);
        Task<string> GetToken(TokenLoginBinding model);
    }
}