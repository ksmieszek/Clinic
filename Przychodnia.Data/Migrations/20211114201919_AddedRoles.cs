using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolaId",
                table: "Loginy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loginy_RolaId",
                table: "Loginy",
                column: "RolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loginy_Role_RolaId",
                table: "Loginy",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loginy_Role_RolaId",
                table: "Loginy");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Loginy_RolaId",
                table: "Loginy");

            migrationBuilder.DropColumn(
                name: "RolaId",
                table: "Loginy");
        }
    }
}
