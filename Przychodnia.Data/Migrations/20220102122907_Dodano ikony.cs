using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class Dodanoikony : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "IkonaId",
                table: "Strony",
                type: "int",
                nullable: true);            

            migrationBuilder.CreateTable(
                name: "Ikony",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ikony", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Strony_IkonaId",
                table: "Strony",
                column: "IkonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Strony_Ikony_IkonaId",
                table: "Strony",
                column: "IkonaId",
                principalTable: "Ikony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strony_Ikony_IkonaId",
                table: "Strony");

            migrationBuilder.DropTable(
                name: "Ikony");

            migrationBuilder.DropIndex(
                name: "IX_Strony_IkonaId",
                table: "Strony");

            migrationBuilder.DropColumn(
                name: "IkonaId",
                table: "Strony");
        }
    }
}
