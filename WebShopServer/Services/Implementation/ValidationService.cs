using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebShop.Data;
using WebShop.Services.Interface;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Services.Implementation
{
    public class ValidationService : IValidationService
    {
        private readonly ApplicationDbContext db;

        public ValidationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> ProductIdValid(int id)
        {
            return await db.Product.FindAsync(id) != null;
        }


        public async Task<bool> ProductCategoryIdValid(int id)
        {
            return await db.ProductCategory.FindAsync(id) != null;
        }

        /// <summary>
        /// Manipulacija izlaznog objekta
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ApiResponseViewModel ValidationMsgResponse(ModelStateDictionary.ValueEnumerable input)
        {
            ApiResponseViewModel response = new ApiResponseViewModel();
            foreach (var modelState in input)
            {
                foreach (var error in modelState.Errors)
                {
                    response.Message += ", " + error.ErrorMessage;
                }
            }
            return response;
        }


    }
}
