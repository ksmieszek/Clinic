using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miejscowosc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumerDomu = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NumerMieszkania = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funkcje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funkcje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loginy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUzytkownika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenAktywacyjny = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Zablokowany = table.Column<bool>(type: "bit", nullable: false),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loginy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusyWizyt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wartosc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusyWizyt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lekarze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plec = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginId = table.Column<int>(type: "int", nullable: true),
                    FunkcjaId = table.Column<int>(type: "int", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekarze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lekarze_Funkcje_FunkcjaId",
                        column: x => x.FunkcjaId,
                        principalTable: "Funkcje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lekarze_Loginy_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Loginy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacjenci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plec = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresId = table.Column<int>(type: "int", nullable: true),
                    LoginId = table.Column<int>(type: "int", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjenci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacjenci_Adresy_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacjenci_Loginy_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Loginy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Placowki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresId = table.Column<int>(type: "int", nullable: true),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false),
                    LekarzId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placowki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placowki_Adresy_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Placowki_Lekarze_LekarzId",
                        column: x => x.LekarzId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specjalizacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false),
                    LekarzId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specjalizacje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specjalizacje_Lekarze_LekarzId",
                        column: x => x.LekarzId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KartyPacjentow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacjentId = table.Column<int>(type: "int", nullable: true),
                    Waga = table.Column<int>(type: "int", nullable: false),
                    Wzrost = table.Column<int>(type: "int", nullable: false),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartyPacjentow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KartyPacjentow_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gabinety",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacowkaId = table.Column<int>(type: "int", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gabinety", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gabinety_Placowki_PlacowkaId",
                        column: x => x.PlacowkaId,
                        principalTable: "Placowki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plec = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginId = table.Column<int>(type: "int", nullable: true),
                    FunkcjaId = table.Column<int>(type: "int", nullable: true),
                    PlacowkaId = table.Column<int>(type: "int", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pracownicy_Funkcje_FunkcjaId",
                        column: x => x.FunkcjaId,
                        principalTable: "Funkcje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pracownicy_Loginy_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Loginy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pracownicy_Placowki_PlacowkaId",
                        column: x => x.PlacowkaId,
                        principalTable: "Placowki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wizyty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    PacjentId = table.Column<int>(type: "int", nullable: true),
                    LekarzId = table.Column<int>(type: "int", nullable: true),
                    PlacowkaId = table.Column<int>(type: "int", nullable: true),
                    CzasTrwania = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wizyty_Lekarze_LekarzId",
                        column: x => x.LekarzId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wizyty_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wizyty_Placowki_PlacowkaId",
                        column: x => x.PlacowkaId,
                        principalTable: "Placowki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wizyty_StatusyWizyt_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusyWizyt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Harmonogramy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LekarzId = table.Column<int>(type: "int", nullable: true),
                    PlacowkaId = table.Column<int>(type: "int", nullable: true),
                    GabinetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harmonogramy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harmonogramy_Gabinety_GabinetId",
                        column: x => x.GabinetId,
                        principalTable: "Gabinety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Harmonogramy_Lekarze_LekarzId",
                        column: x => x.LekarzId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Harmonogramy_Placowki_PlacowkaId",
                        column: x => x.PlacowkaId,
                        principalTable: "Placowki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wpisy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataWpisu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StanZdrowia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpisChoroby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leczenie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leki = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WizytaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wpisy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wpisy_Wizyty_WizytaId",
                        column: x => x.WizytaId,
                        principalTable: "Wizyty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gabinety_PlacowkaId",
                table: "Gabinety",
                column: "PlacowkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Harmonogramy_GabinetId",
                table: "Harmonogramy",
                column: "GabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Harmonogramy_LekarzId",
                table: "Harmonogramy",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_Harmonogramy_PlacowkaId",
                table: "Harmonogramy",
                column: "PlacowkaId");

            migrationBuilder.CreateIndex(
                name: "IX_KartyPacjentow_PacjentId",
                table: "KartyPacjentow",
                column: "PacjentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarze_FunkcjaId",
                table: "Lekarze",
                column: "FunkcjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarze_LoginId",
                table: "Lekarze",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjenci_AdresId",
                table: "Pacjenci",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjenci_LoginId",
                table: "Pacjenci",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Placowki_AdresId",
                table: "Placowki",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Placowki_LekarzId",
                table: "Placowki",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicy_FunkcjaId",
                table: "Pracownicy",
                column: "FunkcjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicy_LoginId",
                table: "Pracownicy",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicy_PlacowkaId",
                table: "Pracownicy",
                column: "PlacowkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Specjalizacje_LekarzId",
                table: "Specjalizacje",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_LekarzId",
                table: "Wizyty",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_PacjentId",
                table: "Wizyty",
                column: "PacjentId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_PlacowkaId",
                table: "Wizyty",
                column: "PlacowkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_StatusId",
                table: "Wizyty",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Wpisy_WizytaId",
                table: "Wpisy",
                column: "WizytaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harmonogramy");

            migrationBuilder.DropTable(
                name: "KartyPacjentow");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Specjalizacje");

            migrationBuilder.DropTable(
                name: "Wpisy");

            migrationBuilder.DropTable(
                name: "Gabinety");

            migrationBuilder.DropTable(
                name: "Wizyty");

            migrationBuilder.DropTable(
                name: "Pacjenci");

            migrationBuilder.DropTable(
                name: "Placowki");

            migrationBuilder.DropTable(
                name: "StatusyWizyt");

            migrationBuilder.DropTable(
                name: "Adresy");

            migrationBuilder.DropTable(
                name: "Lekarze");

            migrationBuilder.DropTable(
                name: "Funkcje");

            migrationBuilder.DropTable(
                name: "Loginy");
        }
    }
}
