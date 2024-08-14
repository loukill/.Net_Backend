using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddRoleToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "RoleUser",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a096664-2a20-498f-bdee-3fbe9126d7e7", null, "Prestataire", "PRESTATAIRE" },
                    { "7513bad3-7830-41e9-b69a-b37efecca4bc", null, "Client", "CLIENT" },
                    { "ceecb2da-aae0-4295-a639-c661f6b79c49", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a096664-2a20-498f-bdee-3fbe9126d7e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7513bad3-7830-41e9-b69a-b37efecca4bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceecb2da-aae0-4295-a639-c661f6b79c49");

            migrationBuilder.AlterColumn<int>(
                name: "RoleUser",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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
    }
}
