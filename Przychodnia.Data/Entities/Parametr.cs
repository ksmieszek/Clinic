using System.ComponentModel.DataAnnotations;

namespace Przychodnia.Data.Entities
{
    public class Parametr
    {        
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Pozycja { get; set; }
        [Display(Name = "Wartość ")]
        public string Wartosc { get; set; }
        public string Opis { get; set; }
        public bool Aktywny { get; set; }
    }
}
