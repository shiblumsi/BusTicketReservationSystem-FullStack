using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusTicketReservationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    TotalSeats = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FromCity = table.Column<string>(type: "text", nullable: false),
                    ToCity = table.Column<string>(type: "text", nullable: false),
                    DistanceKm = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusId = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusSchedules_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusSchedules_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatNumber = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_BusSchedules_BusScheduleId",
                        column: x => x.BusScheduleId,
                        principalTable: "BusSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "CompanyName", "Name", "TotalSeats" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "BanglaBus", "Express A1", 40 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "CityLine", "Express B2", 35 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "GreenLine", "Super Fast C3", 45 },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Shyamoli", "Comfort D4", 30 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Hanif", "Luxury E5", 50 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "DeshLine", "Rapid F6", 40 },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Soudia", "Night Rider G7", 38 },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "GreenLine", "Morning Express H8", 42 },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Shohag", "SilkRoute I9", 36 },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Hanif", "CityLink J10", 48 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "DistanceKm", "FromCity", "ToCity" },
                values: new object[,]
                {
                    { new Guid("10101010-1010-1010-1010-101010101010"), 250.0, "Dhaka", "Chittagong" },
                    { new Guid("11111111-1111-1111-1111-111111111011"), 115.0, "Dhaka", "Tangail" },
                    { new Guid("20202020-2020-2020-2020-202020202020"), 240.0, "Dhaka", "Sylhet" },
                    { new Guid("30303030-3030-3030-3030-303030303030"), 270.0, "Dhaka", "Rajshahi" },
                    { new Guid("40404040-4040-4040-4040-404040404040"), 220.0, "Dhaka", "Khulna" },
                    { new Guid("50505050-5050-5050-5050-505050505050"), 200.0, "Dhaka", "Barishal" },
                    { new Guid("60606060-6060-6060-6060-606060606060"), 120.0, "Dhaka", "Mymensingh" },
                    { new Guid("70707070-7070-7070-7070-707070707070"), 130.0, "Dhaka", "Comilla" },
                    { new Guid("80808080-8080-8080-8080-808080808080"), 90.0, "Dhaka", "Narsingdi" },
                    { new Guid("90909090-9090-9090-9090-909090909090"), 50.0, "Dhaka", "Gazipur" }
                });

            migrationBuilder.InsertData(
                table: "BusSchedules",
                columns: new[] { "Id", "ArrivalTime", "BusId", "DepartureTime", "Price", "RouteId" },
                values: new object[,]
                {
                    { new Guid("11111111-7777-1111-7777-111111117777"), new DateTime(2025, 10, 21, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 10, 21, 12, 0, 0, 0, DateTimeKind.Utc), 900m, new Guid("70707070-7070-7070-7070-707070707070") },
                    { new Guid("22222222-8888-2222-8888-222222228888"), new DateTime(2025, 10, 21, 16, 0, 0, 0, DateTimeKind.Utc), new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 10, 21, 13, 0, 0, 0, DateTimeKind.Utc), 1000m, new Guid("80808080-8080-8080-8080-808080808080") },
                    { new Guid("33333333-9999-3333-9999-333333339999"), new DateTime(2025, 10, 21, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Utc), 950m, new Guid("90909090-9090-9090-9090-909090909090") },
                    { new Guid("44444444-aaaa-4444-aaaa-44444444aaaa"), new DateTime(2025, 10, 21, 18, 0, 0, 0, DateTimeKind.Utc), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 10, 21, 15, 0, 0, 0, DateTimeKind.Utc), 1200m, new Guid("11111111-1111-1111-1111-111111111011") },
                    { new Guid("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"), new DateTime(2025, 10, 21, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 10, 21, 6, 0, 0, 0, DateTimeKind.Utc), 1200m, new Guid("10101010-1010-1010-1010-101010101010") },
                    { new Guid("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"), new DateTime(2025, 10, 21, 13, 0, 0, 0, DateTimeKind.Utc), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 10, 21, 7, 0, 0, 0, DateTimeKind.Utc), 1300m, new Guid("20202020-2020-2020-2020-202020202020") },
                    { new Guid("cccccccc-3333-cccc-3333-cccccccccccc"), new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 10, 21, 8, 0, 0, 0, DateTimeKind.Utc), 1400m, new Guid("30303030-3030-3030-3030-303030303030") },
                    { new Guid("dddddddd-4444-dddd-4444-dddddddddddd"), new DateTime(2025, 10, 21, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 10, 21, 9, 0, 0, 0, DateTimeKind.Utc), 1500m, new Guid("40404040-4040-4040-4040-404040404040") },
                    { new Guid("eeeeeeee-5555-eeee-5555-eeeeeeeeeeee"), new DateTime(2025, 10, 21, 16, 0, 0, 0, DateTimeKind.Utc), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), 1600m, new Guid("50505050-5050-5050-5050-505050505050") },
                    { new Guid("ffffffff-6666-ffff-6666-ffffffff6666"), new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 10, 21, 11, 0, 0, 0, DateTimeKind.Utc), 1100m, new Guid("60606060-6060-6060-6060-606060606060") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_BusId",
                table: "BusSchedules",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_RouteId",
                table: "BusSchedules",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BusScheduleId",
                table: "Tickets",
                column: "BusScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "BusSchedules");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
