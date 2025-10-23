using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketReservationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoardingPoint",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DroppingPoint",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardingPoint",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DroppingPoint",
                table: "Tickets");
        }
    }
}
