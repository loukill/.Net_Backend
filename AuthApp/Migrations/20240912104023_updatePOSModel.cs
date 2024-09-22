using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class updatePOSModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "POSs",
                newName: "POSName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "POSs",
                newName: "POSLocation");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "POSs",
                newName: "POSId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "053685df-6a4b-46ac-9e56-e02d9f1a5a6c", null, "Prestataire", "PRESTATAIRE" },
                    { "9f687cec-5ffd-45e3-a19d-1b2a248c35ce", null, "Client", "CLIENT" },
                    { "d19ff91c-633d-4102-9c8e-fffa3ae78090", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053685df-6a4b-46ac-9e56-e02d9f1a5a6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f687cec-5ffd-45e3-a19d-1b2a248c35ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d19ff91c-633d-4102-9c8e-fffa3ae78090");

            migrationBuilder.RenameColumn(
                name: "POSName",
                table: "POSs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "POSLocation",
                table: "POSs",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "POSId",
                table: "POSs",
                newName: "Id");

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
    }
}
