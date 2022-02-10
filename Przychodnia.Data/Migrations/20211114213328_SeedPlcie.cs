using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class SeedPlcie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plcie",
                columns: new[] { "Id", "Aktywna", "Nazwa", "Opis" },
                values: new object[] { 1, true, "Kobieta", "Kobieta" });

            migrationBuilder.InsertData(
                table: "Plcie",
                columns: new[] { "Id", "Aktywna", "Nazwa", "Opis" },
                values: new object[] { 2, true, "Mężczyzna", "Mężczyzna" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plcie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plcie",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
