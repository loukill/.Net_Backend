using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class deleteTypeFromService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25f52e48-9fff-4c74-81e7-3ff268bed8a1", null, "Prestataire", "PRESTATAIRE" },
                    { "9828023c-113b-44e1-aa70-e76585af6513", null, "Client", "CLIENT" },
                    { "d30f2692-eb9b-44b6-8db0-91b38c66d940", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f52e48-9fff-4c74-81e7-3ff268bed8a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9828023c-113b-44e1-aa70-e76585af6513");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30f2692-eb9b-44b6-8db0-91b38c66d940");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

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
    }
}
