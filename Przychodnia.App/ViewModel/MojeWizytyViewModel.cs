using Przychodnia.Data.Entities;
using System.Collections.Generic;

namespace Przychodnia.App.ViewModel
{
    public class MojeWizytyViewModel
    {
        public IEnumerable<Wizyta> Appointments { get; set; }
    }
}
