using System.ComponentModel.DataAnnotations;
using WebShop.Services.Interface;

namespace WebShop.Validation
{
    public class ShoppingCartIdValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));


            if (value is int)
            {
                int id = (int)value;
                if (validationService.ShoppingCartIdValid(id).Result)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("ShoppingCartIdValid nije pronadjen!");

            }

            return new ValidationResult("ShoppingCartIdValid Id nije validan!");

        }
    }
}
