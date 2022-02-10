using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Przychodnia.Data.Validation
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string telefon = value.ToString();

                var cleaned = RemoveNonNumeric(telefon);

                if (cleaned.Length == 9)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Telefon jest niepoprawny");
            }
            return new ValidationResult("Proszę podać telefon");
        }

        public static string RemoveNonNumeric(string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", "");
        }
    }
}
