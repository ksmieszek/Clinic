using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;

namespace Przychodnia.Intranet.ViewModel
{
    public class AktualnosciViewModel
    {
        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Tytuł nagłówka jest wymagany")]
        [Display(Name = "Tytuł nagłówka")]
        public string Tytul { get; set; }

        [Required(ErrorMessage = "Treść artykułu jest wymagana")]
        [Column(TypeName = "nvarchar(MAX)")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Tresc { get; set; }

        public IFormFile Foto { get; set; }
        public string FotoUrl { get; set; }

        [MaxLength(50, ErrorMessage = "Wartość pola Odbiorca nie może przekraczać 50 znaków")]
        public string Odbiorca { get; set; }

        public AktualnosciViewModel()
        {
        }

        public AktualnosciViewModel(string tytul, string tresc, IFormFile foto, string odbiorca)
        {
            Tytul = tytul;
            Tresc = tresc;
            Foto = foto;
            Odbiorca = odbiorca;
        }
    }
}