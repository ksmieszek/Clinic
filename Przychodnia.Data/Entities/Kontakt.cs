using Przychodnia.Data.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Entities
{
    public class Kontakt
    {
        public int Id { get; set; }
        public int? UzytkownikId {get; set;}
        [Display(Name = "Użytkownik")]
        public Uzytkownik Uzytkownik { get; set; }
        public int? AdresId { get; set; }
        public Adres Adres { get; set; }

        [RegularExpression(@"^\+48\(?([0-9]{9})$", ErrorMessage = "Nieprawidłowy numer telefonu (pamietaj o dodaniu numeru kierunkowego)")]
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]      
        public string Telefon { get; set; }
        [EmailAddress]
        public string Email { get; set; }        
        public string Opis { get; set; }
        public bool Aktywny { get; set; }
        [PriorityAttribute]
        [Display(Name = "Pozycja Wyświetlania")]
        public int? PozycjaWyswietlania { get; set; }

    }
}
