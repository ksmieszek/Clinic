using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.Entities
{
    public class Regulamin
    {
        public int Id { get; set; }
        public DateTime DataObowiazywania { get; set; }
        public string Nazwa { get; set; }
        public string Tresc { get; set; }
    }
}
