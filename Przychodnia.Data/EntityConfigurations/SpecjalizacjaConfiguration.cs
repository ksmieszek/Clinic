using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Przychodnia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data.EntityConfigurations
{
    public class SpecjalizacjaConfiguration : IEntityTypeConfiguration<Specjalizacja>
    {
        public void Configure(EntityTypeBuilder<Specjalizacja> builder)
        {
            builder.HasData(new Specjalizacja
            {
                Id = 1,
                Aktywna = true,
                Nazwa = "Dermatolog",
                Opis = "Dermatolog zajmuje się leczeniem, diagnozowaniem i profilaktyką chorób skóry, włosów i paznokci. Na wizytę do poradni dermatologicznej powinny zgłosić się osoby, które zaobserwowały u siebie zmiany skórne, przebarwienia lub znamiona."
            },
            new Specjalizacja
            {
                Id = 2,
                Aktywna = true,
                Nazwa = "Pediatra",
                Opis = "Pediatra jest lekarzem zajmującym się diagnozowaniem i leczeniem chorób oraz dolegliwości występujących u dzieci. Posiada on ogromny zasób wiedzy, dzięki któremu jest w stanie zastosować prawidłową terapię nie tylko w przypadku drobnych schorzeń, ale również tych o podłożu genetycznym oraz mających pochodzenie psychologiczne lub psychospołeczne"
            });
        }
    }
}
