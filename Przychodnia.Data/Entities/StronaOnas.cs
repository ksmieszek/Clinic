using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Entities
{
    public class StronaOnas
    {
        public int Id { get; set; }
        [Display(Name = "Tytuł")]
        public string Tytul { get; set; }
        [Display(Name = "Treść")]
        public string Tresc { get; set; }
        public int Pozycja { get; set;  }
        public string FotoUrl { get; set; }
        public bool Aktywna { get; set; } = true;
    }
}
