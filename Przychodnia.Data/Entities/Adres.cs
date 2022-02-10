using Przychodnia.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace Przychodnia.Data.Entities
{
    public class Adres
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Miejscowość jest wymagana")]
        [MaxLength(50)]
        [Display(Name = "Miejscowość")]
        public string Miejscowosc { get; set; }
        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        [ZIPCodeValidatorAttribute]
        [Display(Name = "Kod pocztowy")]
        public string KodPocztowy { get; set; }
        //[Required]
        [MaxLength(100)]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Numer budynku jest wymagany")]
        [MaxLength(5)]
        [Display(Name = "Numer budynku")]
        public string NumerDomu { get; set; }
        [MaxLength(3)]
        [Display(Name = "Numer mieszkania")]
        public string NumerMieszkania { get; set; }
        public bool Aktywny { get; set; }
    }
}
