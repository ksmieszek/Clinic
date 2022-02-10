using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class AddikonaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strony_Ikony_IkonaId",
                table: "Strony");

            migrationBuilder.AlterColumn<int>(
                name: "IkonaId",
                table: "Strony",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Strony_Ikony_IkonaId",
                table: "Strony",
                column: "IkonaId",
                principalTable: "Ikony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strony_Ikony_IkonaId",
                table: "Strony");

            migrationBuilder.AlterColumn<int>(
                name: "IkonaId",
                table: "Strony",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Strony_Ikony_IkonaId",
                table: "Strony",
                column: "IkonaId",
                principalTable: "Ikony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
