using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class MakeRefreshTokenExpiresNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10d94c93-d407-4169-ab2c-5fb5a62868bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3fab43-5dbe-427d-90fb-2ece997008b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6df3877-83c2-4de8-935e-56eb03c58e83");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpires",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpires",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10d94c93-d407-4169-ab2c-5fb5a62868bf", null, "Admin", "ADMIN" },
                    { "2d3fab43-5dbe-427d-90fb-2ece997008b7", null, "Prestataire", "PRESTATAIRE" },
                    { "f6df3877-83c2-4de8-935e-56eb03c58e83", null, "Client", "CLIENT" }
                });
        }
    }
}
