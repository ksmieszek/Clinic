using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class DOdanieAktywnyWCennikach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktywny",
                table: "CennikiZabiegi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Aktywny",
                table: "CennikiPoradnie",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Aktywny",
                table: "CennikiLekarze",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktywny",
                table: "CennikiZabiegi");

            migrationBuilder.DropColumn(
                name: "Aktywny",
                table: "CennikiPoradnie");

            migrationBuilder.DropColumn(
                name: "Aktywny",
                table: "CennikiLekarze");
        }
    }
}
