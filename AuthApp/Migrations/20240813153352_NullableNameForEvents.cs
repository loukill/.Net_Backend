using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class NullableNameForEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PrestataireName",
                table: "Events",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
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
                    { "0ae9fa5a-3e7d-479c-9602-48eb69d2c430", null, "Prestataire", "PRESTATAIRE" },
                    { "1d3091a6-ee57-4b65-8a31-f0b41b44bc5f", null, "Admin", "ADMIN" },
                    { "2f59cb81-fe22-46f5-b08d-0031d83e28e4", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ae9fa5a-3e7d-479c-9602-48eb69d2c430");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d3091a6-ee57-4b65-8a31-f0b41b44bc5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f59cb81-fe22-46f5-b08d-0031d83e28e4");

            migrationBuilder.AlterColumn<string>(
                name: "PrestataireName",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
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
                    { "18a5c36c-e0ff-4963-b0c7-99948b6b938d", null, "Client", "CLIENT" },
                    { "67753636-6235-46c4-8dd6-0e76f1904d98", null, "Prestataire", "PRESTATAIRE" },
                    { "b88aac54-0160-4e4d-a47a-f3002c600ddd", null, "Admin", "ADMIN" }
                });
        }
    }
}
