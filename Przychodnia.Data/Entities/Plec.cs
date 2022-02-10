using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Przychodnia.Data.Entities
{
    public class Plec
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        [Display(Name = "Użytkownik")]
        public List<Uzytkownik> Uzytkownicy { get; set; }
        public bool Aktywna { get; set; }
    }
}
