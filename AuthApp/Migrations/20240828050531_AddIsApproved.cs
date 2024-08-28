using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddIsApproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27ae1319-807b-4d07-921c-b3de3c955ed8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43a54755-3b11-4c94-b245-1ccdf448d8e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fabe3f2a-555e-4bcf-8fd9-e8bdf7e0e45b");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10d94c93-d407-4169-ab2c-5fb5a62868bf", null, "Admin", "ADMIN" },
                    { "2d3fab43-5dbe-427d-90fb-2ece997008b7", null, "Prestataire", "PRESTATAIRE" },
                    { "f6df3877-83c2-4de8-935e-56eb03c58e83", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10d94c93-d407-4169-ab2c-5fb5a62868bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3fab43-5dbe-427d-90fb-2ece997008b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6df3877-83c2-4de8-935e-56eb03c58e83");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27ae1319-807b-4d07-921c-b3de3c955ed8", null, "Prestataire", "PRESTATAIRE" },
                    { "43a54755-3b11-4c94-b245-1ccdf448d8e2", null, "Admin", "ADMIN" },
                    { "fabe3f2a-555e-4bcf-8fd9-e8bdf7e0e45b", null, "Client", "CLIENT" }
                });
        }
    }
}
