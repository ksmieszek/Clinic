using Microsoft.AspNetCore.Http;
using Przychodnia.Data.Entities;
using System.Collections.Generic;

namespace Przychodnia.Intranet.ViewModel
{
    public class PoradniaViewModel
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public List<Uzytkownik> Lekarze { get; set; }
        public IFormFile Foto { get; set; }
        public string FotoUrl { get; set; }
        public bool Aktywna { get; set; }

        public PoradniaViewModel()
        {
        }

        public PoradniaViewModel(string nazwa, string opis, IFormFile foto, bool aktywna)
        {
            Nazwa = nazwa; 
            Opis = opis;
            Foto = foto;
            Aktywna = aktywna;
        }
    }
}
