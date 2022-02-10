using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loginy_Role_RolaId",
                table: "Loginy");

            migrationBuilder.AlterColumn<int>(
                name: "RolaId",
                table: "Loginy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Aktywna", "Nazwa" },
                values: new object[] { 3, true, "Admin" });

            migrationBuilder.InsertData(
                table: "Loginy",
                columns: new[] { "Id", "Aktywny", "Haslo", "NazwaUzytkownika", "RolaId", "TokenAktywacyjny", "Zablokowany" },
                values: new object[] { 1, true, "P@$$w0rd", "Admin", 3, new Guid("00000000-0000-0000-0000-000000000000"), false });

            migrationBuilder.AddForeignKey(
                name: "FK_Loginy_Role_RolaId",
                table: "Loginy",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loginy_Role_RolaId",
                table: "Loginy");

            migrationBuilder.DeleteData(
                table: "Loginy",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "RolaId",
                table: "Loginy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Loginy_Role_RolaId",
                table: "Loginy",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
