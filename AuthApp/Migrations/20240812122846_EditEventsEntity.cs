using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class EditEventsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserEvents");

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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "PrestataireId");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRequest",
                table: "Events",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventStatus",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "289eb5db-79a3-4c41-85d6-dd0a77d2ba37", null, "Client", "CLIENT" },
                    { "49e911ae-744b-458d-8baf-7b060de8d1ad", null, "Prestataire", "PRESTATAIRE" },
                    { "becbf96b-733e-42bd-a3c2-d0f4197703bf", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ClientId",
                table: "Events",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PrestataireId",
                table: "Events",
                column: "PrestataireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_ClientId",
                table: "Events",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_PrestataireId",
                table: "Events",
                column: "PrestataireId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_ClientId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_PrestataireId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ClientId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PrestataireId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "289eb5db-79a3-4c41-85d6-dd0a77d2ba37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49e911ae-744b-458d-8baf-7b060de8d1ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "becbf96b-733e-42bd-a3c2-d0f4197703bf");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DateRequest",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventStatus",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "PrestataireId",
                table: "Events",
                newName: "Name");

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
    }
}
