using Microsoft.EntityFrameworkCore.Migrations;

namespace Przychodnia.Data.Migrations
{
    public partial class Seedspecjalizacje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specjalizacje",
                columns: new[] { "Id", "Aktywna", "Nazwa", "Opis" },
                values: new object[] { 1, true, "Dermatolog", "Dermatolog zajmuje się leczeniem, diagnozowaniem i profilaktyką chorób skóry, włosów i paznokci. Na wizytę do poradni dermatologicznej powinny zgłosić się osoby, które zaobserwowały u siebie zmiany skórne, przebarwienia lub znamiona." });

            migrationBuilder.InsertData(
                table: "Specjalizacje",
                columns: new[] { "Id", "Aktywna", "Nazwa", "Opis" },
                values: new object[] { 2, true, "Pediatra", "Pediatra jest lekarzem zajmującym się diagnozowaniem i leczeniem chorób oraz dolegliwości występujących u dzieci. Posiada on ogromny zasób wiedzy, dzięki któremu jest w stanie zastosować prawidłową terapię nie tylko w przypadku drobnych schorzeń, ale również tych o podłożu genetycznym oraz mających pochodzenie psychologiczne lub psychospołeczne" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specjalizacje",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specjalizacje",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
