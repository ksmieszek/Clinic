using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Przychodnia.Data.Entities;

namespace Przychodnia.Data.EntityConfigurations
{
    public class UzytkownicyConfiguration : IEntityTypeConfiguration<Uzytkownik>
    {
        public void Configure(EntityTypeBuilder<Uzytkownik> builder)
        {
            builder.HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
