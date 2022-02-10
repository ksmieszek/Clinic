using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Validation
{
    public class PeselValidatorAttribute : ValidationAttribute
    {
        private static readonly int[] mnozniki = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string pesel = value.ToString();

                if (!ValidatePesel(pesel))
                {
                    return new ValidationResult("Pesel jest nieprawidłowy");
                }
                else
                    return ValidationResult.Success;
            }
            return new ValidationResult("Pesel jest wymagany");
        }

        public static bool ValidatePesel(string pesel)
        {
            bool toRet = false;
            try
            {
                if (pesel.Length == 11)
                {
                    toRet = CountSum(pesel).Equals(pesel[10].ToString());
                }
            }
            catch (Exception)
            {
                toRet = false;
            }
            return toRet;
        }
        private static string CountSum(string pesel)
        {
            int sum = 0;
            for (int i = 0; i < mnozniki.Length; i++)
            {
                sum += mnozniki[i] * int.Parse(pesel[i].ToString());
            }

            int reszta = sum % 10;
            return reszta == 0 ? reszta.ToString() : (10 - reszta).ToString();
        }
    }
}
