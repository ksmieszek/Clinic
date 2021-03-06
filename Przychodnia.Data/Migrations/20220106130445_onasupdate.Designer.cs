// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Przychodnia.Data;

namespace Przychodnia.Data.Migrations
{
    [DbContext(typeof(PrzychodniaDbContext))]
    [Migration("20220106130445_onasupdate")]
    partial class onasupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Przychodnia.Data.Entities.Adres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miejscowosc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumerDomu")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("NumerMieszkania")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Adresy");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Aktualnosc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDodania")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkTytul")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Odbiorca")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Priorytet")
                        .HasColumnType("bigint");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aktualnosci");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.CennikLekarz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<int?>("LekarzId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LekarzId");

                    b.ToTable("CennikiLekarze");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.CennikPoradnia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PoradniaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PoradniaId");

                    b.ToTable("CennikiPoradnie");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.CennikZabieg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZabiegId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZabiegId");

                    b.ToTable("CennikiZabiegi");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Harmonogram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatoGodzina")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LekarzId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LekarzId");

                    b.ToTable("Harmonogramy");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Ikona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ikony");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nazwa = "fas fa-crutch fa-2x"
                        },
                        new
                        {
                            Id = 2,
                            Nazwa = "fas fa-first-aid fa-2x"
                        },
                        new
                        {
                            Id = 3,
                            Nazwa = "fas fa-heartbeat fa-2x"
                        },
                        new
                        {
                            Id = 4,
                            Nazwa = "fas fa-lungs fa-2x"
                        },
                        new
                        {
                            Id = 5,
                            Nazwa = "fas fa-procedures fa-2x"
                        },
                        new
                        {
                            Id = 6,
                            Nazwa = "fas fa-stethoscope fa-2x"
                        },
                        new
                        {
                            Id = 7,
                            Nazwa = "fas fa-star-of-life fa-2x"
                        },
                        new
                        {
                            Id = 8,
                            Nazwa = "fas fa-hand-holding-medical fa-2x"
                        });
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Kontakt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresId")
                        .HasColumnType("int");

                    b.Property<bool>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PozycjaWyswietlania")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("UzytkownikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdresId");

                    b.HasIndex("UzytkownikId");

                    b.ToTable("Kontakty");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Parametr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Wartosc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parametry");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Plec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plcie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aktywna = true,
                            Nazwa = "Kobieta",
                            Opis = "Kobieta"
                        },
                        new
                        {
                            Id = 2,
                            Aktywna = true,
                            Nazwa = "Mężczyzna",
                            Opis = "Mężczyzna"
                        });
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Poradnia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywna")
                        .HasColumnType("bit");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Poradnie");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Rola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aktywna = true,
                            Nazwa = "Lekarz"
                        },
                        new
                        {
                            Id = 2,
                            Aktywna = true,
                            Nazwa = "Pacjent"
                        });
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Specjalizacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Opis")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Specjalizacje");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aktywna = true,
                            Nazwa = "Dermatolog",
                            Opis = "Dermatolog zajmuje się leczeniem, diagnozowaniem i profilaktyką chorób skóry, włosów i paznokci. Na wizytę do poradni dermatologicznej powinny zgłosić się osoby, które zaobserwowały u siebie zmiany skórne, przebarwienia lub znamiona."
                        },
                        new
                        {
                            Id = 2,
                            Aktywna = true,
                            Nazwa = "Pediatra",
                            Opis = "Pediatra jest lekarzem zajmującym się diagnozowaniem i leczeniem chorób oraz dolegliwości występujących u dzieci. Posiada on ogromny zasób wiedzy, dzięki któremu jest w stanie zastosować prawidłową terapię nie tylko w przypadku drobnych schorzeń, ale również tych o podłożu genetycznym oraz mających pochodzenie psychologiczne lub psychospołeczne"
                        });
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Strona", b =>
                {
                    b.Property<int>("IdStrony")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyIkona")
                        .HasColumnType("bit");

                    b.Property<int?>("IkonaId")
                        .HasColumnType("int");

                    b.Property<string>("IkonaNazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdStrony");

                    b.HasIndex("IkonaId");

                    b.ToTable("Strony");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.StronaOnas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Treść")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytuł")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StronaOnas");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.TytulNaukowy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TytulyNaukowe");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Uzytkownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresId")
                        .HasColumnType("int");

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Haslo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HasloSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlecId")
                        .HasColumnType("int");

                    b.Property<int?>("PoradnieId")
                        .HasColumnType("int");

                    b.Property<bool>("Promowany")
                        .HasColumnType("bit");

                    b.Property<int>("RolaId")
                        .HasColumnType("int");

                    b.Property<int?>("SpecjalizacjeId")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("TokenAktywacyjny")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TytulNaukowyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdresId");

                    b.HasIndex("PlecId");

                    b.HasIndex("PoradnieId");

                    b.HasIndex("RolaId");

                    b.HasIndex("SpecjalizacjeId");

                    b.HasIndex("TytulNaukowyId");

                    b.ToTable("Uzytkownicy");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Wizyta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HarmonogramId")
                        .HasColumnType("int");

                    b.Property<int?>("PacjentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HarmonogramId");

                    b.HasIndex("PacjentId");

                    b.ToTable("Wizyty");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Zabieg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("CzasTrwania")
                        .HasColumnType("time");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Przeciwwskazania")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Przygotowania")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zabiegi");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.CennikLekarz", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Uzytkownik", "Lekarz")
                        .WithMany()
                        .HasForeignKey("LekarzId");

                    b.Navigation("Lekarz");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.CennikPoradnia", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Poradnia", "Poradnia")
                        .WithMany()
                        .HasForeignKey("PoradniaId");

                    b.Navigation("Poradnia");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.CennikZabieg", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Zabieg", "Zabieg")
                        .WithMany()
                        .HasForeignKey("ZabiegId");

                    b.Navigation("Zabieg");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Harmonogram", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Uzytkownik", "Lekarz")
                        .WithMany()
                        .HasForeignKey("LekarzId");

                    b.Navigation("Lekarz");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Kontakt", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId");

                    b.HasOne("Przychodnia.Data.Entities.Uzytkownik", "Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UzytkownikId");

                    b.Navigation("Adres");

                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Strona", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Ikona", "Ikona")
                        .WithMany()
                        .HasForeignKey("IkonaId");

                    b.Navigation("Ikona");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Uzytkownik", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId");

                    b.HasOne("Przychodnia.Data.Entities.Plec", "Plec")
                        .WithMany("Uzytkownicy")
                        .HasForeignKey("PlecId");

                    b.HasOne("Przychodnia.Data.Entities.Poradnia", "Poradnie")
                        .WithMany("Lekarze")
                        .HasForeignKey("PoradnieId");

                    b.HasOne("Przychodnia.Data.Entities.Rola", "Rola")
                        .WithMany("Loginy")
                        .HasForeignKey("RolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Przychodnia.Data.Entities.Specjalizacja", "Specjalizacje")
                        .WithMany("Lekarze")
                        .HasForeignKey("SpecjalizacjeId");

                    b.HasOne("Przychodnia.Data.Entities.TytulNaukowy", "TytulNaukowy")
                        .WithMany("Uzytkownicy")
                        .HasForeignKey("TytulNaukowyId");

                    b.Navigation("Adres");

                    b.Navigation("Plec");

                    b.Navigation("Poradnie");

                    b.Navigation("Rola");

                    b.Navigation("Specjalizacje");

                    b.Navigation("TytulNaukowy");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Wizyta", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Harmonogram", "Harmonogram")
                        .WithMany()
                        .HasForeignKey("HarmonogramId");

                    b.HasOne("Przychodnia.Data.Entities.Uzytkownik", "Pacjent")
                        .WithMany()
                        .HasForeignKey("PacjentId");

                    b.Navigation("Harmonogram");

                    b.Navigation("Pacjent");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Plec", b =>
                {
                    b.Navigation("Uzytkownicy");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Poradnia", b =>
                {
                    b.Navigation("Lekarze");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Rola", b =>
                {
                    b.Navigation("Loginy");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Specjalizacja", b =>
                {
                    b.Navigation("Lekarze");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.TytulNaukowy", b =>
                {
                    b.Navigation("Uzytkownicy");
                });
#pragma warning restore 612, 618
        }
    }
}
