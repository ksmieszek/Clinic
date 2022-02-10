using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class UpdateHarmonogramEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRozpoczecia",
                table: "Harmonogramy");

            migrationBuilder.RenameColumn(
                name: "DataZakonczenia",
                table: "Harmonogramy",
                newName: "DatoGodzina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatoGodzina",
                table: "Harmonogramy",
                newName: "DataZakonczenia");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRozpoczecia",
                table: "Harmonogramy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
