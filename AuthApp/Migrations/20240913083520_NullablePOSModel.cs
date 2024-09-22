using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class NullablePOSModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053685df-6a4b-46ac-9e56-e02d9f1a5a6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f687cec-5ffd-45e3-a19d-1b2a248c35ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d19ff91c-633d-4102-9c8e-fffa3ae78090");

            migrationBuilder.AlterColumn<string>(
                name: "POSName",
                table: "POSs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "POSLocation",
                table: "POSs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "POSs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "POSs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7eaf81b0-28a1-4bf1-a671-257045ec1258", null, "Prestataire", "PRESTATAIRE" },
                    { "9a6e5a96-f7a9-4fc5-b5b8-9667e0530e21", null, "Admin", "ADMIN" },
                    { "f38f6e15-0133-4f8c-a044-6a7a4a9d1771", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eaf81b0-28a1-4bf1-a671-257045ec1258");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a6e5a96-f7a9-4fc5-b5b8-9667e0530e21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f38f6e15-0133-4f8c-a044-6a7a4a9d1771");

            migrationBuilder.AlterColumn<string>(
                name: "POSName",
                table: "POSs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POSLocation",
                table: "POSs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "POSs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "POSs",
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
                    { "053685df-6a4b-46ac-9e56-e02d9f1a5a6c", null, "Prestataire", "PRESTATAIRE" },
                    { "9f687cec-5ffd-45e3-a19d-1b2a248c35ce", null, "Client", "CLIENT" },
                    { "d19ff91c-633d-4102-9c8e-fffa3ae78090", null, "Admin", "ADMIN" }
                });
        }
    }
}
