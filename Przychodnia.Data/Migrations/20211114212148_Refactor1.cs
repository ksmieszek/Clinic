using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class Refactor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoradniaId",
                table: "Lekarze",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Poradnie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poradnie", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lekarze_PoradniaId",
                table: "Lekarze",
                column: "PoradniaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lekarze_Poradnie_PoradniaId",
                table: "Lekarze",
                column: "PoradniaId",
                principalTable: "Poradnie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lekarze_Poradnie_PoradniaId",
                table: "Lekarze");

            migrationBuilder.DropTable(
                name: "Poradnie");

            migrationBuilder.DropIndex(
                name: "IX_Lekarze_PoradniaId",
                table: "Lekarze");

            migrationBuilder.DropColumn(
                name: "PoradniaId",
                table: "Lekarze");
        }
    }
}
