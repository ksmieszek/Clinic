using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class DeletedLekarz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Harmonogramy_Lekarz_LekarzId",
                table: "Harmonogramy");

            migrationBuilder.DropForeignKey(
                name: "FK_Specjalizacje_Lekarz_LekarzId",
                table: "Specjalizacje");

            migrationBuilder.DropTable(
                name: "Lekarz");

            migrationBuilder.DropIndex(
                name: "IX_Specjalizacje_LekarzId",
                table: "Specjalizacje");

            migrationBuilder.DropColumn(
                name: "LekarzId",
                table: "Specjalizacje");

            migrationBuilder.AddForeignKey(
                name: "FK_Harmonogramy_Uzytkownicy_LekarzId",
                table: "Harmonogramy",
                column: "LekarzId",
                principalTable: "Uzytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Harmonogramy_Uzytkownicy_LekarzId",
                table: "Harmonogramy");

            migrationBuilder.AddColumn<int>(
                name: "LekarzId",
                table: "Specjalizacje",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lekarz",
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
                    PoradniaId = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekarz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lekarz_Adresy_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lekarz_Login_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Login",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lekarz_Plcie_PlecId",
                        column: x => x.PlecId,
                        principalTable: "Plcie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lekarz_Poradnie_PoradniaId",
                        column: x => x.PoradniaId,
                        principalTable: "Poradnie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specjalizacje_LekarzId",
                table: "Specjalizacje",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarz_AdresId",
                table: "Lekarz",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarz_LoginId",
                table: "Lekarz",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarz_PlecId",
                table: "Lekarz",
                column: "PlecId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarz_PoradniaId",
                table: "Lekarz",
                column: "PoradniaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Harmonogramy_Lekarz_LekarzId",
                table: "Harmonogramy",
                column: "LekarzId",
                principalTable: "Lekarz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specjalizacje_Lekarz_LekarzId",
                table: "Specjalizacje",
                column: "LekarzId",
                principalTable: "Lekarz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
