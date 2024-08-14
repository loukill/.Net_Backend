using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class RenameRoleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "280e0e37-c523-4fce-995e-0bfe1a2cebe9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf3169b-ff6f-4df0-a1cb-17424f16ae54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c96a04e2-b4aa-441d-a07b-05c7f6cf039f");

            migrationBuilder.RenameColumn(
                name: "Roles",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Roles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "280e0e37-c523-4fce-995e-0bfe1a2cebe9", null, "Admin", "ADMIN" },
                    { "adf3169b-ff6f-4df0-a1cb-17424f16ae54", null, "Prestataire", "PRESTATAIRE" },
                    { "c96a04e2-b4aa-441d-a07b-05c7f6cf039f", null, "Client", "CLIENT" }
                });
        }
    }
}
