using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Przychodnia.Data.Entities;

namespace Przychodnia.Data.EntityConfigurations
{
    public class RolaConfiguration : IEntityTypeConfiguration<Rola>
    {
        public void Configure(EntityTypeBuilder<Rola> builder)
        {
                builder.HasData(new Rola
                {
                    Id = 2,
                    Nazwa = "Lekarz",
                    Aktywna = true
                },
                new Rola
                {
                    Id = 1,
                    Nazwa = "Pacjent",
                    Aktywna = true
                }
            );
        }
    }
}
