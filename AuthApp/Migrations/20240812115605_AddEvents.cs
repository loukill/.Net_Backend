using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class AddEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fb97053-19c5-4dbc-b3f8-7bec63e26c13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1a672e1-db87-426c-93c0-ecc48126b91d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcb3e159-94ba-454d-8cac-44d5644e653e");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserEvents",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserEvents", x => new { x.EventsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppUserEvents_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserEvents_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "133dcc05-2d67-41f9-bb87-3e001a614da1", null, "Admin", "ADMIN" },
                    { "32f8b692-19ed-482b-80e5-f9911a933c0f", null, "Client", "CLIENT" },
                    { "82c021ac-fae5-4fbe-9863-437679f44e5b", null, "Prestataire", "PRESTATAIRE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserEvents_UsersId",
                table: "AppUserEvents",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserEvents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "133dcc05-2d67-41f9-bb87-3e001a614da1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32f8b692-19ed-482b-80e5-f9911a933c0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82c021ac-fae5-4fbe-9863-437679f44e5b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fb97053-19c5-4dbc-b3f8-7bec63e26c13", null, "Prestataire", "PRESTATAIRE" },
                    { "d1a672e1-db87-426c-93c0-ecc48126b91d", null, "Admin", "ADMIN" },
                    { "fcb3e159-94ba-454d-8cac-44d5644e653e", null, "Client", "CLIENT" }
                });
        }
    }
}
