using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plec",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "NumerTelefonu",
                table: "Lekarze");

            migrationBuilder.DropColumn(
                name: "Plec",
                table: "Lekarze");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Pacjenci",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "PlecId",
                table: "Pacjenci",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwisko",
                table: "Lekarze",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Lekarze",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Lekarze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlecId",
                table: "Lekarze",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Lekarze",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plcie",
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
                    table.PrimaryKey("PK_Plcie", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacjenci_PlecId",
                table: "Pacjenci",
                column: "PlecId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarze_AdresId",
                table: "Lekarze",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarze_PlecId",
                table: "Lekarze",
                column: "PlecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Adresy_AdresId",
                table: "Lekarze",
                column: "AdresId",
                principalTable: "Adresy",
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
                name: "FK_Pacjenci_Plcie_PlecId",
                table: "Pacjenci",
                column: "PlecId",
                principalTable: "Plcie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Adresy_AdresId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Plcie_PlecId",
                table: "Lekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacjenci_Plcie_PlecId",
                table: "Pacjenci");

            migrationBuilder.DropTable(
                name: "Plcie");

            migrationBuilder.DropIndex(
                name: "IX_Pacjenci_PlecId",
                table: "Pacjenci");

            migrationBuilder.DropIndex(
                name: "IX_Lekarze_AdresId",
                table: "Lekarze");

            migrationBuilder.DropIndex(
                name: "IX_Lekarze_PlecId",
                table: "Lekarze");

            migrationBuilder.DropColumn(
                name: "PlecId",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Lekarze");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Lekarze");

            migrationBuilder.DropColumn(
                name: "PlecId",
                table: "Lekarze");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Lekarze");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Pacjenci",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plec",
                table: "Pacjenci",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwisko",
                table: "Lekarze",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "NumerTelefonu",
                table: "Lekarze",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plec",
                table: "Lekarze",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }
    }
}
