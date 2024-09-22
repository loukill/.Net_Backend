using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class SomeChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "11a0204d-9a1a-4d06-abfa-c8eb519f6264");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad9a74ba-77a9-4abe-88d2-efe05525a254");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce92ed3b-ef85-4943-848e-ef6d3676fc4f");

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
                    { "0c2b5261-1276-4973-84d7-bb6e556c5ff0", null, "Prestataire", "PRESTATAIRE" },
                    { "3fb2b998-f065-4d5f-b4f6-9d5b6a9d3294", null, "Client", "CLIENT" },
                    { "ba24316d-f874-48f3-9c25-90b5eafa4230", null, "Admin", "ADMIN" }
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "0c2b5261-1276-4973-84d7-bb6e556c5ff0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fb2b998-f065-4d5f-b4f6-9d5b6a9d3294");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba24316d-f874-48f3-9c25-90b5eafa4230");

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
                    { "11a0204d-9a1a-4d06-abfa-c8eb519f6264", null, "Prestataire", "PRESTATAIRE" },
                    { "ad9a74ba-77a9-4abe-88d2-efe05525a254", null, "Client", "CLIENT" },
                    { "ce92ed3b-ef85-4943-848e-ef6d3676fc4f", null, "Admin", "ADMIN" }
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
    }
}
