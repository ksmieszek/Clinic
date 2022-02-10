using Microsoft.EntityFrameworkCore;
using Przychodnia.Data.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Entities
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public string Imie { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)\\S{8,20}$", ErrorMessage = "Hasło musi zawierać co najmniej jedną: dużą i małą literę, cyfrę oraz mieć długość 8-20 znaków")]
        [Display(Name = "Hasło")]
        //[PasswordValidatorAttribute]
        public string Haslo { get; set; }
        public string HasloSalt { get; set; }
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{1,6}$", ErrorMessage = "Nieprawidłowy adres Email")]
        public string Email { get; set; }
        public int RolaId { get; set; }
        public Rola Rola { get; set; }
        [PeselValidatorAttribute]
        //[RegularExpression("^\\d{11,11}$", ErrorMessage = "Nieprawidłowy numer pesel")]
        public string Pesel { get; set; }
        public int? PlecId { get; set; }
        [Display(Name = "Płeć")]
        public Plec Plec { get; set; }
        [RegularExpression(@"^\+48\(?([0-9]{9})$", ErrorMessage = "Numer telefonu musi być zapisany w postaci +48XXXXXXXXX")]
        public string Telefon { get; set; }
        [Display(Name = "Data urodzenia")]
        public DateTime DataUrodzenia { get; set; }
        public int? AdresId { get; set; }
        public Adres Adres { get; set; }
        public int? SpecjalizacjeId { get; set; }
        public Specjalizacja Specjalizacje { get; set; }
        public int? PoradnieId { get; set; }
        public Poradnia Poradnie { get; set; }
        DateTime Wygasa { get; set; }
        public string TokenAktywacyjny { get; set; }
        public bool CzyAktywny { get; set; }
        public int? TytulNaukowyId { get; set; }
        public TytulNaukowy TytulNaukowy { get; set; }
        public string FotoUrl { get; set; }
        public bool Promowany { get; set; }
    }
}
