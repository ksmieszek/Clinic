using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Entities
{
    public class Zabieg
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Przeciwwskazania { get; set; }
        public string Przygotowania { get; set; }
        [Display(Name = "Czas Trwania")]
        public TimeSpan CzasTrwania { get; set; }
        [Display(Name = "Czas Trwania")]
        public int CzasTrwaniaMinuty { get; set; }
        public string FotoUrl { get; set; }
        public bool Aktywny { get; set; }
    }
}
