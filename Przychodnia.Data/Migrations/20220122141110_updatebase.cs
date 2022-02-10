using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class updatebase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktywny",
                table: "Parametry",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktywny",
                table: "Parametry");
        }
    }
}
