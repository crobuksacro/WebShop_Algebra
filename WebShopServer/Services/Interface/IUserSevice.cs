using System.Security.Claims;
using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShopCommon.Models.Binding;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Services.Interface
{
    public interface IUserSevice
    {
        Task DeleteUserAsync(string id);
        Task<ApplicationUserViewModel?> CreateUserAsync(UserAdminBinding model);
        Task<List<UserRolesViewModel>> GetUserRoles();
        Task<List<ApplicationUserViewModel>> GetUsers();
        Task<ApplicationUser?> CreateUserAsync(UserBinding model, string role);
        Task<ApplicationUserViewModel?> CreateApiUserAsync(ApiBasicDataUser model);
        Task<string> GetToken(TokenLoginBinding model);
        Task<ApplicationUserViewModel> GetUser(string id);
        Task<ApplicationUserViewModel> GetUser(ClaimsPrincipal user);
        Task<ApplicationUser?> CreateUserAsync(ApiBasicDataUser model, string role);
        Task<ApplicationUserViewModel?> CreateApiUserAsync(UserBinding model, string role);
    }
}