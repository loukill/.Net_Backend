using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class addClientNameToEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c2d7539-ed2f-419d-9e49-832c869b1b0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2da2035-1efb-44b8-be30-5ebf18ee884e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbbc2899-8393-419e-8b18-e402ca9c4a41");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Events",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9c2d7539-ed2f-419d-9e49-832c869b1b0c", null, "Client", "CLIENT" },
                    { "d2da2035-1efb-44b8-be30-5ebf18ee884e", null, "Admin", "ADMIN" },
                    { "dbbc2899-8393-419e-8b18-e402ca9c4a41", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
