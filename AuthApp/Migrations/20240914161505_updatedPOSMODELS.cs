using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class updatedPOSMODELS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_POSPrestataires",
                table: "POSPrestataires");

            migrationBuilder.DropIndex(
                name: "IX_POSPrestataires_POSId",
                table: "POSPrestataires");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POSClients",
                table: "POSClients");

            migrationBuilder.DropIndex(
                name: "IX_POSClients_ClientId",
                table: "POSClients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399f1e20-6d20-4260-a940-d5d6359620f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da7bdf6-0bfc-4343-92db-9f37914a5302");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa1f4986-a9ea-4bae-b37d-f606c5bade9c");

            migrationBuilder.DropColumn(
                name: "POSPrestataireId",
                table: "POSPrestataires");

            migrationBuilder.DropColumn(
                name: "POSClientId",
                table: "POSClients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSPrestataires",
                table: "POSPrestataires",
                columns: new[] { "POSId", "PrestataireId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSClients",
                table: "POSClients",
                columns: new[] { "ClientId", "POSId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bb6bae4-6536-40e0-a370-89670a9a5c2d", null, "Admin", "ADMIN" },
                    { "24229a38-a9fe-473c-a3b6-295b9dc4ffee", null, "Prestataire", "PRESTATAIRE" },
                    { "c5e765cc-ebb0-465c-a3c1-36e2cc543f2b", null, "Client", "CLIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_POSPrestataires",
                table: "POSPrestataires");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POSClients",
                table: "POSClients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bb6bae4-6536-40e0-a370-89670a9a5c2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24229a38-a9fe-473c-a3b6-295b9dc4ffee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5e765cc-ebb0-465c-a3c1-36e2cc543f2b");

            migrationBuilder.AddColumn<string>(
                name: "POSPrestataireId",
                table: "POSPrestataires",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "POSClientId",
                table: "POSClients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSPrestataires",
                table: "POSPrestataires",
                column: "POSPrestataireId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSClients",
                table: "POSClients",
                column: "POSClientId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "399f1e20-6d20-4260-a940-d5d6359620f5", null, "Client", "CLIENT" },
                    { "4da7bdf6-0bfc-4343-92db-9f37914a5302", null, "Prestataire", "PRESTATAIRE" },
                    { "fa1f4986-a9ea-4bae-b37d-f606c5bade9c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_POSPrestataires_POSId",
                table: "POSPrestataires",
                column: "POSId");

            migrationBuilder.CreateIndex(
                name: "IX_POSClients_ClientId",
                table: "POSClients",
                column: "ClientId");
        }
    }
}
