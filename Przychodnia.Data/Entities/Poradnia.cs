using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Entities
{
    public class Poradnia
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public List<Uzytkownik> Lekarze { get; set; }
        public string FotoUrl { get; set; }
        public bool Aktywna { get; set; }
    }
}
