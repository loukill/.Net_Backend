using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class ChangesEventEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Events",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrestataireResponse",
                table: "Events",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PrestataireResponse",
                table: "Events");

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
    }
}
