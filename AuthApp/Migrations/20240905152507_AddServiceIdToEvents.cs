using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddServiceIdToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f52e48-9fff-4c74-81e7-3ff268bed8a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9828023c-113b-44e1-aa70-e76585af6513");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30f2692-eb9b-44b6-8db0-91b38c66d940");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Events",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f076fac-adc5-4f01-86c5-91644c07ff39", null, "Admin", "ADMIN" },
                    { "a48af43e-03bf-40db-8636-98a626cce377", null, "Prestataire", "PRESTATAIRE" },
                    { "f994a068-4011-4606-ad44-01615cf7be14", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f076fac-adc5-4f01-86c5-91644c07ff39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a48af43e-03bf-40db-8636-98a626cce377");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f994a068-4011-4606-ad44-01615cf7be14");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25f52e48-9fff-4c74-81e7-3ff268bed8a1", null, "Prestataire", "PRESTATAIRE" },
                    { "9828023c-113b-44e1-aa70-e76585af6513", null, "Client", "CLIENT" },
                    { "d30f2692-eb9b-44b6-8db0-91b38c66d940", null, "Admin", "ADMIN" }
                });
        }
    }
}
