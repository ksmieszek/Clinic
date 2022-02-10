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
    public class IkonaConfiguration : IEntityTypeConfiguration<Ikona>
    {
        public void Configure(EntityTypeBuilder<Ikona> builder)
        {
            builder.HasData(
                new Ikona { Id = 1, Nazwa = "far fa-heart", Unicode = "&#xf08a;" },
                new Ikona { Id = 2, Nazwa = "far fa-calendar", Unicode = "&#xf133;" },
                new Ikona { Id = 3, Nazwa = "far fa-newspaper", Unicode = "&#xf1ea;" },
                new Ikona { Id = 4, Nazwa = "far fa-envelope", Unicode = "&#xf2b7;" },
                new Ikona { Id = 5, Nazwa = "far fa-id-card", Unicode = "&#xf2c3;" }
                );
        }
    }
}
