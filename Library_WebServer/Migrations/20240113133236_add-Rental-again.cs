using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_WebServer.Migrations
{
    /// <inheritdoc />
    public partial class addRentalagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBorrow",
                table: "Rentals",
                newName: "IsBorrowed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBorrowed",
                table: "Rentals",
                newName: "IsBorrow");
        }
    }
}
