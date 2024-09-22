using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class updatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientPOS");

            migrationBuilder.DropTable(
                name: "PrestatairePOS");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9df79769-5a53-407e-a2c6-fb5fa0314f62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e645fbf4-5e77-4551-9140-7d548e721c06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb396943-c013-45e3-953d-34d3b4611ac4");

            migrationBuilder.CreateTable(
                name: "POSClients",
                columns: table => new
                {
                    POSClientId = table.Column<string>(type: "text", nullable: false),
                    POSId = table.Column<int>(type: "integer", nullable: false),
                    POSId1 = table.Column<int>(type: "integer", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    ClientId1 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSClients", x => x.POSClientId);
                    table.ForeignKey(
                        name: "FK_POSClients_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POSClients_AspNetUsers_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POSClients_POSs_POSId",
                        column: x => x.POSId,
                        principalTable: "POSs",
                        principalColumn: "POSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POSClients_POSs_POSId1",
                        column: x => x.POSId1,
                        principalTable: "POSs",
                        principalColumn: "POSId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "POSPrestataires",
                columns: table => new
                {
                    POSPrestataireId = table.Column<string>(type: "text", nullable: false),
                    POSId = table.Column<int>(type: "integer", nullable: false),
                    POSId1 = table.Column<int>(type: "integer", nullable: false),
                    PrestataireId = table.Column<string>(type: "text", nullable: false),
                    PrestataireId1 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSPrestataires", x => x.POSPrestataireId);
                    table.ForeignKey(
                        name: "FK_POSPrestataires_AspNetUsers_PrestataireId",
                        column: x => x.PrestataireId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POSPrestataires_AspNetUsers_PrestataireId1",
                        column: x => x.PrestataireId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POSPrestataires_POSs_POSId",
                        column: x => x.POSId,
                        principalTable: "POSs",
                        principalColumn: "POSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POSPrestataires_POSs_POSId1",
                        column: x => x.POSId1,
                        principalTable: "POSs",
                        principalColumn: "POSId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_POSClients_ClientId",
                table: "POSClients",
                column: "ClientId");

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

            migrationBuilder.CreateIndex(
                name: "IX_POSPrestataires_POSId",
                table: "POSPrestataires",
                column: "POSId");

            migrationBuilder.CreateIndex(
                name: "IX_POSPrestataires_POSId1",
                table: "POSPrestataires",
                column: "POSId1");

            migrationBuilder.CreateIndex(
                name: "IX_POSPrestataires_PrestataireId",
                table: "POSPrestataires",
                column: "PrestataireId");

            migrationBuilder.CreateIndex(
                name: "IX_POSPrestataires_PrestataireId1",
                table: "POSPrestataires",
                column: "PrestataireId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POSClients");

            migrationBuilder.DropTable(
                name: "POSPrestataires");

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

            migrationBuilder.CreateTable(
                name: "ClientPOS",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    POSId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPOS", x => new { x.ClientId, x.POSId });
                    table.ForeignKey(
                        name: "FK_ClientPOS_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientPOS_POSs_POSId",
                        column: x => x.POSId,
                        principalTable: "POSs",
                        principalColumn: "POSId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrestatairePOS",
                columns: table => new
                {
                    POSId = table.Column<int>(type: "integer", nullable: false),
                    PrestataireId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestatairePOS", x => new { x.POSId, x.PrestataireId });
                    table.ForeignKey(
                        name: "FK_PrestatairePOS_AspNetUsers_PrestataireId",
                        column: x => x.PrestataireId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestatairePOS_POSs_POSId",
                        column: x => x.POSId,
                        principalTable: "POSs",
                        principalColumn: "POSId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9df79769-5a53-407e-a2c6-fb5fa0314f62", null, "Prestataire", "PRESTATAIRE" },
                    { "e645fbf4-5e77-4551-9140-7d548e721c06", null, "Admin", "ADMIN" },
                    { "fb396943-c013-45e3-953d-34d3b4611ac4", null, "Client", "CLIENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPOS_POSId",
                table: "ClientPOS",
                column: "POSId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestatairePOS_PrestataireId",
                table: "PrestatairePOS",
                column: "PrestataireId");
        }
    }
}
