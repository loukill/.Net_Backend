using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddNavigationEventsPOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15283920-921b-4edc-8128-2771491a6890");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bb51ae3-7e61-4a94-997a-18af4367c471");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed20cb91-c4f9-4071-8527-02c1cd60efd8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "040afd53-fc59-42b7-9863-1adebdf17a4d", null, "Admin", "ADMIN" },
                    { "236798b3-a090-44d4-8a9d-242cf20d3fe7", null, "Client", "CLIENT" },
                    { "54d409cc-053b-46e2-9d39-bf5ce9747d03", null, "Prestataire", "PRESTATAIRE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_PosId",
                table: "Events",
                column: "PosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_POSs_PosId",
                table: "Events",
                column: "PosId",
                principalTable: "POSs",
                principalColumn: "POSId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_POSs_PosId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PosId",
                table: "Events");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15283920-921b-4edc-8128-2771491a6890", null, "Admin", "ADMIN" },
                    { "9bb51ae3-7e61-4a94-997a-18af4367c471", null, "Client", "CLIENT" },
                    { "ed20cb91-c4f9-4071-8527-02c1cd60efd8", null, "Prestataire", "PRESTATAIRE" }
                });
        }
    }
}
