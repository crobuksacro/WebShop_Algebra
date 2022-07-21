using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShop.Models.ViewModel;
using WebShop.Services.Interface;

namespace WebShop.Services.Implementation
{
    public class UserSevice : IUserSevice
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public UserSevice(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }


        public async Task<ApplicationUserViewModel?> CreateApiUserAsync(UserBinding model, string role)
        {
            var result =await CreateUserAsync(model, role);
            if(result == null)
            {
                return null;
            }
            return mapper.Map<ApplicationUserViewModel>(result);

        }


        public async Task<ApplicationUser?> CreateUserAsync(UserBinding model, string role)
        {
            var find = await userManager.FindByEmailAsync(model.Email);
            if (find != null)
            {
                return null;
            }
            var user = mapper.Map<ApplicationUser>(model);
            var adress = mapper.Map<Adress>(model.UserAdress);
            user.Adress = new List<Adress>() { adress };
            var createdUser = await userManager.CreateAsync(user, model.Password);
            if (createdUser.Succeeded)
            {
                var userAddedToRole = await userManager.AddToRoleAsync(user, role);
                if (!userAddedToRole.Succeeded)
                {
                    throw new Exception("Korisnik nije dodan u rolu!");
                }
            }
            return user;
        }

    }
}
