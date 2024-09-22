using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddPOSAssociation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31966b5e-d012-47d1-8b68-24ff3419f3ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "900f4a55-f080-4c38-a325-b128f57ee586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbdb9d1e-074c-4641-b617-6a224c4a880d");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserServices",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "POSId",
                table: "Services",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "POSs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    AdminId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POSs_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Services_POSId",
                table: "Services",
                column: "POSId");

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

            migrationBuilder.CreateIndex(
                name: "IX_POSs_AdminId",
                table: "POSs",
                column: "AdminId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "POSs");

            migrationBuilder.DropIndex(
                name: "IX_UserServices_UserId1",
                table: "UserServices");

            migrationBuilder.DropIndex(
                name: "IX_Services_POSId",
                table: "Services");

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
                table: "Services");

            migrationBuilder.DropColumn(
                name: "POSId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "POSId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "POSId2",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31966b5e-d012-47d1-8b68-24ff3419f3ce", null, "Client", "CLIENT" },
                    { "900f4a55-f080-4c38-a325-b128f57ee586", null, "Prestataire", "PRESTATAIRE" },
                    { "dbdb9d1e-074c-4641-b617-6a224c4a880d", null, "Admin", "ADMIN" }
                });
        }
    }
}
