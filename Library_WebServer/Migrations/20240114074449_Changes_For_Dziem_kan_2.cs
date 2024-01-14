using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_WebServer.Migrations
{
    /// <inheritdoc />
    public partial class Changes_For_Dziem_kan_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Publications",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseYear",
                table: "Publications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Publications");
        }
    }
}
