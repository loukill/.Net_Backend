using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class UpdatePOSRelationships1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "069b5fb1-acd2-47d1-9d2c-5dd8230d3253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9c5fa4-5298-4bb6-8c9b-c11f9115ce40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee5810f2-ae5c-4755-a99f-2e89d219664d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "394bef83-bc0a-448e-ba54-bd57f26411d8", null, "Prestataire", "PRESTATAIRE" },
                    { "a648b5c5-c8fa-4d90-bf80-12f8ca395565", null, "Client", "CLIENT" },
                    { "d983c174-ad60-40bc-bc2e-32cb24e5ee2d", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "394bef83-bc0a-448e-ba54-bd57f26411d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a648b5c5-c8fa-4d90-bf80-12f8ca395565");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d983c174-ad60-40bc-bc2e-32cb24e5ee2d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "069b5fb1-acd2-47d1-9d2c-5dd8230d3253", null, "Admin", "ADMIN" },
                    { "ba9c5fa4-5298-4bb6-8c9b-c11f9115ce40", null, "Prestataire", "PRESTATAIRE" },
                    { "ee5810f2-ae5c-4755-a99f-2e89d219664d", null, "Client", "CLIENT" }
                });
        }
    }
}
