using System.ComponentModel.DataAnnotations;

namespace Przychodnia.Data.Entities
{
    public class CennikLekarz
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        public double Cena { get; set; }
        public Uzytkownik Lekarz { get; set; }
        public bool Aktywny { get; set; } = true;
    }
}
