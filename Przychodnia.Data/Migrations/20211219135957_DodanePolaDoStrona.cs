using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class DodanePolaDoStrona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.AddColumn<bool>(
                name: "Aktywny",
                table: "Strona",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "CzyIkona",
                table: "Strona",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IkonaNazwa",
                table: "Strona",
                type: "nvarchar(max)",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Strona",
                table: "Strona");

            migrationBuilder.DropColumn(
                name: "CzyIkona",
                table: "Strona");

            migrationBuilder.DropColumn(
                name: "IkonaNazwa",
                table: "Strona");

            migrationBuilder.RenameTable(
                name: "Strona",
                newName: "Strony");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Strony",
                table: "Strony",
                column: "IdStrony");
        }
    }
}
