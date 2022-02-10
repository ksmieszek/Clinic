using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class stronaonas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tekst",
                table: "StronaOnas",
                newName: "Tytuł");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "StronaOnas",
                newName: "Treść");

            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Uzytkownicy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tytuł",
                table: "StronaOnas",
                newName: "Tekst");

            migrationBuilder.RenameColumn(
                name: "Treść",
                table: "StronaOnas",
                newName: "Header");

            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Uzytkownicy",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
