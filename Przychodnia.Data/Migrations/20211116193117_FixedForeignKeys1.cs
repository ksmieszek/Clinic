using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class FixedForeignKeys1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Plcie_PlecId",
                table: "Uzytkownicy");

            migrationBuilder.AlterColumn<int>(
                name: "PlecId",
                table: "Uzytkownicy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Plcie_PlecId",
                table: "Uzytkownicy",
                column: "PlecId",
                principalTable: "Plcie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Plcie_PlecId",
                table: "Uzytkownicy");

            migrationBuilder.AlterColumn<int>(
                name: "PlecId",
                table: "Uzytkownicy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Plcie_PlecId",
                table: "Uzytkownicy",
                column: "PlecId",
                principalTable: "Plcie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
