using System.ComponentModel.DataAnnotations;
using WebShop.Services.Interface;

namespace WebShop.Validation
{
    public class ProductCategoryIdValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));


            if (value is int)
            {
                int id = (int)value;
                if (validationService.ProductCategoryIdValid(id).Result)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("ProductCategory nije pronadjen!");

            }

            return new ValidationResult("ProductCategory Id nije validan!");

        }
    }
}
