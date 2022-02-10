using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Entities
{
    public class CennikZabieg
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        public double Cena { get; set; }
        public Zabieg Zabieg { get; set; }
        public bool Aktywny { get; set; } = true;
    }
}
