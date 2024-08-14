using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class ConvertServiceIdToInteger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a8d88ea-b076-4166-b536-e7e8e6cdf4fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97482078-06ca-4c65-8f63-a0f46a242a9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad9ac570-c7dd-4542-8067-0e19226d077b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fb97053-19c5-4dbc-b3f8-7bec63e26c13", null, "Prestataire", "PRESTATAIRE" },
                    { "d1a672e1-db87-426c-93c0-ecc48126b91d", null, "Admin", "ADMIN" },
                    { "fcb3e159-94ba-454d-8cac-44d5644e653e", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fb97053-19c5-4dbc-b3f8-7bec63e26c13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1a672e1-db87-426c-93c0-ecc48126b91d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcb3e159-94ba-454d-8cac-44d5644e653e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a8d88ea-b076-4166-b536-e7e8e6cdf4fc", null, "Admin", "ADMIN" },
                    { "97482078-06ca-4c65-8f63-a0f46a242a9a", null, "Client", "CLIENT" },
                    { "ad9ac570-c7dd-4542-8067-0e19226d077b", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
