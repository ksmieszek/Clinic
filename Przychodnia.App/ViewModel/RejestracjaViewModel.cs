using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.ViewModel
{
    public class RejestracjaViewModel
    {
        [Required(ErrorMessage = "Imie jest wymagane")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Nazwisko { get; set; }
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)\\S{8,20}$", ErrorMessage = "Hasło musi zawierać co najmniej jedną: dużą i małą literę, cyfrę oraz mieć długość 8-20 znaków")]
        [Required(ErrorMessage = "Haslo jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same.")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{11})$", ErrorMessage = "Nieprawidłowy numer pesel")]

        [Required(ErrorMessage = "Pesel jest wymagany")]
        public string Pesel { get; set; }
        [RegularExpression(@"^\+48\(?([0-9]{9})$", ErrorMessage = "Nieprawidłowy numer telefonu (pamietaj o dodaniu numeru kierunkowego)")]
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]

        public string Telefon { get; set; }
    }
}
