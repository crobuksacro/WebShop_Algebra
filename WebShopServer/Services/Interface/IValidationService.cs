using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Services.Interface
{
    public interface IValidationService
    {
        Task<bool> ProductIdValid(int id);
        Task<bool> ProductCategoryIdValid(int id);
        ApiResponseViewModel ValidationMsgResponse(ModelStateDictionary.ValueEnumerable input);
    }
}