using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Przychodnia.Data.Entities
{
    public class Strona
    {
        // To jest kluczem głównym - i samo się automatycznie inkrementuje
        [Key]
        public int IdStrony { get; set; }
        // Oznacza to że poniższe pole jest wymagane
        // a jak się go nie wpisze pojawi się ErrorMessage
        [Required(ErrorMessage = "Tytul Linku jest wymagany")]
        [MaxLength(20, ErrorMessage = "Tytul powinien mieć max 10 znaków")]
        // tu określamy jak pole będzie się nazywało na widoku
        [Display(Name = "Tytuł odnośnika")]
        public string LinkTytul { get; set; }
        [Required(ErrorMessage = "Tytul Strony jest wymagany")]
        [MaxLength(50, ErrorMessage = "Tytul powinien mieć max 50 znaków")]
        [Display(Name = "Tytuł")]
        public string Tytul { get; set; }
        [Display(Name = "Treść")]
        // Tu wymuszamy jakiego typu pole będzie w bazie danych
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc { get; set; }
        [Display(Name = "Pozycja wyświetlania")]
        [Required(ErrorMessage = "Wpisz pozycje wyświetlania")]
        public int Pozycja { get; set; }
        [Display(Name = "Czy w oknie")]
        public bool CzyWOknie { get; set; }
        [Display(Name = "Czy ikona")]
        public bool CzyIkona { get; set; }
        [Display(Name = "Wyświetl jako ikonę")]
        public string IkonaNazwa { get; set; }
        public int IkonaId { get; set; }
        public Ikona Ikona { get; set; }
        public bool Aktywna { get; set; } = true;
    }
}

