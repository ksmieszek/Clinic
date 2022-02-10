using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przychodnia.Data.Entities
{
    public class Aktualnosc
    {
        public int Id { get; set; }

        [Display(Name = "Tytuł odnośnika")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł nagłówka jest wymagany")]
        [MinLength(10, ErrorMessage = "Tytuł artykułu powinien mieć minimum 10 znaków")]
        [Display(Name = "Tytuł nagłówka")]
        public string Tytul { get; set; }

        [Required(ErrorMessage = "Treść artykułu jest wymagana")]
        [MinLength(50, ErrorMessage = "Treść artykułu powinna mieć conajmniej 50 znaków")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Treść")]
        public string Tresc { get; set; }
        [Required(ErrorMessage = "Data dodania jest wymagana")]
        [Display(Name = "Data dodania")]
        public DateTime DataDodania { get; set; }
        public string FotoUrl { get; set; }
        public uint Priorytet { get; set; }
        [MaxLength(50, ErrorMessage = "Wartość pola Odbiorca nie może przekraczać 50 znaków")]
        public string Odbiorca { get; set; }
        public bool Aktywna { get; set; }
    }
}
