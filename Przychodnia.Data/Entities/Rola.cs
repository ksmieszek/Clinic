using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Entities
{
    public class Rola
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public List<Uzytkownik> Loginy { get; set; }
        public bool Aktywna { get; set; }
    }
}
