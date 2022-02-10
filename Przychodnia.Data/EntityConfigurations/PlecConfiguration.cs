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
    public class PlecConfiguration : IEntityTypeConfiguration<Plec>
    {
        public void Configure(EntityTypeBuilder<Plec> builder)
        {
            builder.HasData(new Plec
            {
                Id = 1,
                Nazwa = "Kobieta",
                Opis = "Kobieta",
                Aktywna = true
            },
            new Plec
            {
                Id = 2,
                Nazwa = "Mężczyzna",
                Opis = "Mężczyzna",
                Aktywna = true
            });

        }
    }
}
