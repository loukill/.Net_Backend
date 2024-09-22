using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class MakePrestataireIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a6c5d81-0754-425a-8b57-772e57b9398a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d590d5e-b98c-4e3d-a4d3-e32465bf1c7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9f810d7-7fd1-4edf-8a5d-abf6a52a5875");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87e5c095-cbe4-4129-bf70-ce759076b2ce", null, "Client", "CLIENT" },
                    { "b11feaf6-0555-41eb-a340-bfc63bb3ba6e", null, "Prestataire", "PRESTATAIRE" },
                    { "ddeb789c-7a8d-42aa-8987-0cbd20c8d179", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e5c095-cbe4-4129-bf70-ce759076b2ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b11feaf6-0555-41eb-a340-bfc63bb3ba6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddeb789c-7a8d-42aa-8987-0cbd20c8d179");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a6c5d81-0754-425a-8b57-772e57b9398a", null, "Prestataire", "PRESTATAIRE" },
                    { "6d590d5e-b98c-4e3d-a4d3-e32465bf1c7f", null, "Admin", "ADMIN" },
                    { "d9f810d7-7fd1-4edf-8a5d-abf6a52a5875", null, "Client", "CLIENT" }
                });
        }
    }
}
