using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebShop.Data;
using WebShop.Models;
using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShop.Models.Dto;
using WebShop.Models.ViewModel;
using WebShop.Services.Interface;


namespace WebShop.Services.Implementation
{
    public class UserSevice : IUserSevice
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;
        private SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext db;
        private readonly AppConfig appSettings;

        public UserSevice(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper,
            SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, IOptions<AppConfig> appSettings)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.db = db;
            this.appSettings = appSettings.Value;
        }

        public async Task<ApplicationUserViewModel> GetUser(string id)
        {
            var dboUser = await db.Users
                .Include(x => x.Adress)
                .FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<ApplicationUserViewModel>(dboUser);
        }


        public async Task<ApplicationUserViewModel> GetUser(ClaimsPrincipal user)
        {
            var userId = userManager.GetUserId(user);
            return await GetUser(userId);

        }


        /// <summary>
        /// Dohvati token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> GetToken(TokenLoginBinding model)
        {
            var signInResult = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (signInResult.Succeeded)
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName);
                //var user = await userManager.getu(model.UserName);

                if (user != null)
                {
                    var role = await userManager.GetRolesAsync(user);
                    DateTime expires = DateTime.Now.AddMinutes(30);
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, model.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Expiration, expires.ToString()),
                        new Claim(ClaimTypes.Role, role.First()),
                    };

                    var keyBytes = Encoding.UTF8.GetBytes(appSettings.Identity.Key);
                    var theKey = new SymmetricSecurityKey(keyBytes);
                    var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(appSettings.AppUrl, appSettings.AppUrl, claims, expires: expires, signingCredentials: creds);
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }


            }
            return string.Empty;
        }

        public async Task<ApplicationUserViewModel?> CreateApiUserAsync(UserBinding model, string role)
        {
            var result = await CreateUserAsync(model, role);
            if (result == null)
            {
                return null;
            }
            return mapper.Map<ApplicationUserViewModel>(result);

        }

        public async Task<ApplicationUserViewModel?> CreateApiUserAsync(ApiBasicDataUser model)
        {
            var result = await CreateUserAsync(model, Roles.BasicUser);
            if (result == null)
            {
                return null;
            }
            return mapper.Map<ApplicationUserViewModel>(result);

        }


        public async Task<ApplicationUser?> CreateUserAsync(ApiBasicDataUser model, string role)
        {
            var find = await userManager.FindByEmailAsync(model.Email);
            if (find != null)
            {
                return null;
            }

            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
            };


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
