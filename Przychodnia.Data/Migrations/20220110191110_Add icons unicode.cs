using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class Addiconsunicode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unicode",
                table: "Ikony",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 1,
                column: "Unicode",
                value: "#f7f7");

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 2,
                column: "Unicode",
                value: "#f479");

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 3,
                column: "Unicode",
                value: "#f21e");

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 4,
                column: "Unicode",
                value: "#f604");

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 5,
                column: "Unicode",
                value: "#f487");

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 6,
                column: "Unicode",
                value: "#f0f1");

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 7,
                column: "Unicode",
                value: "#f621");

            migrationBuilder.UpdateData(
                table: "Ikony",
                keyColumn: "Id",
                keyValue: 8,
                column: "Unicode",
                value: "#e05c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unicode",
                table: "Ikony");
        }
    }
}
