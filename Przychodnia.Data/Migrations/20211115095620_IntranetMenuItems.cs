using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class IntranetMenuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Adresy_AdresId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Loginy_LoginId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Plcie_PlecId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacjenci_Adresy_AdresId",
                table: "Pacjenci");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacjenci_Loginy_LoginId",
                table: "Pacjenci");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacjenci_Plcie_PlecId",
                table: "Pacjenci");

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Poradnie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nazwa",
                table: "Poradnie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlecId",
                table: "Pacjenci",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoginId",
                table: "Pacjenci",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Pacjenci",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlecId",
                table: "Lekarze",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoginId",
                table: "Lekarze",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Lekarze",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Aktualnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktualnosci", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Adresy_AdresId",
                table: "Lekarze",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Loginy_LoginId",
                table: "Lekarze",
                column: "LoginId",
                principalTable: "Loginy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Plcie_PlecId",
                table: "Lekarze",
                column: "PlecId",
                principalTable: "Plcie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacjenci_Adresy_AdresId",
                table: "Pacjenci",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacjenci_Loginy_LoginId",
                table: "Pacjenci",
                column: "LoginId",
                principalTable: "Loginy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacjenci_Plcie_PlecId",
                table: "Pacjenci",
                column: "PlecId",
                principalTable: "Plcie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Adresy_AdresId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Loginy_LoginId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Plcie_PlecId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacjenci_Adresy_AdresId",
                table: "Pacjenci");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacjenci_Loginy_LoginId",
                table: "Pacjenci");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacjenci_Plcie_PlecId",
                table: "Pacjenci");

            migrationBuilder.DropTable(
                name: "Aktualnosci");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Poradnie");

            migrationBuilder.DropColumn(
                name: "Nazwa",
                table: "Poradnie");

            migrationBuilder.AlterColumn<int>(
                name: "PlecId",
                table: "Pacjenci",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LoginId",
                table: "Pacjenci",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Pacjenci",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlecId",
                table: "Lekarze",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LoginId",
                table: "Lekarze",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Lekarze",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Adresy_AdresId",
                table: "Lekarze",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Loginy_LoginId",
                table: "Lekarze",
                column: "LoginId",
                principalTable: "Loginy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Plcie_PlecId",
                table: "Lekarze",
                column: "PlecId",
                principalTable: "Plcie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacjenci_Adresy_AdresId",
                table: "Pacjenci",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacjenci_Loginy_LoginId",
                table: "Pacjenci",
                column: "LoginId",
                principalTable: "Loginy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacjenci_Plcie_PlecId",
                table: "Pacjenci",
                column: "PlecId",
                principalTable: "Plcie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
