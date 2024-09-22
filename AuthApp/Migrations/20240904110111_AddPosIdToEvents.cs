using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddPosIdToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32171127-7b94-4c87-a76d-34a3b081a095");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "417311ff-02cf-4891-83e6-25eb92fc2588");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b05ea66-7d75-463e-9673-8553cdaf186a");

            migrationBuilder.AddColumn<int>(
                name: "PosId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a6c5d81-0754-425a-8b57-772e57b9398a", null, "Prestataire", "PRESTATAIRE" },
                    { "6d590d5e-b98c-4e3d-a4d3-e32465bf1c7f", null, "Admin", "ADMIN" },
                    { "d9f810d7-7fd1-4edf-8a5d-abf6a52a5875", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a6c5d81-0754-425a-8b57-772e57b9398a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d590d5e-b98c-4e3d-a4d3-e32465bf1c7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9f810d7-7fd1-4edf-8a5d-abf6a52a5875");

            migrationBuilder.DropColumn(
                name: "PosId",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32171127-7b94-4c87-a76d-34a3b081a095", null, "Prestataire", "PRESTATAIRE" },
                    { "417311ff-02cf-4891-83e6-25eb92fc2588", null, "Client", "CLIENT" },
                    { "8b05ea66-7d75-463e-9673-8553cdaf186a", null, "Admin", "ADMIN" }
                });
        }
    }
}
