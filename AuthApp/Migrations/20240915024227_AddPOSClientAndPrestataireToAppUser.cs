using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddPOSClientAndPrestataireToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POSClients_AspNetUsers_ClientId1",
                table: "POSClients");

            migrationBuilder.DropForeignKey(
                name: "FK_POSClients_POSs_POSId1",
                table: "POSClients");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataires_AspNetUsers_PrestataireId1",
                table: "POSPrestataires");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataires_POSs_POSId1",
                table: "POSPrestataires");

            migrationBuilder.DropIndex(
                name: "IX_POSPrestataires_POSId1",
                table: "POSPrestataires");

            migrationBuilder.DropIndex(
                name: "IX_POSPrestataires_PrestataireId1",
                table: "POSPrestataires");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POSClients",
                table: "POSClients");

            migrationBuilder.DropIndex(
                name: "IX_POSClients_ClientId1",
                table: "POSClients");

            migrationBuilder.DropIndex(
                name: "IX_POSClients_POSId",
                table: "POSClients");

            migrationBuilder.DropIndex(
                name: "IX_POSClients_POSId1",
                table: "POSClients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c2b5261-1276-4973-84d7-bb6e556c5ff0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fb2b998-f065-4d5f-b4f6-9d5b6a9d3294");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba24316d-f874-48f3-9c25-90b5eafa4230");

            migrationBuilder.DropColumn(
                name: "POSId1",
                table: "POSPrestataires");

            migrationBuilder.DropColumn(
                name: "PrestataireId1",
                table: "POSPrestataires");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "POSClients");

            migrationBuilder.DropColumn(
                name: "POSId1",
                table: "POSClients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSClients",
                table: "POSClients",
                columns: new[] { "POSId", "ClientId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15283920-921b-4edc-8128-2771491a6890", null, "Admin", "ADMIN" },
                    { "9bb51ae3-7e61-4a94-997a-18af4367c471", null, "Client", "CLIENT" },
                    { "ed20cb91-c4f9-4071-8527-02c1cd60efd8", null, "Prestataire", "PRESTATAIRE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_POSClients_ClientId",
                table: "POSClients",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_POSClients",
                table: "POSClients");

            migrationBuilder.DropIndex(
                name: "IX_POSClients_ClientId",
                table: "POSClients");

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

            migrationBuilder.AddColumn<int>(
                name: "POSId1",
                table: "POSPrestataires",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrestataireId1",
                table: "POSPrestataires",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientId1",
                table: "POSClients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "POSId1",
                table: "POSClients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSClients",
                table: "POSClients",
                columns: new[] { "ClientId", "POSId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c2b5261-1276-4973-84d7-bb6e556c5ff0", null, "Prestataire", "PRESTATAIRE" },
                    { "3fb2b998-f065-4d5f-b4f6-9d5b6a9d3294", null, "Client", "CLIENT" },
                    { "ba24316d-f874-48f3-9c25-90b5eafa4230", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_POSPrestataires_POSId1",
                table: "POSPrestataires",
                column: "POSId1");

            migrationBuilder.CreateIndex(
                name: "IX_POSPrestataires_PrestataireId1",
                table: "POSPrestataires",
                column: "PrestataireId1");

            migrationBuilder.CreateIndex(
                name: "IX_POSClients_ClientId1",
                table: "POSClients",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_POSClients_POSId",
                table: "POSClients",
                column: "POSId");

            migrationBuilder.CreateIndex(
                name: "IX_POSClients_POSId1",
                table: "POSClients",
                column: "POSId1");

            migrationBuilder.AddForeignKey(
                name: "FK_POSClients_AspNetUsers_ClientId1",
                table: "POSClients",
                column: "ClientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSClients_POSs_POSId1",
                table: "POSClients",
                column: "POSId1",
                principalTable: "POSs",
                principalColumn: "POSId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSPrestataires_AspNetUsers_PrestataireId1",
                table: "POSPrestataires",
                column: "PrestataireId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSPrestataires_POSs_POSId1",
                table: "POSPrestataires",
                column: "POSId1",
                principalTable: "POSs",
                principalColumn: "POSId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
