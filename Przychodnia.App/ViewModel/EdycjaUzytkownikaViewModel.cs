using System.ComponentModel.DataAnnotations;

namespace Przychodnia.App.ViewModel
{
    public class EdycjaUzytkownikaViewModel
    {
        public int Id { get; set; }
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
        
        [Required(ErrorMessage = "Pesel jest wymagany")]
        [RegularExpression(@"^\(?([0-9]{11})$", ErrorMessage = "Nieprawidłowy numer pesel")]

        public string Pesel { get; set; }
        [RegularExpression(@"^\+48\(?([0-9]{9})$", ErrorMessage = "Nieprawidłowy numer telefonu")]
        public string Telefon { get; set; }
    }
}
