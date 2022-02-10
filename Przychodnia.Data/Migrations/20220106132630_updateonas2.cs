using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class updateonas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tytuł",
                table: "StronaOnas",
                newName: "Tytul");

            migrationBuilder.RenameColumn(
                name: "Treść",
                table: "StronaOnas",
                newName: "Tresc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tytul",
                table: "StronaOnas",
                newName: "Tytuł");

            migrationBuilder.RenameColumn(
                name: "Tresc",
                table: "StronaOnas",
                newName: "Treść");
        }
    }
}
