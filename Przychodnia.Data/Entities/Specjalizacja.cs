using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Przychodnia.Data.Entities
{
    public class Specjalizacja
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nazwa { get; set; }
        [MaxLength(1000)]
        public string Opis { get; set; }
        public List<Uzytkownik> Lekarze { get; set; }
        public bool Aktywna { get; set; }
    }
}
