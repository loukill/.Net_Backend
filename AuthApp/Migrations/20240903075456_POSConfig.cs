using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class POSConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2ac03120-0de8-428e-8f8b-3f865fc31ba2", null, "Prestataire", "PRESTATAIRE" },
                    { "549531b8-f2f5-434c-976f-fca9996066e3", null, "Admin", "ADMIN" },
                    { "7ae8358f-3461-42f2-9834-7a615f91cdf6", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ac03120-0de8-428e-8f8b-3f865fc31ba2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "549531b8-f2f5-434c-976f-fca9996066e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ae8358f-3461-42f2-9834-7a615f91cdf6");

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
    }
}
