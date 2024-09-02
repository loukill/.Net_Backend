using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddPasswordResetToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57081f55-dc91-4650-a2af-3750c0edccff", null, "Client", "CLIENT" },
                    { "6014d24d-0b05-4edd-8226-381043793c9f", null, "Prestataire", "PRESTATAIRE" },
                    { "c7b313b7-8d4b-4a28-89a1-483e1b5f38c1", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordResetTokens");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57081f55-dc91-4650-a2af-3750c0edccff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6014d24d-0b05-4edd-8226-381043793c9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b313b7-8d4b-4a28-89a1-483e1b5f38c1");

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
    }
}
