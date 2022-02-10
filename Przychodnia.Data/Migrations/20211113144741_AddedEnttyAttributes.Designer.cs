﻿// <auto-generated />
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
    [Migration("20211113144741_AddedEnttyAttributes")]
    partial class AddedEnttyAttributes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LekarzPlacowka", b =>
                {
                    b.Property<int>("LekarzeId")
                        .HasColumnType("int");

                    b.Property<int>("PlacowkiId")
                        .HasColumnType("int");

                    b.HasKey("LekarzeId", "PlacowkiId");

                    b.HasIndex("PlacowkiId");

                    b.ToTable("LekarzPlacowka");
                });

            modelBuilder.Entity("LekarzSpecjalizacja", b =>
                {
                    b.Property<int>("LekarzeId")
                        .HasColumnType("int");

                    b.Property<int>("SpecjalizacjeId")
                        .HasColumnType("int");

                    b.HasKey("LekarzeId", "SpecjalizacjeId");

                    b.HasIndex("SpecjalizacjeId");

                    b.ToTable("LekarzSpecjalizacja");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Adres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

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

            modelBuilder.Entity("Przychodnia.Data.Entities.Funkcja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Opis")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Funkcje");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Gabinet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Numer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlacowkaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlacowkaId");

                    b.ToTable("Gabinety");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Harmonogram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataRozpoczecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZakonczenia")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GabinetId")
                        .HasColumnType("int");

                    b.Property<int?>("LekarzId")
                        .HasColumnType("int");

                    b.Property<int?>("PlacowkaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GabinetId");

                    b.HasIndex("LekarzId");

                    b.HasIndex("PlacowkaId");

                    b.ToTable("Harmonogramy");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.KartaPacjenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywna")
                        .HasColumnType("bit");

                    b.Property<int?>("PacjentId")
                        .HasColumnType("int");

                    b.Property<int>("Waga")
                        .HasColumnType("int");

                    b.Property<int>("Wzrost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacjentId");

                    b.ToTable("KartyPacjentow");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Lekarz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FunkcjaId")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumerTelefonu")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Pesel")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Plec")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("FunkcjaId");

                    b.HasIndex("LoginId");

                    b.ToTable("Lekarze");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Haslo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NazwaUzytkownika")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("TokenAktywacyjny")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Zablokowany")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Loginy");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Pacjent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresId")
                        .HasColumnType("int");

                    b.Property<bool>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Pesel")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Plec")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("AdresId");

                    b.HasIndex("LoginId");

                    b.ToTable("Pacjenci");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Placowka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresId")
                        .HasColumnType("int");

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

                    b.HasIndex("AdresId");

                    b.ToTable("Placowki");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Pracownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FunkcjaId")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NumerTelefonu")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Pesel")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("PlacowkaId")
                        .HasColumnType("int");

                    b.Property<string>("Plec")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("FunkcjaId");

                    b.HasIndex("LoginId");

                    b.HasIndex("PlacowkaId");

                    b.ToTable("Pracownicy");
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
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.StatusWizyty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wartosc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusyWizyt");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Wizyta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("CzasTrwania")
                        .HasColumnType("time");

                    b.Property<int?>("LekarzId")
                        .HasColumnType("int");

                    b.Property<int?>("PacjentId")
                        .HasColumnType("int");

                    b.Property<int?>("PlacowkaId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LekarzId");

                    b.HasIndex("PacjentId");

                    b.HasIndex("PlacowkaId");

                    b.HasIndex("StatusId");

                    b.ToTable("Wizyty");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Wpis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataWpisu")
                        .HasColumnType("datetime2");

                    b.Property<string>("Leczenie")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Leki")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("OpisChoroby")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("StanZdrowia")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int?>("WizytaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WizytaId");

                    b.ToTable("Wpisy");
                });

            modelBuilder.Entity("LekarzPlacowka", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Lekarz", null)
                        .WithMany()
                        .HasForeignKey("LekarzeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Przychodnia.Data.Entities.Placowka", null)
                        .WithMany()
                        .HasForeignKey("PlacowkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LekarzSpecjalizacja", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Lekarz", null)
                        .WithMany()
                        .HasForeignKey("LekarzeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Przychodnia.Data.Entities.Specjalizacja", null)
                        .WithMany()
                        .HasForeignKey("SpecjalizacjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Gabinet", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Placowka", "Placowka")
                        .WithMany("Gabinety")
                        .HasForeignKey("PlacowkaId");

                    b.Navigation("Placowka");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Harmonogram", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Gabinet", "Gabinet")
                        .WithMany()
                        .HasForeignKey("GabinetId");

                    b.HasOne("Przychodnia.Data.Entities.Lekarz", "Lekarz")
                        .WithMany()
                        .HasForeignKey("LekarzId");

                    b.HasOne("Przychodnia.Data.Entities.Placowka", "Placowka")
                        .WithMany()
                        .HasForeignKey("PlacowkaId");

                    b.Navigation("Gabinet");

                    b.Navigation("Lekarz");

                    b.Navigation("Placowka");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.KartaPacjenta", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Pacjent", "Pacjent")
                        .WithMany()
                        .HasForeignKey("PacjentId");

                    b.Navigation("Pacjent");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Lekarz", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Funkcja", "Funkcja")
                        .WithMany()
                        .HasForeignKey("FunkcjaId");

                    b.HasOne("Przychodnia.Data.Entities.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId");

                    b.Navigation("Funkcja");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Pacjent", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId");

                    b.HasOne("Przychodnia.Data.Entities.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId");

                    b.Navigation("Adres");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Placowka", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId");

                    b.Navigation("Adres");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Pracownik", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Funkcja", "Funkcja")
                        .WithMany()
                        .HasForeignKey("FunkcjaId");

                    b.HasOne("Przychodnia.Data.Entities.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId");

                    b.HasOne("Przychodnia.Data.Entities.Placowka", "Placowka")
                        .WithMany()
                        .HasForeignKey("PlacowkaId");

                    b.Navigation("Funkcja");

                    b.Navigation("Login");

                    b.Navigation("Placowka");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Wizyta", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Lekarz", "Lekarz")
                        .WithMany()
                        .HasForeignKey("LekarzId");

                    b.HasOne("Przychodnia.Data.Entities.Pacjent", "Pacjent")
                        .WithMany()
                        .HasForeignKey("PacjentId");

                    b.HasOne("Przychodnia.Data.Entities.Placowka", "Placowka")
                        .WithMany()
                        .HasForeignKey("PlacowkaId");

                    b.HasOne("Przychodnia.Data.Entities.StatusWizyty", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Lekarz");

                    b.Navigation("Pacjent");

                    b.Navigation("Placowka");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Wpis", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Wizyta", "Wizyta")
                        .WithMany()
                        .HasForeignKey("WizytaId");

                    b.Navigation("Wizyta");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Placowka", b =>
                {
                    b.Navigation("Gabinety");
                });
#pragma warning restore 612, 618
        }
    }
}
