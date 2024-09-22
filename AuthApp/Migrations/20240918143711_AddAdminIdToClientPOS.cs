using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddAdminIdToClientPOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "040afd53-fc59-42b7-9863-1adebdf17a4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "236798b3-a090-44d4-8a9d-242cf20d3fe7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d409cc-053b-46e2-9d39-bf5ce9747d03");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "POSClients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b862d84-429c-48b8-bb89-72512fc408bc", null, "Admin", "ADMIN" },
                    { "5f4b4a65-0b41-444d-a20f-8c4dc6c60148", null, "Prestataire", "PRESTATAIRE" },
                    { "bb90692d-64d0-4658-a106-0ae60d492240", null, "Client", "CLIENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_POSClients_AdminId",
                table: "POSClients",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_POSClients_AspNetUsers_AdminId",
                table: "POSClients",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POSClients_AspNetUsers_AdminId",
                table: "POSClients");

            migrationBuilder.DropIndex(
                name: "IX_POSClients_AdminId",
                table: "POSClients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b862d84-429c-48b8-bb89-72512fc408bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f4b4a65-0b41-444d-a20f-8c4dc6c60148");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb90692d-64d0-4658-a106-0ae60d492240");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "POSClients");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "040afd53-fc59-42b7-9863-1adebdf17a4d", null, "Admin", "ADMIN" },
                    { "236798b3-a090-44d4-8a9d-242cf20d3fe7", null, "Client", "CLIENT" },
                    { "54d409cc-053b-46e2-9d39-bf5ce9747d03", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
