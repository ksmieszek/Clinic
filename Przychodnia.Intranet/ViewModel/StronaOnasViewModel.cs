using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace Przychodnia.Intranet.ViewModel
{
    public class StronaOnasViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tytuł")]
        public string Tytul { get; set; }
        [Display(Name = "Treść")]
        public string Tresc { get; set; }
        public int Pozycja { get; set; }
        public IFormFile Foto { get; set; }
        public string FotoUrl { get; set; }

        public StronaOnasViewModel()
        {
        }

        public StronaOnasViewModel(string tytul, string tresc, int pozycja, IFormFile foto)
        {
            Pozycja = pozycja;  
            Tytul = tytul;
            Tresc = tresc;  
            Foto = foto;          

        }
    }
}
