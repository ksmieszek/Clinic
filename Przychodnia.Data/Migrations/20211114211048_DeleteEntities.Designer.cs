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
    [Migration("20211114211048_DeleteEntities")]
    partial class DeleteEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int?>("LekarzId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LekarzId");

                    b.ToTable("Harmonogramy");
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

                    b.Property<int?>("RolaId")
                        .HasColumnType("int");

                    b.Property<Guid>("TokenAktywacyjny")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Zablokowany")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RolaId");

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

            modelBuilder.Entity("Przychodnia.Data.Entities.Harmonogram", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Lekarz", "Lekarz")
                        .WithMany()
                        .HasForeignKey("LekarzId");

                    b.Navigation("Lekarz");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Lekarz", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("Przychodnia.Data.Entities.Login", b =>
                {
                    b.HasOne("Przychodnia.Data.Entities.Rola", "Rola")
                        .WithMany("Loginy")
                        .HasForeignKey("RolaId");

                    b.Navigation("Rola");
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

            modelBuilder.Entity("Przychodnia.Data.Entities.Rola", b =>
                {
                    b.Navigation("Loginy");
                });
#pragma warning restore 612, 618
        }
    }
}