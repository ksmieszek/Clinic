using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class Seedicons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ikony",
                columns: new[] { "Id", "Nazwa" },
                values: new object[,]
                {
                    { 1, "fas fa-crutch fa-2x" },
                    { 2, "fas fa-first-aid fa-2x" },
                    { 3, "fas fa-heartbeat fa-2x" },
                    { 4, "fas fa-lungs fa-2x" },
                    { 5, "fas fa-procedures fa-2x" },
                    { 6, "fas fa-stethoscope fa-2x" },
                    { 7, "fas fa-star-of-life fa-2x" },
                    { 8, "fas fa-hand-holding-medical fa-2x" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
