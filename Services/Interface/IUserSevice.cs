using WebShop.Models.Binding;
using WebShop.Models.Dbo;

namespace WebShop.Services.Interface
{
    public interface IUserSevice
    {
        Task<ApplicationUser?> CreateUserAsync(UserBinding model, string role);
    }
}