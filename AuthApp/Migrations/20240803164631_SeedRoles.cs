using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00ddad67-7434-4b18-9edc-967adebe247d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf8eee49-0bb4-480d-aa41-1812d225382c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a480dbb-c1f4-4549-a619-3c1e477b5cce", null, "Prestataire", "PRESTATAIRE" },
                    { "619666c1-41ea-49bf-9c21-da9225809ec0", null, "Admin", "ADMIN" },
                    { "6c915c34-5dde-4fb1-bc8a-c208ac1ed445", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a480dbb-c1f4-4549-a619-3c1e477b5cce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "619666c1-41ea-49bf-9c21-da9225809ec0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c915c34-5dde-4fb1-bc8a-c208ac1ed445");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00ddad67-7434-4b18-9edc-967adebe247d", null, "User", "USER" },
                    { "bf8eee49-0bb4-480d-aa41-1812d225382c", null, "Admin", "ADMIN" }
                });
        }
    }
}
