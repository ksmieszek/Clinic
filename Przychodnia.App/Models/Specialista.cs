using Przychodnia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Models
{
    public class Specialista
    {
        public Specialista(Uzytkownik u)
        {
            Uzytkownik = u;
        }

        public string NazwaSpecialnosci { get; set; }
        public Uzytkownik Uzytkownik { get; }
        public string TytulNaukowy { get; internal set; }
    }
}
