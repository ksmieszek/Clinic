using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class UpdatedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Placowki_Lekarze_LekarzId",
                table: "Placowki");

            migrationBuilder.DropForeignKey(
                name: "FK_Specjalizacje_Lekarze_LekarzId",
                table: "Specjalizacje");

            migrationBuilder.DropIndex(
                name: "IX_Specjalizacje_LekarzId",
                table: "Specjalizacje");

            migrationBuilder.DropIndex(
                name: "IX_Placowki_LekarzId",
                table: "Placowki");

            migrationBuilder.DropColumn(
                name: "LekarzId",
                table: "Specjalizacje");

            migrationBuilder.DropColumn(
                name: "LekarzId",
                table: "Placowki");

            migrationBuilder.CreateTable(
                name: "LekarzPlacowka",
                columns: table => new
                {
                    LekarzeId = table.Column<int>(type: "int", nullable: false),
                    PlacowkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LekarzPlacowka", x => new { x.LekarzeId, x.PlacowkiId });
                    table.ForeignKey(
                        name: "FK_LekarzPlacowka_Lekarze_LekarzeId",
                        column: x => x.LekarzeId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LekarzPlacowka_Placowki_PlacowkiId",
                        column: x => x.PlacowkiId,
                        principalTable: "Placowki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LekarzSpecjalizacja",
                columns: table => new
                {
                    LekarzeId = table.Column<int>(type: "int", nullable: false),
                    SpecjalizacjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LekarzSpecjalizacja", x => new { x.LekarzeId, x.SpecjalizacjeId });
                    table.ForeignKey(
                        name: "FK_LekarzSpecjalizacja_Lekarze_LekarzeId",
                        column: x => x.LekarzeId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LekarzSpecjalizacja_Specjalizacje_SpecjalizacjeId",
                        column: x => x.SpecjalizacjeId,
                        principalTable: "Specjalizacje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LekarzPlacowka_PlacowkiId",
                table: "LekarzPlacowka",
                column: "PlacowkiId");

            migrationBuilder.CreateIndex(
                name: "IX_LekarzSpecjalizacja_SpecjalizacjeId",
                table: "LekarzSpecjalizacja",
                column: "SpecjalizacjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LekarzPlacowka");

            migrationBuilder.DropTable(
                name: "LekarzSpecjalizacja");

            migrationBuilder.AddColumn<int>(
                name: "LekarzId",
                table: "Specjalizacje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LekarzId",
                table: "Placowki",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specjalizacje_LekarzId",
                table: "Specjalizacje",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_Placowki_LekarzId",
                table: "Placowki",
                column: "LekarzId");

            migrationBuilder.AddForeignKey(
                name: "FK_Placowki_Lekarze_LekarzId",
                table: "Placowki",
                column: "LekarzId",
                principalTable: "Lekarze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specjalizacje_Lekarze_LekarzId",
                table: "Specjalizacje",
                column: "LekarzId",
                principalTable: "Lekarze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
