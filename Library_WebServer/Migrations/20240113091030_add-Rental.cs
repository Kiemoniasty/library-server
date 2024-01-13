using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_WebServer.Migrations
{
    /// <inheritdoc />
    public partial class addRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsBorrow = table.Column<bool>(type: "boolean", nullable: false),
                    LibraryPublicationId = table.Column<Guid>(name: "LibraryPublication.Id", type: "uuid", nullable: false),
                    LibraryUserId = table.Column<Guid>(name: "LibraryUser.Id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Publications_LibraryPublication.Id",
                        column: x => x.LibraryPublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_LibraryUser.Id",
                        column: x => x.LibraryUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_LibraryPublication.Id",
                table: "Rentals",
                column: "LibraryPublication.Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_LibraryUser.Id",
                table: "Rentals",
                column: "LibraryUser.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");
        }
    }
}
