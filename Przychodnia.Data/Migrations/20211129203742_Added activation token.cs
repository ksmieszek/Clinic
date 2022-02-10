using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class Addedactivationtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<Guid>(
            //    name: "TokenAktywacyjny",
            //    table: "Uzytkownicy",
            //    type: "uniqueidentifier",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenAktywacyjny",
                table: "Uzytkownicy");
        }
    }
}
