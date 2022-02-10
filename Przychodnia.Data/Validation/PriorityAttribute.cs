using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Przychodnia.Data.Validation
{
    public class PriorityAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int priorytet;
                string stringValue = value.ToString();

                bool wynik = int.TryParse(stringValue, out priorytet);

                if(!wynik)
                {
                    return new ValidationResult("Nieprawidłowe dane");
                }

                if (priorytet > 0)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Priorytet jest mniejszy od zera");
            }
            return new ValidationResult("Proszę ustawić priorytet");
        }
    }
}
