using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusTicketReservationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-1111-bbbb-1111-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-3333-cccc-3333-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("10101010-1010-1010-1010-101010101010"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111011"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("50505050-5050-5050-5050-505050505050"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("60606060-6060-6060-6060-606060606060"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("70707070-7070-7070-7070-707070707070"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("80808080-8080-8080-8080-808080808080"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("90909090-9090-9090-9090-909090909090"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("20202020-2020-2020-2020-202020202020"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("30303030-3030-3030-3030-303030303030"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("40404040-4040-4040-4040-404040404040"));

            migrationBuilder.InsertData(
                table: "BusSchedules",
                columns: new[] { "Id", "ArrivalTime", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    { new Guid("11111111-1211-1111-1111-111111111111"), new DateTime(2025, 10, 25, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 10, 25, 6, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1700m, new Guid("12121212-1212-1212-1212-121212121212") },
                    { new Guid("11111111-1211-2111-1111-111111111111"), new DateTime(2025, 10, 25, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 10, 25, 6, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1700m, new Guid("12121212-1212-1212-1212-121212121212") },
                    { new Guid("11111111-1311-1111-1111-111111111111"), new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 10, 25, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 950m, new Guid("12121212-1212-1212-1212-121212121212") },
                    { new Guid("11111111-1411-1111-1111-111111111111"), new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 10, 25, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1100m, new Guid("12121212-1212-1212-1212-121212121212") },
                    { new Guid("11111111-1411-2111-1111-111111111111"), new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 10, 25, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1100m, new Guid("12121212-1212-1212-1212-121212121212") },
                    { new Guid("11111111-1711-1111-1111-111111111111"), new DateTime(2025, 10, 27, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 10, 27, 6, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1700m, new Guid("13131313-1313-1313-1313-131313131313") },
                    { new Guid("11111111-1811-1111-1111-111111111111"), new DateTime(2025, 10, 27, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 10, 27, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 950m, new Guid("13131313-1313-1313-1313-131313131313") },
                    { new Guid("11111111-1911-1111-1111-111111111111"), new DateTime(2025, 10, 27, 16, 0, 0, 0, DateTimeKind.Utc), new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 10, 27, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1100m, new Guid("13131313-1313-1313-1313-131313131313") }
                });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CompanyName", "Name" },
                values: new object[] { "Shyamoli", "Shyamoli NR" });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CompanyName", "Name", "TotalSeats" },
                values: new object[] { "Ena", "Ena Transport", 40 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Super Fast", 40 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Comfort Line", 40 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Luxury Line", 40 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "Name",
                value: "Rapid Class");

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Night Rider", 40 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Morning Express", 40 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "SilkRoute", 40 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "CityLink", 40 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "DistanceKm", "FromCity", "ToCity" },
                values: new object[] { new Guid("15151515-1515-1515-1515-151515151515"), 240.0, "Dhaka", "Sylhet" });

            migrationBuilder.InsertData(
                table: "BusSchedules",
                columns: new[] { "Id", "ArrivalTime", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    { new Guid("11111111-1511-1111-1111-111111111111"), new DateTime(2025, 10, 26, 13, 0, 0, 0, DateTimeKind.Utc), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 10, 26, 7, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 750m, new Guid("15151515-1515-1515-1515-151515151515") },
                    { new Guid("11111111-1611-1111-1111-111111111111"), new DateTime(2025, 10, 26, 17, 0, 0, 0, DateTimeKind.Utc), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 10, 26, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 950m, new Guid("15151515-1515-1515-1515-151515151515") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1211-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1211-2111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1311-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1411-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1411-2111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1511-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1611-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1711-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1811-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "BusSchedules",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1911-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("15151515-1515-1515-1515-151515151515"));

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CompanyName", "Name" },
                values: new object[] { "BanglaBus", "Express A1" });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CompanyName", "Name", "TotalSeats" },
                values: new object[] { "CityLine", "Express B2", 35 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Super Fast C3", 45 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Comfort D4", 30 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Luxury E5", 50 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "Name",
                value: "Rapid F6");

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Night Rider G7", 38 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "Morning Express H8", 42 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "SilkRoute I9", 36 });

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Name", "TotalSeats" },
                values: new object[] { "CityLink J10", 48 });

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
                columns: new[] { "Id", "ArrivalTime", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"), new DateTime(2025, 10, 21, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 10, 21, 6, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200m, new Guid("40404040-4040-4040-4040-404040404040") },
                    { new Guid("aaaaaaaa-1111-bbbb-1111-aaaaaaaaaaaa"), new DateTime(2025, 10, 21, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 10, 21, 6, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200m, new Guid("40404040-4040-4040-4040-404040404040") },
                    { new Guid("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"), new DateTime(2025, 10, 21, 13, 0, 0, 0, DateTimeKind.Utc), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 10, 21, 7, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1300m, new Guid("20202020-2020-2020-2020-202020202020") },
                    { new Guid("cccccccc-3333-cccc-3333-cccccccccccc"), new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 10, 21, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1400m, new Guid("30303030-3030-3030-3030-303030303030") }
                });
        }
    }
}
