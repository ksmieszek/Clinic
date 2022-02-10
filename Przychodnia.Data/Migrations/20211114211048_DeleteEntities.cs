using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class DeleteEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Harmonogramy_Gabinety_GabinetId",
                table: "Harmonogramy");

            migrationBuilder.DropForeignKey(
                name: "FK_Harmonogramy_Placowki_PlacowkaId",
                table: "Harmonogramy");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Funkcje_FunkcjaId",
                table: "Lekarze");

            migrationBuilder.DropTable(
                name: "Gabinety");

            migrationBuilder.DropTable(
                name: "KartyPacjentow");

            migrationBuilder.DropTable(
                name: "LekarzPlacowka");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Wpisy");

            migrationBuilder.DropTable(
                name: "Funkcje");

            migrationBuilder.DropTable(
                name: "Wizyty");

            migrationBuilder.DropTable(
                name: "Placowki");

            migrationBuilder.DropTable(
                name: "StatusyWizyt");

            migrationBuilder.DropIndex(
                name: "IX_Lekarze_FunkcjaId",
                table: "Lekarze");

            migrationBuilder.DropIndex(
                name: "IX_Harmonogramy_GabinetId",
                table: "Harmonogramy");

            migrationBuilder.DropIndex(
                name: "IX_Harmonogramy_PlacowkaId",
                table: "Harmonogramy");

            migrationBuilder.DropColumn(
                name: "FunkcjaId",
                table: "Lekarze");

            migrationBuilder.DropColumn(
                name: "GabinetId",
                table: "Harmonogramy");

            migrationBuilder.DropColumn(
                name: "PlacowkaId",
                table: "Harmonogramy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FunkcjaId",
                table: "Lekarze",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GabinetId",
                table: "Harmonogramy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlacowkaId",
                table: "Harmonogramy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Funkcje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funkcje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KartyPacjentow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false),
                    PacjentId = table.Column<int>(type: "int", nullable: true),
                    Waga = table.Column<int>(type: "int", nullable: false),
                    Wzrost = table.Column<int>(type: "int", nullable: false)
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
                name: "Placowki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresId = table.Column<int>(type: "int", nullable: true),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "StatusyWizyt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wartosc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusyWizyt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gabinety",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false),
                    Numer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacowkaId = table.Column<int>(type: "int", nullable: true)
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
                name: "LekarzPlacowka",
                columns: table => new
                {
                    LekarzeId = table.Column<int>(type: "int", nullable: false),
                    PlacowkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LekarzPlacowka", x => new { x.LekarzeId, x.PlacowkiId });
                    table.ForeignKey(
                        name: "FK_LekarzPlacowka_Lekarze_LekarzeId",
                        column: x => x.LekarzeId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LekarzPlacowka_Placowki_PlacowkiId",
                        column: x => x.PlacowkiId,
                        principalTable: "Placowki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FunkcjaId = table.Column<int>(type: "int", nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LoginId = table.Column<int>(type: "int", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PlacowkaId = table.Column<int>(type: "int", nullable: true),
                    Plec = table.Column<string>(type: "nvarchar(1)", nullable: false)
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
                    CzasTrwania = table.Column<TimeSpan>(type: "time", nullable: false),
                    LekarzId = table.Column<int>(type: "int", nullable: true),
                    PacjentId = table.Column<int>(type: "int", nullable: true),
                    PlacowkaId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
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
                name: "Wpisy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataWpisu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Leczenie = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Leki = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    OpisChoroby = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    StanZdrowia = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
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
                name: "IX_Lekarze_FunkcjaId",
                table: "Lekarze",
                column: "FunkcjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Harmonogramy_GabinetId",
                table: "Harmonogramy",
                column: "GabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Harmonogramy_PlacowkaId",
                table: "Harmonogramy",
                column: "PlacowkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gabinety_PlacowkaId",
                table: "Gabinety",
                column: "PlacowkaId");

            migrationBuilder.CreateIndex(
                name: "IX_KartyPacjentow_PacjentId",
                table: "KartyPacjentow",
                column: "PacjentId");

            migrationBuilder.CreateIndex(
                name: "IX_LekarzPlacowka_PlacowkiId",
                table: "LekarzPlacowka",
                column: "PlacowkiId");

            migrationBuilder.CreateIndex(
                name: "IX_Placowki_AdresId",
                table: "Placowki",
                column: "AdresId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Harmonogramy_Gabinety_GabinetId",
                table: "Harmonogramy",
                column: "GabinetId",
                principalTable: "Gabinety",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Harmonogramy_Placowki_PlacowkaId",
                table: "Harmonogramy",
                column: "PlacowkaId",
                principalTable: "Placowki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Funkcje_FunkcjaId",
                table: "Lekarze",
                column: "FunkcjaId",
                principalTable: "Funkcje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
