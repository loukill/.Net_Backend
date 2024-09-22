using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddImageUrlToPOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "POSs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32171127-7b94-4c87-a76d-34a3b081a095", null, "Prestataire", "PRESTATAIRE" },
                    { "417311ff-02cf-4891-83e6-25eb92fc2588", null, "Client", "CLIENT" },
                    { "8b05ea66-7d75-463e-9673-8553cdaf186a", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32171127-7b94-4c87-a76d-34a3b081a095");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "417311ff-02cf-4891-83e6-25eb92fc2588");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b05ea66-7d75-463e-9673-8553cdaf186a");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "POSs");

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
    }
}
