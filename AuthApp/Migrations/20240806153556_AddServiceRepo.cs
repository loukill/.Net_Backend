using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddServiceRepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c7be4f0-7971-4199-94d4-a960ca784a9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37862e65-79e7-4bb7-848f-bd78d907e65a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73c9d290-2964-4f68-bd31-74fe4180b7e7");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "UserServices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Services",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a8d88ea-b076-4166-b536-e7e8e6cdf4fc", null, "Admin", "ADMIN" },
                    { "97482078-06ca-4c65-8f63-a0f46a242a9a", null, "Client", "CLIENT" },
                    { "ad9ac570-c7dd-4542-8067-0e19226d077b", null, "Prestataire", "PRESTATAIRE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a8d88ea-b076-4166-b536-e7e8e6cdf4fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97482078-06ca-4c65-8f63-a0f46a242a9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad9ac570-c7dd-4542-8067-0e19226d077b");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "UserServices",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Services",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c7be4f0-7971-4199-94d4-a960ca784a9b", null, "Admin", "ADMIN" },
                    { "37862e65-79e7-4bb7-848f-bd78d907e65a", null, "Client", "CLIENT" },
                    { "73c9d290-2964-4f68-bd31-74fe4180b7e7", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
