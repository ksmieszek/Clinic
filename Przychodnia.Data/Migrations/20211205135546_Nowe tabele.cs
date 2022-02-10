using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class Nowetabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Uzytkownicy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Promowany",
                table: "Uzytkownicy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TytulNaukowyId",
                table: "Uzytkownicy",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KodPocztowy",
                table: "Adresy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.CreateTable(
                name: "Parametry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozycja = table.Column<int>(type: "int", nullable: false),
                    Wartosc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TytulyNaukowe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TytulyNaukowe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_TytulNaukowyId",
                table: "Uzytkownicy",
                column: "TytulNaukowyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_TytulyNaukowe_TytulNaukowyId",
                table: "Uzytkownicy",
                column: "TytulNaukowyId",
                principalTable: "TytulyNaukowe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_TytulyNaukowe_TytulNaukowyId",
                table: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Parametry");

            migrationBuilder.DropTable(
                name: "TytulyNaukowe");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownicy_TytulNaukowyId",
                table: "Uzytkownicy");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Uzytkownicy");

            migrationBuilder.DropColumn(
                name: "Promowany",
                table: "Uzytkownicy");

            migrationBuilder.DropColumn(
                name: "TytulNaukowyId",
                table: "Uzytkownicy");

            migrationBuilder.AlterColumn<string>(
                name: "KodPocztowy",
                table: "Adresy",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
