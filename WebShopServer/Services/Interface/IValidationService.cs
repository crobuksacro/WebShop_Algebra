using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Services.Interface
{
    public interface IValidationService
    {
        Task<bool> UsersIdValid(string id);
        Task<bool> ShoppingCartIdValid(int id);
        Task<bool> EmailExists(string email);
        Task<bool> ProductIdValid(int id);
        Task<bool> ProductCategoryIdValid(int id);
        ApiResponseViewModel ValidationMsgResponse(ModelStateDictionary.ValueEnumerable input);
    }
}