using System.ComponentModel.DataAnnotations;
using WebShop.Extensions;

namespace WebShop.Validation
{
    public class StringGreaterThanThanSeven : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            if (value is string)
            {
                string input = (string)value;
                if (input.StringGreaterThan(7))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Unos ima manje od 7 znakova!");
            }

            return new ValidationResult("Unos nije validan!");

        }
    }
}
