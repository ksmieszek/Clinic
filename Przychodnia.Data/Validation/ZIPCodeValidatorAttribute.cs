using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Validation
{
    public class ZIPCodeValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string kod = value.ToString();
                if (kod.Contains("-"))
                {
                    string[] tab = kod.Split('-');
                    if (String.IsNullOrEmpty(tab[0]))
                    {
                        return new ValidationResult("KOD POCZTOWY nie zawiera prawidłowej treści przed znakiem '-'");
                    }
                    if (String.IsNullOrEmpty(tab[1]))
                    {
                        return new ValidationResult("KOD POCZTOWY nie zawiera prawidłowej treści po znaku '-'");
                    }
                    if (tab[0].Length != 2)
                    {
                        return new ValidationResult("KOD POCZTOWY zawiera nieprawidłową treści przed znakiem '-'");
                    }
                    if (tab[1].Length != 3)
                    {
                        return new ValidationResult("KOD POCZTOWY zawiera nieprawidłową treści po znaku '-'");
                    }
                    int tmp;
                    if (!int.TryParse(tab[0], out tmp))
                    {
                        return new ValidationResult("KOD POCZTOWY zawiera nieprawidłową treści przed znakiem '-'");
                    }
                    if (!int.TryParse(tab[1], out tmp))
                    {
                        return new ValidationResult("KOD POCZTOWY zawiera nieprawidłową treści po znaku '-'");
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    return new ValidationResult("KOD POCZTOWY jest niepoprawny");
                }
            }
            return new ValidationResult("Proszę podać kod pocztowy");
        }
    }
}
