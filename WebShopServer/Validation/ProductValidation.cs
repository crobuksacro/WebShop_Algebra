using System.ComponentModel.DataAnnotations;
using WebShop.Extensions;
using WebShop.Models.Binding.Interface;
using WebShop.Services.Interface;

namespace WebShop.Validation
{
    public class ProductIdValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));


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

    public class ProductValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));


            if (value is IProduct)
            {
                IProduct product = (IProduct)value;

                if (validationService.ProductCategoryIdValid(product.ProductCategoryId).Result && product.Value.GreaterThan(0))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Product nije validan!");

            }

            return new ValidationResult("Product je validan!");

        }
    }

}
