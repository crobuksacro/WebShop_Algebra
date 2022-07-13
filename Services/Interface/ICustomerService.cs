using WebShop.Models.ViewModel;

namespace WebShop.Services.Interface
{
    public interface ICustomerService
    {
        Task<AdressViewModel> GetAdress(string userId);
    }
}