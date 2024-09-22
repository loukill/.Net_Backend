using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class SomeChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POSClients_AspNetUsers_ClientId",
                table: "POSClients");

            migrationBuilder.DropForeignKey(
                name: "FK_POSClients_AspNetUsers_ClientId1",
                table: "POSClients");

            migrationBuilder.DropForeignKey(
                name: "FK_POSClients_POSs_POSId",
                table: "POSClients");

            migrationBuilder.DropForeignKey(
                name: "FK_POSClients_POSs_POSId1",
                table: "POSClients");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataires_AspNetUsers_PrestataireId",
                table: "POSPrestataires");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataires_AspNetUsers_PrestataireId1",
                table: "POSPrestataires");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataires_POSs_POSId",
                table: "POSPrestataires");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataires_POSs_POSId1",
                table: "POSPrestataires");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POSPrestataires",
                table: "POSPrestataires");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POSClients",
                table: "POSClients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "166107d5-1e56-43f0-8013-d9180df5602e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba999cc3-29cc-44a6-8f28-17b122f54645");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bac2e5d8-f46a-4e0b-b28f-11043d972c8f");

            migrationBuilder.RenameTable(
                name: "POSPrestataires",
                newName: "POSPrestataire");

            migrationBuilder.RenameTable(
                name: "POSClients",
                newName: "POSClient");

            migrationBuilder.RenameIndex(
                name: "IX_POSPrestataires_PrestataireId1",
                table: "POSPrestataire",
                newName: "IX_POSPrestataire_PrestataireId1");

            migrationBuilder.RenameIndex(
                name: "IX_POSPrestataires_PrestataireId",
                table: "POSPrestataire",
                newName: "IX_POSPrestataire_PrestataireId");

            migrationBuilder.RenameIndex(
                name: "IX_POSPrestataires_POSId1",
                table: "POSPrestataire",
                newName: "IX_POSPrestataire_POSId1");

            migrationBuilder.RenameIndex(
                name: "IX_POSClients_POSId1",
                table: "POSClient",
                newName: "IX_POSClient_POSId1");

            migrationBuilder.RenameIndex(
                name: "IX_POSClients_POSId",
                table: "POSClient",
                newName: "IX_POSClient_POSId");

            migrationBuilder.RenameIndex(
                name: "IX_POSClients_ClientId1",
                table: "POSClient",
                newName: "IX_POSClient_ClientId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSPrestataire",
                table: "POSPrestataire",
                columns: new[] { "POSId", "PrestataireId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_POSClient",
                table: "POSClient",
                columns: new[] { "ClientId", "POSId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7e6b3244-5142-4cc6-b8da-7ea88c896909", null, "Admin", "ADMIN" },
                    { "b5dc934d-2c03-4077-ac6c-4467fbb8857a", null, "Client", "CLIENT" },
                    { "eefd2c44-45e6-4e30-bcb2-364073bdcd18", null, "Prestataire", "PRESTATAIRE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_POSClient_AspNetUsers_ClientId",
                table: "POSClient",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSClient_AspNetUsers_ClientId1",
                table: "POSClient",
                column: "ClientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSClient_POSs_POSId",
                table: "POSClient",
                column: "POSId",
                principalTable: "POSs",
                principalColumn: "POSId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSClient_POSs_POSId1",
                table: "POSClient",
                column: "POSId1",
                principalTable: "POSs",
                principalColumn: "POSId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSPrestataire_AspNetUsers_PrestataireId",
                table: "POSPrestataire",
                column: "PrestataireId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSPrestataire_AspNetUsers_PrestataireId1",
                table: "POSPrestataire",
                column: "PrestataireId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSPrestataire_POSs_POSId",
                table: "POSPrestataire",
                column: "POSId",
                principalTable: "POSs",
                principalColumn: "POSId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSPrestataire_POSs_POSId1",
                table: "POSPrestataire",
                column: "POSId1",
                principalTable: "POSs",
                principalColumn: "POSId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POSClient_AspNetUsers_ClientId",
                table: "POSClient");

            migrationBuilder.DropForeignKey(
                name: "FK_POSClient_AspNetUsers_ClientId1",
                table: "POSClient");

            migrationBuilder.DropForeignKey(
                name: "FK_POSClient_POSs_POSId",
                table: "POSClient");

            migrationBuilder.DropForeignKey(
                name: "FK_POSClient_POSs_POSId1",
                table: "POSClient");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataire_AspNetUsers_PrestataireId",
                table: "POSPrestataire");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataire_AspNetUsers_PrestataireId1",
                table: "POSPrestataire");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataire_POSs_POSId",
                table: "POSPrestataire");

            migrationBuilder.DropForeignKey(
                name: "FK_POSPrestataire_POSs_POSId1",
                table: "POSPrestataire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POSPrestataire",
                table: "POSPrestataire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POSClient",
                table: "POSClient");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e6b3244-5142-4cc6-b8da-7ea88c896909");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5dc934d-2c03-4077-ac6c-4467fbb8857a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eefd2c44-45e6-4e30-bcb2-364073bdcd18");

            migrationBuilder.RenameTable(
                name: "POSPrestataire",
                newName: "POSPrestataires");

            migrationBuilder.RenameTable(
                name: "POSClient",
                newName: "POSClients");

            migrationBuilder.RenameIndex(
                name: "IX_POSPrestataire_PrestataireId1",
                table: "POSPrestataires",
                newName: "IX_POSPrestataires_PrestataireId1");

            migrationBuilder.RenameIndex(
                name: "IX_POSPrestataire_PrestataireId",
                table: "POSPrestataires",
                newName: "IX_POSPrestataires_PrestataireId");

            migrationBuilder.RenameIndex(
                name: "IX_POSPrestataire_POSId1",
                table: "POSPrestataires",
                newName: "IX_POSPrestataires_POSId1");

            migrationBuilder.RenameIndex(
                name: "IX_POSClient_POSId1",
                table: "POSClients",
                newName: "IX_POSClients_POSId1");

            migrationBuilder.RenameIndex(
                name: "IX_POSClient_POSId",
                table: "POSClients",
                newName: "IX_POSClients_POSId");

            migrationBuilder.RenameIndex(
                name: "IX_POSClient_ClientId1",
                table: "POSClients",
                newName: "IX_POSClients_ClientId1");

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
                    { "166107d5-1e56-43f0-8013-d9180df5602e", null, "Prestataire", "PRESTATAIRE" },
                    { "ba999cc3-29cc-44a6-8f28-17b122f54645", null, "Client", "CLIENT" },
                    { "bac2e5d8-f46a-4e0b-b28f-11043d972c8f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_POSClients_AspNetUsers_ClientId",
                table: "POSClients",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSClients_AspNetUsers_ClientId1",
                table: "POSClients",
                column: "ClientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSClients_POSs_POSId",
                table: "POSClients",
                column: "POSId",
                principalTable: "POSs",
                principalColumn: "POSId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSClients_POSs_POSId1",
                table: "POSClients",
                column: "POSId1",
                principalTable: "POSs",
                principalColumn: "POSId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSPrestataires_AspNetUsers_PrestataireId",
                table: "POSPrestataires",
                column: "PrestataireId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSPrestataires_AspNetUsers_PrestataireId1",
                table: "POSPrestataires",
                column: "PrestataireId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_POSPrestataires_POSs_POSId",
                table: "POSPrestataires",
                column: "POSId",
                principalTable: "POSs",
                principalColumn: "POSId",
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
