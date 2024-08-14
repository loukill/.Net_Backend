using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class EventEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "289eb5db-79a3-4c41-85d6-dd0a77d2ba37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49e911ae-744b-458d-8baf-7b060de8d1ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "becbf96b-733e-42bd-a3c2-d0f4197703bf");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Events",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26011fd4-3b12-4ab4-ad93-4d5bcdf1e0ec", null, "Prestataire", "PRESTATAIRE" },
                    { "b1c5a034-85a9-4247-8b06-3c8f18425c26", null, "Admin", "ADMIN" },
                    { "eb5c0b60-f266-4002-911d-0b0258bf2f07", null, "Client", "CLIENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_AdminId",
                table: "Events",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_AdminId",
                table: "Events",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_AdminId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_AdminId",
                table: "Events");

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

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "289eb5db-79a3-4c41-85d6-dd0a77d2ba37", null, "Client", "CLIENT" },
                    { "49e911ae-744b-458d-8baf-7b060de8d1ad", null, "Prestataire", "PRESTATAIRE" },
                    { "becbf96b-733e-42bd-a3c2-d0f4197703bf", null, "Admin", "ADMIN" }
                });
        }
    }
}
