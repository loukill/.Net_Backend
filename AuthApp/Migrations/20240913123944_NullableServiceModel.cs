using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class NullableServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eaf81b0-28a1-4bf1-a671-257045ec1258");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a6e5a96-f7a9-4fc5-b5b8-9667e0530e21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f38f6e15-0133-4f8c-a044-6a7a4a9d1771");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9df79769-5a53-407e-a2c6-fb5fa0314f62", null, "Prestataire", "PRESTATAIRE" },
                    { "e645fbf4-5e77-4551-9140-7d548e721c06", null, "Admin", "ADMIN" },
                    { "fb396943-c013-45e3-953d-34d3b4611ac4", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9df79769-5a53-407e-a2c6-fb5fa0314f62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e645fbf4-5e77-4551-9140-7d548e721c06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb396943-c013-45e3-953d-34d3b4611ac4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7eaf81b0-28a1-4bf1-a671-257045ec1258", null, "Prestataire", "PRESTATAIRE" },
                    { "9a6e5a96-f7a9-4fc5-b5b8-9667e0530e21", null, "Admin", "ADMIN" },
                    { "f38f6e15-0133-4f8c-a044-6a7a4a9d1771", null, "Client", "CLIENT" }
                });
        }
    }
}
