using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class MailVerification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38605efd-ba0c-48b6-b53c-c6ef7e4beac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eecc6d50-c3d9-49d7-b662-91273124b584");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f21e2499-5db8-4c7b-a49c-f5ab5252aff0");

            migrationBuilder.AddColumn<bool>(
                name: "IsValidated",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsValidated",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38605efd-ba0c-48b6-b53c-c6ef7e4beac9", null, "Admin", "ADMIN" },
                    { "eecc6d50-c3d9-49d7-b662-91273124b584", null, "Client", "CLIENT" },
                    { "f21e2499-5db8-4c7b-a49c-f5ab5252aff0", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
