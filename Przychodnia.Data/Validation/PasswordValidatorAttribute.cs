using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Validation
{

    public class PasswordValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string password = value.ToString();

                if (!ValidatePassword(password))
                {
                    return new ValidationResult("Hasło nie spełnia wymogów");
                }
                else
                    return ValidationResult.Success;
            }
            return new ValidationResult("Hasło jest wymagane");
        }

        public static bool ValidatePassword(string password)
        {
            bool toRet = false;
            try
            {
                if (password.Length > 8)
                {
                    var charArray = password.ToCharArray();
                    var uLeter = false;
                    foreach (Char c in charArray)
                    {
                        if (Char.IsUpper(c))
                        {
                            uLeter = true;
                        }
                    }
                    var lLeter = false;
                    foreach (Char c in charArray)
                    {
                        if (Char.IsLower(c))
                        {
                            lLeter = true;
                        }
                    }
                    var digit = false;
                    foreach (Char c in charArray)
                    {
                        if (Char.IsDigit(c))
                        {
                            digit = true;
                        }
                    }
                    var special = false;
                    foreach (Char c in charArray)
                    {
                        switch (c)
                        {
                            case '!':
                            case '@':
                            case '#':
                            case '$':
                            case '%':
                            case '^':
                            case '&':
                            case '*':
                                special = true; break;
                        }
                    }

                    if (uLeter && lLeter && digit && special == true)
                    {
                        toRet = true;
                    }
                }
            }
            catch (Exception)
            {
                toRet = false;
            }
            return toRet;
        }
    }
}
