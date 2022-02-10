using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class AddedcennikiHasloSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cennik");

            migrationBuilder.AddColumn<string>(
                name: "HasloSalt",
                table: "Uzytkownicy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CennikiLekarze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    LekarzId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CennikiLekarze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CennikiLekarze_Uzytkownicy_LekarzId",
                        column: x => x.LekarzId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CennikiPoradnie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    PoradniaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CennikiPoradnie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CennikiPoradnie_Poradnie_PoradniaId",
                        column: x => x.PoradniaId,
                        principalTable: "Poradnie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CennikiZabiegi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    ZabiegId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CennikiZabiegi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CennikiZabiegi_Zabiegi_ZabiegId",
                        column: x => x.ZabiegId,
                        principalTable: "Zabiegi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CennikiLekarze_LekarzId",
                table: "CennikiLekarze",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_CennikiPoradnie_PoradniaId",
                table: "CennikiPoradnie",
                column: "PoradniaId");

            migrationBuilder.CreateIndex(
                name: "IX_CennikiZabiegi_ZabiegId",
                table: "CennikiZabiegi",
                column: "ZabiegId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CennikiLekarze");

            migrationBuilder.DropTable(
                name: "CennikiPoradnie");

            migrationBuilder.DropTable(
                name: "CennikiZabiegi");

            migrationBuilder.DropColumn(
                name: "HasloSalt",
                table: "Uzytkownicy");

            migrationBuilder.CreateTable(
                name: "Cennik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cennik", x => x.Id);
                });
        }
    }
}
