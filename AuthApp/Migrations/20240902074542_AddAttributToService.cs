using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddAttributToService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<float>(
                name: "Prix",
                table: "Services",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31966b5e-d012-47d1-8b68-24ff3419f3ce", null, "Client", "CLIENT" },
                    { "900f4a55-f080-4c38-a325-b128f57ee586", null, "Prestataire", "PRESTATAIRE" },
                    { "dbdb9d1e-074c-4641-b617-6a224c4a880d", null, "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31966b5e-d012-47d1-8b68-24ff3419f3ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "900f4a55-f080-4c38-a325-b128f57ee586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbdb9d1e-074c-4641-b617-6a224c4a880d");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Services");

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
    }
}
