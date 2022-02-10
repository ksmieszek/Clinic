using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class DeletedLekarze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Aktywna", "Nazwa" },
                values: new object[] { 3, true, "Admin" });

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "Aktywny", "Haslo", "NazwaUzytkownika", "RolaId", "TokenAktywacyjny", "Zablokowany" },
                values: new object[] { 1, true, "P@$$w0rd", "Admin", 3, new Guid("00000000-0000-0000-0000-000000000000"), false });
        }
    }
}
