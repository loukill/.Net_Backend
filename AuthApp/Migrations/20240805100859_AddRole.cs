using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "AspNetUsers");

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
    }
}
