using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Przychodnia.Intranet.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required()]
        public int Id { get; set; }
        [Required(ErrorMessage = "Haslo jest wymagane")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)\\S{8,20}$", ErrorMessage = "Hasło musi zawierać co najmniej jedną: dużą i małą literę, cyfrę oraz mieć długość 8-20 znaków")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same.")]
        public string ConfirmPassword { get; set; }
    }
}
