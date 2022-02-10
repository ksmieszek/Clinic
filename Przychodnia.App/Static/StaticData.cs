using Przychodnia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.App.Static
{
    public class StaticData
    {
        public static List<StronaOnas> StronaONasElements { get; set; } = new List<StronaOnas>();
        public static List<Strona> StronaElements { get; set; } = new List<Strona>();
        public static List<Poradnia> PoradniaElements { get; set; } = new List<Poradnia>();

        


    }
}
