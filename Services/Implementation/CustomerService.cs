using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShop.Services.Interface;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public CustomerService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// Dohvati adresu korisnika
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<AdressViewModel> GetAdress(string userId)
        {
            var adress = await db.Adress.FirstOrDefaultAsync(x => x.ApplicationUser.Id == userId);
            return mapper.Map<AdressViewModel>(adress);

        }


        public async Task UpdateUserPhone(string userId, string phone)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Id == userId);
            user.PhoneNumber = phone;
            await db.SaveChangesAsync();

        }

        public async Task<AdressViewModel> AddAdress(AdressBinding model)
        {
            var user = await db.Users
                .Include(x => x.Adress)
                .FirstOrDefaultAsync(x => x.Id == model.UserId);
            if (user == null)
            {
                return null;
            }

            var dbo = mapper.Map<Adress>(model);
            user.Adress.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<AdressViewModel>(dbo);
        }

    }
}
