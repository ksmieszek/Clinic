using Microsoft.EntityFrameworkCore;
using Przychodnia.Data.Entities;
using System.Reflection;

namespace Przychodnia.Data
{
    public class PrzychodniaDbContext : DbContext
    {
        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Harmonogram> Harmonogramy { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }
        public DbSet<Specjalizacja> Specjalizacje { get; set; }
        public DbSet<Rola> Role { get; set; }
        public DbSet<Plec> Plcie { get; set; }
        public DbSet<Poradnia> Poradnie { get; set; }
        public DbSet<Aktualnosc> Aktualnosci { get; set; }
        public DbSet<Zabieg> Zabiegi { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Kontakt> Kontakty { get; set; }
        public DbSet<StronaOnas> StronaOnas { get; set; }
        public DbSet<CennikLekarz> CennikiLekarze { get; set; }
        public DbSet<CennikPoradnia> CennikiPoradnie { get; set; }
        public DbSet<CennikZabieg> CennikiZabiegi { get; set; }
        public DbSet<Parametr> Parametry { get; set; }
        public DbSet<TytulNaukowy> TytulyNaukowe { get; set; }
        public DbSet<Strona> Strony { get; set; }
        public DbSet<Ikona> Ikony { get; set; }
        public DbSet<Regulamin> Regulaminy { get; set; }

        public PrzychodniaDbContext(DbContextOptions<PrzychodniaDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }    
}
