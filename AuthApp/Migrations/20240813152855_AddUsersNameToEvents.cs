using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddUsersNameToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26011fd4-3b12-4ab4-ad93-4d5bcdf1e0ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1c5a034-85a9-4247-8b06-3c8f18425c26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb5c0b60-f266-4002-911d-0b0258bf2f07");

            migrationBuilder.AddColumn<string>(
                name: "AdminName",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrestataireName",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18a5c36c-e0ff-4963-b0c7-99948b6b938d", null, "Client", "CLIENT" },
                    { "67753636-6235-46c4-8dd6-0e76f1904d98", null, "Prestataire", "PRESTATAIRE" },
                    { "b88aac54-0160-4e4d-a47a-f3002c600ddd", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18a5c36c-e0ff-4963-b0c7-99948b6b938d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67753636-6235-46c4-8dd6-0e76f1904d98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b88aac54-0160-4e4d-a47a-f3002c600ddd");

            migrationBuilder.DropColumn(
                name: "AdminName",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PrestataireName",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26011fd4-3b12-4ab4-ad93-4d5bcdf1e0ec", null, "Prestataire", "PRESTATAIRE" },
                    { "b1c5a034-85a9-4247-8b06-3c8f18425c26", null, "Admin", "ADMIN" },
                    { "eb5c0b60-f266-4002-911d-0b0258bf2f07", null, "Client", "CLIENT" }
                });
        }
    }
}
