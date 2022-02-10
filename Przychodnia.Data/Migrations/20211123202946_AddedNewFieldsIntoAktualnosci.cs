using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class AddedNewFieldsIntoAktualnosci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Odbiorca",
                table: "Aktualnosci",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Priorytet",
                table: "Aktualnosci",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odbiorca",
                table: "Aktualnosci");

            migrationBuilder.DropColumn(
                name: "Priorytet",
                table: "Aktualnosci");
        }
    }
}
