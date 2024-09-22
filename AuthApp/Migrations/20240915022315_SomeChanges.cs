using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bb6bae4-6536-40e0-a370-89670a9a5c2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24229a38-a9fe-473c-a3b6-295b9dc4ffee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5e765cc-ebb0-465c-a3c1-36e2cc543f2b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "166107d5-1e56-43f0-8013-d9180df5602e", null, "Prestataire", "PRESTATAIRE" },
                    { "ba999cc3-29cc-44a6-8f28-17b122f54645", null, "Client", "CLIENT" },
                    { "bac2e5d8-f46a-4e0b-b28f-11043d972c8f", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "166107d5-1e56-43f0-8013-d9180df5602e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba999cc3-29cc-44a6-8f28-17b122f54645");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bac2e5d8-f46a-4e0b-b28f-11043d972c8f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bb6bae4-6536-40e0-a370-89670a9a5c2d", null, "Admin", "ADMIN" },
                    { "24229a38-a9fe-473c-a3b6-295b9dc4ffee", null, "Prestataire", "PRESTATAIRE" },
                    { "c5e765cc-ebb0-465c-a3c1-36e2cc543f2b", null, "Client", "CLIENT" }
                });
        }
    }
}
