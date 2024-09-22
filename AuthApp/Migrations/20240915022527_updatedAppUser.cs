using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class updatedAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e6b3244-5142-4cc6-b8da-7ea88c896909");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5dc934d-2c03-4077-ac6c-4467fbb8857a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eefd2c44-45e6-4e30-bcb2-364073bdcd18");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11a0204d-9a1a-4d06-abfa-c8eb519f6264", null, "Prestataire", "PRESTATAIRE" },
                    { "ad9a74ba-77a9-4abe-88d2-efe05525a254", null, "Client", "CLIENT" },
                    { "ce92ed3b-ef85-4943-848e-ef6d3676fc4f", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11a0204d-9a1a-4d06-abfa-c8eb519f6264");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad9a74ba-77a9-4abe-88d2-efe05525a254");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce92ed3b-ef85-4943-848e-ef6d3676fc4f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7e6b3244-5142-4cc6-b8da-7ea88c896909", null, "Admin", "ADMIN" },
                    { "b5dc934d-2c03-4077-ac6c-4467fbb8857a", null, "Client", "CLIENT" },
                    { "eefd2c44-45e6-4e30-bcb2-364073bdcd18", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
