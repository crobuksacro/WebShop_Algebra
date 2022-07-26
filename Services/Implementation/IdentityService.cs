using WebShop.Models;
using WebShop.Models.Dbo;
using WebShop.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace WebShop.Services.Implementation
{
    public class IdentityService : IIdentityService
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public IdentityService(IServiceScopeFactory scopeFactory)
        {

            using (var scope = scopeFactory.CreateScope())
            {
                this.userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                this.roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                CreateRoleAsync(Roles.Admin).Wait();
                CreateRoleAsync(Roles.BasicUser).Wait();
                CreateRoleAsync(Roles.Employee).Wait();

                //CreateUser()
                CreateUserAsync(new ApplicationUser
                {
                    Firstname = "Ivan",
                    Lastname = "Radoš",
                    Email = "ivan@neostar.com",
                    UserName = "ivan@neostar.com",
                    DOB = DateTime.Now.AddYears(-35),
                    PhoneNumber = "+3859912345678",
                    Adress = new List<Adress>
                    {
                        new Adress
                        {
                            City = "Vg",
                            Street = "Zagrebacka",
                        }
                    }

                }, "Pa$$word321", Roles.Admin).Wait();

                CreateUserAsync(new ApplicationUser
                {
                    Firstname = "Ivan",
                    Lastname = "Radoš",
                    Email = "ivan2@neostar.com",
                    UserName = "ivan2@neostar.com",
                    DOB = DateTime.Now.AddYears(-35),
                    PhoneNumber = "+3859912345678",
                    Adress = new List<Adress>
                    {
                        new Adress
                        {
                            City = "Vg",
                            Street = "Zagrebacka",
                        }
                    }

                }, "Pa$$word321", Roles.Employee).Wait();

                CreateUserAsync(new ApplicationUser
                {
                    Firstname = "Ivan",
                    Lastname = "Radoš",
                    Email = "ivan@ivan.hr",
                    UserName = "ivan@ivan.hr",
                    DOB = DateTime.Now.AddYears(-35),
                    PhoneNumber = "+3859912345278", 
                    Adress = new List<Adress>
                    {
                        new Adress
                        {
                            City = "Vg",
                            Street = "Zagrebacka",
                        }
                    }

                }, "Pa$$w0rd", Roles.BasicUser).Wait();
            }


        }


        public async Task CreateRoleAsync(string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = role

                });
            }

        }


        public async Task CreateUserAsync(ApplicationUser user, string password, string role)
        {

            //Prvo provjeri ima li korisnika sa istim emailom u bazi
            var find = await userManager.FindByEmailAsync(user.Email);
            if (find != null)
            {
                return;
            }
 

            user.EmailConfirmed = true;
            //Izraditi novog korisnika
            var createdUser = await userManager.CreateAsync(user, password);
            
            //Provjeriti jeli korisnik uspješno dodan
            if (createdUser.Succeeded)
            {
                //Dodati korisnika u rolu
                var userAddedToRole = await userManager.AddToRoleAsync(user, role);
                if (!userAddedToRole.Succeeded)
                {
                    throw new Exception("Korisnik nije dodan u rolu!");
                }
            }



        }
    }
}
