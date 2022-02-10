using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class AddedUzytkownicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Harmonogramy_Lekarze_LekarzId",
                table: "Harmonogramy");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Adresy_AdresId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Loginy_LoginId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Plcie_PlecId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Poradnie_PoradniaId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Loginy_Role_RolaId",
                table: "Loginy");

            migrationBuilder.DropTable(
                name: "LekarzSpecjalizacja");

            migrationBuilder.DropTable(
                name: "Pacjenci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loginy",
                table: "Loginy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lekarze",
                table: "Lekarze");

            migrationBuilder.RenameTable(
                name: "Loginy",
                newName: "Login");

            migrationBuilder.RenameTable(
                name: "Lekarze",
                newName: "Lekarz");

            migrationBuilder.RenameIndex(
                name: "IX_Loginy_RolaId",
                table: "Login",
                newName: "IX_Login_RolaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lekarze_PoradniaId",
                table: "Lekarz",
                newName: "IX_Lekarz_PoradniaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lekarze_PlecId",
                table: "Lekarz",
                newName: "IX_Lekarz_PlecId");

            migrationBuilder.RenameIndex(
                name: "IX_Lekarze_LoginId",
                table: "Lekarz",
                newName: "IX_Lekarz_LoginId");

            migrationBuilder.RenameIndex(
                name: "IX_Lekarze_AdresId",
                table: "Lekarz",
                newName: "IX_Lekarz_AdresId");

            migrationBuilder.AddColumn<int>(
                name: "LekarzId",
                table: "Specjalizacje",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lekarz",
                table: "Lekarz",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolaId = table.Column<int>(type: "int", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PlecId = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    PoradniaId = table.Column<int>(type: "int", nullable: true),
                    SpecjalizacjaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Adresy_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Plcie_PlecId",
                        column: x => x.PlecId,
                        principalTable: "Plcie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Poradnie_PoradniaId",
                        column: x => x.PoradniaId,
                        principalTable: "Poradnie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Role_RolaId",
                        column: x => x.RolaId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Specjalizacje_SpecjalizacjaId",
                        column: x => x.SpecjalizacjaId,
                        principalTable: "Specjalizacje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specjalizacje_LekarzId",
                table: "Specjalizacje",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_AdresId",
                table: "Uzytkownicy",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_PlecId",
                table: "Uzytkownicy",
                column: "PlecId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_PoradniaId",
                table: "Uzytkownicy",
                column: "PoradniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_RolaId",
                table: "Uzytkownicy",
                column: "RolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_SpecjalizacjaId",
                table: "Uzytkownicy",
                column: "SpecjalizacjaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Harmonogramy_Lekarz_LekarzId",
                table: "Harmonogramy",
                column: "LekarzId",
                principalTable: "Lekarz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarz_Adresy_AdresId",
                table: "Lekarz",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarz_Login_LoginId",
                table: "Lekarz",
                column: "LoginId",
                principalTable: "Login",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarz_Plcie_PlecId",
                table: "Lekarz",
                column: "PlecId",
                principalTable: "Plcie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarz_Poradnie_PoradniaId",
                table: "Lekarz",
                column: "PoradniaId",
                principalTable: "Poradnie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Role_RolaId",
                table: "Login",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specjalizacje_Lekarz_LekarzId",
                table: "Specjalizacje",
                column: "LekarzId",
                principalTable: "Lekarz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Harmonogramy_Lekarz_LekarzId",
                table: "Harmonogramy");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarz_Adresy_AdresId",
                table: "Lekarz");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarz_Login_LoginId",
                table: "Lekarz");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarz_Plcie_PlecId",
                table: "Lekarz");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarz_Poradnie_PoradniaId",
                table: "Lekarz");

            migrationBuilder.DropForeignKey(
                name: "FK_Login_Role_RolaId",
                table: "Login");

            migrationBuilder.DropForeignKey(
                name: "FK_Specjalizacje_Lekarz_LekarzId",
                table: "Specjalizacje");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropIndex(
                name: "IX_Specjalizacje_LekarzId",
                table: "Specjalizacje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lekarz",
                table: "Lekarz");

            migrationBuilder.DropColumn(
                name: "LekarzId",
                table: "Specjalizacje");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "Loginy");

            migrationBuilder.RenameTable(
                name: "Lekarz",
                newName: "Lekarze");

            migrationBuilder.RenameIndex(
                name: "IX_Login_RolaId",
                table: "Loginy",
                newName: "IX_Loginy_RolaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lekarz_PoradniaId",
                table: "Lekarze",
                newName: "IX_Lekarze_PoradniaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lekarz_PlecId",
                table: "Lekarze",
                newName: "IX_Lekarze_PlecId");

            migrationBuilder.RenameIndex(
                name: "IX_Lekarz_LoginId",
                table: "Lekarze",
                newName: "IX_Lekarze_LoginId");

            migrationBuilder.RenameIndex(
                name: "IX_Lekarz_AdresId",
                table: "Lekarze",
                newName: "IX_Lekarze_AdresId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loginy",
                table: "Loginy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lekarze",
                table: "Lekarze",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LekarzSpecjalizacja",
                columns: table => new
                {
                    LekarzeId = table.Column<int>(type: "int", nullable: false),
                    SpecjalizacjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LekarzSpecjalizacja", x => new { x.LekarzeId, x.SpecjalizacjeId });
                    table.ForeignKey(
                        name: "FK_LekarzSpecjalizacja_Lekarze_LekarzeId",
                        column: x => x.LekarzeId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LekarzSpecjalizacja_Specjalizacje_SpecjalizacjeId",
                        column: x => x.SpecjalizacjeId,
                        principalTable: "Specjalizacje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacjenci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresId = table.Column<int>(type: "int", nullable: false),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LoginId = table.Column<int>(type: "int", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PlecId = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjenci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacjenci_Adresy_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacjenci_Loginy_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Loginy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacjenci_Plcie_PlecId",
                        column: x => x.PlecId,
                        principalTable: "Plcie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LekarzSpecjalizacja_SpecjalizacjeId",
                table: "LekarzSpecjalizacja",
                column: "SpecjalizacjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjenci_AdresId",
                table: "Pacjenci",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjenci_LoginId",
                table: "Pacjenci",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjenci_PlecId",
                table: "Pacjenci",
                column: "PlecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Harmonogramy_Lekarze_LekarzId",
                table: "Harmonogramy",
                column: "LekarzId",
                principalTable: "Lekarze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Adresy_AdresId",
                table: "Lekarze",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Loginy_LoginId",
                table: "Lekarze",
                column: "LoginId",
                principalTable: "Loginy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Plcie_PlecId",
                table: "Lekarze",
                column: "PlecId",
                principalTable: "Plcie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Poradnie_PoradniaId",
                table: "Lekarze",
                column: "PoradniaId",
                principalTable: "Poradnie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loginy_Role_RolaId",
                table: "Loginy",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
