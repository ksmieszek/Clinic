using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class AddedSpecjalizacjaPoradniatoUzytkownik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Poradnie_PoradniaId",
                table: "Uzytkownicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Specjalizacje_SpecjalizacjaId",
                table: "Uzytkownicy");

            migrationBuilder.RenameColumn(
                name: "SpecjalizacjaId",
                table: "Uzytkownicy",
                newName: "SpecjalizacjeId");

            migrationBuilder.RenameColumn(
                name: "PoradniaId",
                table: "Uzytkownicy",
                newName: "PoradnieId");

            migrationBuilder.RenameIndex(
                name: "IX_Uzytkownicy_SpecjalizacjaId",
                table: "Uzytkownicy",
                newName: "IX_Uzytkownicy_SpecjalizacjeId");

            migrationBuilder.RenameIndex(
                name: "IX_Uzytkownicy_PoradniaId",
                table: "Uzytkownicy",
                newName: "IX_Uzytkownicy_PoradnieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Poradnie_PoradnieId",
                table: "Uzytkownicy",
                column: "PoradnieId",
                principalTable: "Poradnie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Specjalizacje_SpecjalizacjeId",
                table: "Uzytkownicy",
                column: "SpecjalizacjeId",
                principalTable: "Specjalizacje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Poradnie_PoradnieId",
                table: "Uzytkownicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Specjalizacje_SpecjalizacjeId",
                table: "Uzytkownicy");

            migrationBuilder.RenameColumn(
                name: "SpecjalizacjeId",
                table: "Uzytkownicy",
                newName: "SpecjalizacjaId");

            migrationBuilder.RenameColumn(
                name: "PoradnieId",
                table: "Uzytkownicy",
                newName: "PoradniaId");

            migrationBuilder.RenameIndex(
                name: "IX_Uzytkownicy_SpecjalizacjeId",
                table: "Uzytkownicy",
                newName: "IX_Uzytkownicy_SpecjalizacjaId");

            migrationBuilder.RenameIndex(
                name: "IX_Uzytkownicy_PoradnieId",
                table: "Uzytkownicy",
                newName: "IX_Uzytkownicy_PoradniaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Poradnie_PoradniaId",
                table: "Uzytkownicy",
                column: "PoradniaId",
                principalTable: "Poradnie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Specjalizacje_SpecjalizacjaId",
                table: "Uzytkownicy",
                column: "SpecjalizacjaId",
                principalTable: "Specjalizacje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
