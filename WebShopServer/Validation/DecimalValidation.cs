using System.ComponentModel.DataAnnotations;
using WebShop.Extensions;

namespace WebShop.Validation
{
    public class DecimalValueGreaterThanZero : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            if (value is decimal)
            {
                decimal input = (decimal)value;
                if (input.GreaterThan(0))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Unos je manji od 0!");
            }

            return new ValidationResult("Unos nije validan!");

        }
    }
}
