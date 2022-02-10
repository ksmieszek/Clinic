using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class FixedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Role_RolaId",
                table: "Uzytkownicy");

            migrationBuilder.AlterColumn<int>(
                name: "RolaId",
                table: "Uzytkownicy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Role_RolaId",
                table: "Uzytkownicy",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Role_RolaId",
                table: "Uzytkownicy");

            migrationBuilder.AlterColumn<int>(
                name: "RolaId",
                table: "Uzytkownicy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Role_RolaId",
                table: "Uzytkownicy",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
