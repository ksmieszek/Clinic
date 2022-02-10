using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class DodaniePolAktywne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktywna",
                table: "Strony",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Aktywna",
                table: "StronaOnas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Aktywny",
                table: "Harmonogramy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Aktywna",
                table: "Aktualnosci",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktywna",
                table: "Strony");

            migrationBuilder.DropColumn(
                name: "Aktywna",
                table: "StronaOnas");

            migrationBuilder.DropColumn(
                name: "Aktywny",
                table: "Harmonogramy");

            migrationBuilder.DropColumn(
                name: "Aktywna",
                table: "Aktualnosci");
        }
    }
}
