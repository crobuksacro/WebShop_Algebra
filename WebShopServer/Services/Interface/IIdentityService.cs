using WebShop.Models.Dbo;

namespace WebShop.Services.Interface
{
    public interface IIdentityService
    {
        Task CreateRoleAsync(string role);
        Task CreateUserAsync(ApplicationUser user, string password, string role);
    }
}