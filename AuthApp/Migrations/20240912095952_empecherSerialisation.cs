using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class empecherSerialisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bedab521-fd64-4d79-bcdb-c4a65a9ec9b6", null, "Admin", "ADMIN" },
                    { "c6f0999d-c703-4240-aba2-ac07c0e9e099", null, "Prestataire", "PRESTATAIRE" },
                    { "dcca8a9e-4935-4a15-89d1-4e2bdb476d03", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bedab521-fd64-4d79-bcdb-c4a65a9ec9b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6f0999d-c703-4240-aba2-ac07c0e9e099");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcca8a9e-4935-4a15-89d1-4e2bdb476d03");

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
    }
}
