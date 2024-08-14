using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6244702d-f18f-4509-9393-7fc7782425be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6be1fec-ffc7-4bbe-ad21-4ec5a0a533af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00ddad67-7434-4b18-9edc-967adebe247d", null, "User", "USER" },
                    { "bf8eee49-0bb4-480d-aa41-1812d225382c", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "6244702d-f18f-4509-9393-7fc7782425be", "b3afcc25-1640-47af-ac01-aa2a6baa4f41", "Admin", "ADMIN" },
                    { "b6be1fec-ffc7-4bbe-ad21-4ec5a0a533af", "dfc9c574-6c15-4ae7-b8f7-0a524d33c6c8", "User", "USER" }
                });
        }
    }
}
