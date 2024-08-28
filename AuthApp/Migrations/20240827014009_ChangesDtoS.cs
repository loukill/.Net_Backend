using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class ChangesDtoS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bdcb1b4-82c9-4669-ace8-92c6ad12974c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4439524-510c-412f-a5ab-78d89192e6a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6ae1db0-f651-42b4-85c1-4b5127bee888");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9bdcb1b4-82c9-4669-ace8-92c6ad12974c", null, "Client", "CLIENT" },
                    { "c4439524-510c-412f-a5ab-78d89192e6a5", null, "Prestataire", "PRESTATAIRE" },
                    { "c6ae1db0-f651-42b4-85c1-4b5127bee888", null, "Admin", "ADMIN" }
                });
        }
    }
}
