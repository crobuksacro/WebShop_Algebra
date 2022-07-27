using System.ComponentModel.DataAnnotations;
using WebShop.Services.Interface;

namespace WebShop.Validation
{
    public class ProductCategoryIdValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var validationService = (IProductService)validationContext.GetService(typeof(IProductService));


            if (value is int)
            {
                int id = (int)value;
                if (validationService.ProductIdValid(id).Result)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Product nije pronadjen!");

            }

            return new ValidationResult("Product Id nije validan!");

        }
    }
}
