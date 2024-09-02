using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class MakeRefreshTokenNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b30f6721-ba26-46d9-ac1b-17afca4e7d5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc6ac5b7-b746-4992-9474-1c46cc883a7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e74cfd06-fb2f-426d-845b-bef3c913abc2");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ba9e1693-46c6-4013-b649-294589e8f528", null, "Client", "CLIENT" },
                    { "d6fdf481-de1b-48da-ac26-46244b48dd7d", null, "Admin", "ADMIN" },
                    { "e09b4a27-72db-4de1-b509-10644c7cafe6", null, "Prestataire", "PRESTATAIRE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9e1693-46c6-4013-b649-294589e8f528");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6fdf481-de1b-48da-ac26-46244b48dd7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e09b4a27-72db-4de1-b509-10644c7cafe6");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
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
                    { "b30f6721-ba26-46d9-ac1b-17afca4e7d5e", null, "Admin", "ADMIN" },
                    { "cc6ac5b7-b746-4992-9474-1c46cc883a7e", null, "Prestataire", "PRESTATAIRE" },
                    { "e74cfd06-fb2f-426d-845b-bef3c913abc2", null, "Client", "CLIENT" }
                });
        }
    }
}
