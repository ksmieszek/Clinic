using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.Intranet.ViewModel
{
    public class ZabiegViewModel
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Przeciwwskazania { get; set; }
        public string Przygotowania { get; set; }
        [Display(Name = "Czas trwania")]
        
        public TimeSpan CzasTrwania { get; set; }
        [Display(Name = "Czas trwania")]

        public int CzasTrwaniaMinuty { get; set; }
        public IFormFile Foto { get; set; }
        public string FotoUrl { get; set; }
        public bool Aktywny { get; set; }

        public ZabiegViewModel()
        {
        }

        public ZabiegViewModel(string nazwa, string opis, string przeciwwskazania, string przygotowania, TimeSpan czasTrwania,int czasTrwaniaMinuty , IFormFile foto, bool aktywny)
        {
            Nazwa = nazwa;
            Opis = opis;
            Przeciwwskazania = przeciwwskazania;
            Przygotowania = przygotowania;
            CzasTrwania = czasTrwania;
            CzasTrwaniaMinuty = czasTrwaniaMinuty;
            Foto = foto;
            Aktywny = aktywny;

        }
    }
}
