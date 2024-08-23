using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class NullableEventDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2614fc3a-ea9e-4714-be75-4dcc4536cc7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35925225-3e63-4a80-8121-f4d36a668176");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b322189e-7dbc-4d0d-b9bc-6759b0854be3");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    { "2614fc3a-ea9e-4714-be75-4dcc4536cc7c", null, "Admin", "ADMIN" },
                    { "35925225-3e63-4a80-8121-f4d36a668176", null, "Client", "CLIENT" },
                    { "b322189e-7dbc-4d0d-b9bc-6759b0854be3", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
