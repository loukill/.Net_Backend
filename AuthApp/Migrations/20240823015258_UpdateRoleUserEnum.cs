using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class UpdateRoleUserEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoleUser",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90ea4b83-0786-4325-bbfd-a1ef7b282ce2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6e83e04-57db-433a-aa06-0b2ef824b5ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff4f6060-53ce-4422-9ae1-f77a557a6d65");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
               name: "RoleUser",
               table: "AspNetUsers",
               type: "integer",
               nullable: false,
               oldClrType: typeof(string),
               oldType: "text");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "90ea4b83-0786-4325-bbfd-a1ef7b282ce2", null, "Admin", "ADMIN" },
                    { "b6e83e04-57db-433a-aa06-0b2ef824b5ef", null, "Client", "CLIENT" },
                    { "ff4f6060-53ce-4422-9ae1-f77a557a6d65", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
