using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class AddedNullableForeignKeysInUzytkownik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Adresy_AdresId",
                table: "Uzytkownicy");

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

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Uzytkownicy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Adresy_AdresId",
                table: "Uzytkownicy",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Role_RolaId",
                table: "Uzytkownicy",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Adresy_AdresId",
                table: "Uzytkownicy");

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

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Uzytkownicy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NazwaUzytkownika = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RolaId = table.Column<int>(type: "int", nullable: false),
                    TokenAktywacyjny = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Zablokowany = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Login_Role_RolaId",
                        column: x => x.RolaId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Login_RolaId",
                table: "Login",
                column: "RolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Adresy_AdresId",
                table: "Uzytkownicy",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Role_RolaId",
                table: "Uzytkownicy",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
