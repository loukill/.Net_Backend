using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class UpdatePOSRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_POSs_POSId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_POSs_POSId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_POSs_POSId2",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_POSs_POSId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_UserServices_AspNetUsers_UserId1",
                table: "UserServices");

            migrationBuilder.DropIndex(
                name: "IX_UserServices_UserId1",
                table: "UserServices");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_POSId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_POSId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_POSId2",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7306a463-1f25-4530-9523-673bdd68132f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba84d8d5-171c-47e6-a7f3-58f365c2ef06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6c260b6-6931-4b58-91fd-1a782fb7ba2f");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserServices");

            migrationBuilder.DropColumn(
                name: "POSId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "POSId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "POSId2",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserServices",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserServices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "POSId",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "069b5fb1-acd2-47d1-9d2c-5dd8230d3253", null, "Admin", "ADMIN" },
                    { "ba9c5fa4-5298-4bb6-8c9b-c11f9115ce40", null, "Prestataire", "PRESTATAIRE" },
                    { "ee5810f2-ae5c-4755-a99f-2e89d219664d", null, "Client", "CLIENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPOS_POSId",
                table: "ClientPOS",
                column: "POSId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestatairePOS_PrestataireId",
                table: "PrestatairePOS",
                column: "PrestataireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_POSs_POSId",
                table: "Services",
                column: "POSId",
                principalTable: "POSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_POSs_POSId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ClientPOS");

            migrationBuilder.DropTable(
                name: "PrestatairePOS");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "069b5fb1-acd2-47d1-9d2c-5dd8230d3253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9c5fa4-5298-4bb6-8c9b-c11f9115ce40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee5810f2-ae5c-4755-a99f-2e89d219664d");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserServices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserServices");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserServices",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "POSId",
                table: "Services",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "POSId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "POSId1",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "POSId2",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7306a463-1f25-4530-9523-673bdd68132f", null, "Client", "CLIENT" },
                    { "ba84d8d5-171c-47e6-a7f3-58f365c2ef06", null, "Admin", "ADMIN" },
                    { "d6c260b6-6931-4b58-91fd-1a782fb7ba2f", null, "Prestataire", "PRESTATAIRE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserServices_UserId1",
                table: "UserServices",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_POSId",
                table: "AspNetUsers",
                column: "POSId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_POSId1",
                table: "AspNetUsers",
                column: "POSId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_POSId2",
                table: "AspNetUsers",
                column: "POSId2");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_POSs_POSId",
                table: "AspNetUsers",
                column: "POSId",
                principalTable: "POSs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_POSs_POSId1",
                table: "AspNetUsers",
                column: "POSId1",
                principalTable: "POSs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_POSs_POSId2",
                table: "AspNetUsers",
                column: "POSId2",
                principalTable: "POSs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_POSs_POSId",
                table: "Services",
                column: "POSId",
                principalTable: "POSs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserServices_AspNetUsers_UserId1",
                table: "UserServices",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
