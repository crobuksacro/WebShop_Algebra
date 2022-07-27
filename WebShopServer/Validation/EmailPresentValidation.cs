using System.ComponentModel.DataAnnotations;
using WebShop.Services.Interface;

namespace WebShop.Validation
{
    public class EmailPresentValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var validationService = (IUserSevice)validationContext.GetService(typeof(IUserSevice));


            if (value is string)
            {
                string email = (string)value;
                if (validationService.EmailPresentValidation(email).Result)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Company Id nije pronadjen!");

            }

            return new ValidationResult("Emial nije validan!");

        }
    }
}
