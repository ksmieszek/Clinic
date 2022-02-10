using System.ComponentModel.DataAnnotations;

namespace Przychodnia.Data.Entities
{
    public class CennikPoradnia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        public double Cena { get; set; }
        public Poradnia Poradnia { get; set; }
        public bool Aktywny { get; set; } = true;
    }
}
