using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class MakeAdminIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e5c095-cbe4-4129-bf70-ce759076b2ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b11feaf6-0555-41eb-a340-bfc63bb3ba6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddeb789c-7a8d-42aa-8987-0cbd20c8d179");

            migrationBuilder.AlterColumn<string>(
                name: "PrestataireId",
                table: "Events",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82184025-30cb-449d-b646-236f3898bf75", null, "Prestataire", "PRESTATAIRE" },
                    { "df0f5b54-df10-4345-ba41-87334e97fb4c", null, "Admin", "ADMIN" },
                    { "eaae655f-3a77-44aa-b235-8e1f1e1fe83b", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82184025-30cb-449d-b646-236f3898bf75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df0f5b54-df10-4345-ba41-87334e97fb4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaae655f-3a77-44aa-b235-8e1f1e1fe83b");

            migrationBuilder.AlterColumn<string>(
                name: "PrestataireId",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87e5c095-cbe4-4129-bf70-ce759076b2ce", null, "Client", "CLIENT" },
                    { "b11feaf6-0555-41eb-a340-bfc63bb3ba6e", null, "Prestataire", "PRESTATAIRE" },
                    { "ddeb789c-7a8d-42aa-8987-0cbd20c8d179", null, "Admin", "ADMIN" }
                });
        }
    }
}
