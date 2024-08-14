using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class RoleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b1c9b6d-5ab6-4f74-be7f-27ecc486cf4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60ccd9f5-4b7c-46fa-b58e-8b09ecbc369e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9e6aac2-7345-431f-a8b1-21a5b921700a");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "AspNetUsers",
                newName: "RoleUser");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a701fe6-2c0c-4c1e-8719-8ccd32ab3e61", null, "Client", "CLIENT" },
                    { "8bf76aaf-643e-49c7-95a7-8dfe32070936", null, "Prestataire", "PRESTATAIRE" },
                    { "f4452611-a22a-4e4b-ba33-e70c2421cd5b", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a701fe6-2c0c-4c1e-8719-8ccd32ab3e61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bf76aaf-643e-49c7-95a7-8dfe32070936");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4452611-a22a-4e4b-ba33-e70c2421cd5b");

            migrationBuilder.RenameColumn(
                name: "RoleUser",
                table: "AspNetUsers",
                newName: "Role");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b1c9b6d-5ab6-4f74-be7f-27ecc486cf4f", null, "Admin", "ADMIN" },
                    { "60ccd9f5-4b7c-46fa-b58e-8b09ecbc369e", null, "Client", "CLIENT" },
                    { "e9e6aac2-7345-431f-a8b1-21a5b921700a", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
