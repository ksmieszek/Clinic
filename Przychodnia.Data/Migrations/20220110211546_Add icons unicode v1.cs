using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class Addiconsunicodev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "far fa-heart", "&#xf08a;" });

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "far fa-calendar", "&#xf133;" });

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "far fa-newspaper", "&#xf1ea;" });

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "far fa-envelope", "&#xf2b7;" });

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "far fa-id-card", "&#xf2c3;" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "fas fa-crutch fa-2x", "#f7f7" });

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "fas fa-first-aid fa-2x", "#f479" });

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "fas fa-heartbeat fa-2x", "#f21e" });

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "fas fa-lungs fa-2x", "#f604" });

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Nazwa", "Unicode" },
                values: new object[] { "fas fa-procedures fa-2x", "#f487" });

            migrationBuilder.InsertData(
                table: "Ikony",
                columns: new[] { "Id", "Nazwa", "Unicode" },
                values: new object[,]
                {
                    { 6, "fas fa-stethoscope fa-2x", "#f0f1" },
                    { 7, "fas fa-star-of-life fa-2x", "#f621" },
                    { 8, "fas fa-hand-holding-medical fa-2x", "#e05c" }
                });
        }
    }
}
