using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_WebServer.Migrations
{
    /// <inheritdoc />
    public partial class _2024_01_07_Added_Changes_To_Everything_AKA_Initial_2_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Reservations",
                newName: "LibraryUser.Id");

            migrationBuilder.RenameColumn(
                name: "LibraryPublication",
                table: "Reservations",
                newName: "LibraryPublication.Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "LibraryUser.Id");

            migrationBuilder.RenameColumn(
                name: "PublicationId",
                table: "Comments",
                newName: "LibraryPublication.Id");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "LibraryAuthor.Id",
            //    table: "Publications",
            //    type: "uuid",
            //    nullable: false,
            //    defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            //migrationBuilder.AddColumn<int>(
            //    name: "LibraryObjectStatus.Id",
            //    table: "Publications",
            //    type: "integer",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LibraryPublication.Id",
                table: "Reservations",
                column: "LibraryPublication.Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LibraryUser.Id",
                table: "Reservations",
                column: "LibraryUser.Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Publications_LibraryAuthor.Id",
            //    table: "Publications",
            //    column: "LibraryAuthor.Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Publications_LibraryObjectStatus.Id",
            //    table: "Publications",
            //    column: "LibraryObjectStatus.Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LibraryPublication.Id",
                table: "Comments",
                column: "LibraryPublication.Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LibraryUser.Id",
                table: "Comments",
                column: "LibraryUser.Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Publications_LibraryPublication.Id",
                table: "Comments",
                column: "LibraryPublication.Id",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_LibraryUser.Id",
                table: "Comments",
                column: "LibraryUser.Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Publications_Authors_LibraryAuthor.Id",
            //    table: "Publications",
            //    column: "LibraryAuthor.Id",
            //    principalTable: "Authors",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Statuses_LibraryObjectStatus.Id",
                table: "Publications",
                column: "LibraryObjectStatus.Id",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Publications_LibraryPublication.Id",
                table: "Reservations",
                column: "LibraryPublication.Id",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_LibraryUser.Id",
                table: "Reservations",
                column: "LibraryUser.Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Publications_LibraryPublication.Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_LibraryUser.Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Authors_LibraryAuthor.Id",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Statuses_LibraryObjectStatus.Id",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Publications_LibraryPublication.Id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_LibraryUser.Id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_LibraryPublication.Id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_LibraryUser.Id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Publications_LibraryAuthor.Id",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_LibraryObjectStatus.Id",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Comments_LibraryPublication.Id",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_LibraryUser.Id",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LibraryAuthor.Id",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "LibraryObjectStatus.Id",
                table: "Publications");

            migrationBuilder.RenameColumn(
                name: "LibraryUser.Id",
                table: "Reservations",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "LibraryPublication.Id",
                table: "Reservations",
                newName: "LibraryPublication");

            migrationBuilder.RenameColumn(
                name: "LibraryUser.Id",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LibraryPublication.Id",
                table: "Comments",
                newName: "PublicationId");
        }
    }
}
