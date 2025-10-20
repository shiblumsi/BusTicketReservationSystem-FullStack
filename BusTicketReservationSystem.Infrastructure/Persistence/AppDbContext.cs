using BusTicketReservationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
       
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<BusSchedule> BusSchedules { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // Seed some dummy data
            // Buses
            modelBuilder.Entity<Bus>().HasData(
                new { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Express A1", CompanyName = "BanglaBus", TotalSeats = 40 },
                new { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Express B2", CompanyName = "CityLine", TotalSeats = 35 },
                new { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Super Fast C3", CompanyName = "GreenLine", TotalSeats = 45 },
                new { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Comfort D4", CompanyName = "Shyamoli", TotalSeats = 30 },
                new { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Luxury E5", CompanyName = "Hanif", TotalSeats = 50 },
                new { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Rapid F6", CompanyName = "DeshLine", TotalSeats = 40 },
                new { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "Night Rider G7", CompanyName = "Soudia", TotalSeats = 38 },
                new { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "Morning Express H8", CompanyName = "GreenLine", TotalSeats = 42 },
                new { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), Name = "SilkRoute I9", CompanyName = "Shohag", TotalSeats = 36 },
                new { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "CityLink J10", CompanyName = "Hanif", TotalSeats = 48 }
            );

            // Routes
            modelBuilder.Entity<Route>().HasData(
                new { Id = Guid.Parse("10101010-1010-1010-1010-101010101010"), FromCity = "Dhaka", ToCity = "Chittagong", DistanceKm = 250.0 },
                new { Id = Guid.Parse("20202020-2020-2020-2020-202020202020"), FromCity = "Dhaka", ToCity = "Sylhet", DistanceKm = 240.0 },
                new { Id = Guid.Parse("30303030-3030-3030-3030-303030303030"), FromCity = "Dhaka", ToCity = "Rajshahi", DistanceKm = 270.0 },
                new { Id = Guid.Parse("40404040-4040-4040-4040-404040404040"), FromCity = "Dhaka", ToCity = "Khulna", DistanceKm = 220.0 },
                new { Id = Guid.Parse("50505050-5050-5050-5050-505050505050"), FromCity = "Dhaka", ToCity = "Barishal", DistanceKm = 200.0 },
                new { Id = Guid.Parse("60606060-6060-6060-6060-606060606060"), FromCity = "Dhaka", ToCity = "Mymensingh", DistanceKm = 120.0 },
                new { Id = Guid.Parse("70707070-7070-7070-7070-707070707070"), FromCity = "Dhaka", ToCity = "Comilla", DistanceKm = 130.0 },
                new { Id = Guid.Parse("80808080-8080-8080-8080-808080808080"), FromCity = "Dhaka", ToCity = "Narsingdi", DistanceKm = 90.0 },
                new { Id = Guid.Parse("90909090-9090-9090-9090-909090909090"), FromCity = "Dhaka", ToCity = "Gazipur", DistanceKm = 50.0 },
                new { Id = Guid.Parse("11111111-1111-1111-1111-111111111011"), FromCity = "Dhaka", ToCity = "Tangail", DistanceKm = 115.0 }
            );

            // BusSchedules
            modelBuilder.Entity<BusSchedule>().HasData(
                new { Id = Guid.Parse("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"), BusId = Guid.Parse("11111111-1111-1111-1111-111111111111"), RouteId = Guid.Parse("10101010-1010-1010-1010-101010101010"), DepartureTime = new DateTime(2025, 10, 21, 6, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 12, 0, 0, DateTimeKind.Utc), Price = 1200m },
                new { Id = Guid.Parse("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"), BusId = Guid.Parse("22222222-2222-2222-2222-222222222222"), RouteId = Guid.Parse("20202020-2020-2020-2020-202020202020"), DepartureTime = new DateTime(2025, 10, 21, 7, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 13, 0, 0, DateTimeKind.Utc), Price = 1300m },
                new { Id = Guid.Parse("cccccccc-3333-cccc-3333-cccccccccccc"), BusId = Guid.Parse("33333333-3333-3333-3333-333333333333"), RouteId = Guid.Parse("30303030-3030-3030-3030-303030303030"), DepartureTime = new DateTime(2025, 10, 21, 8, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 14, 0, 0, DateTimeKind.Utc), Price = 1400m },
                new { Id = Guid.Parse("dddddddd-4444-dddd-4444-dddddddddddd"), BusId = Guid.Parse("44444444-4444-4444-4444-444444444444"), RouteId = Guid.Parse("40404040-4040-4040-4040-404040404040"), DepartureTime = new DateTime(2025, 10, 21, 9, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 15, 0, 0, DateTimeKind.Utc), Price = 1500m },
                new { Id = Guid.Parse("eeeeeeee-5555-eeee-5555-eeeeeeeeeeee"), BusId = Guid.Parse("55555555-5555-5555-5555-555555555555"), RouteId = Guid.Parse("50505050-5050-5050-5050-505050505050"), DepartureTime = new DateTime(2025, 10, 21, 10, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 16, 0, 0, DateTimeKind.Utc), Price = 1600m },
                new { Id = Guid.Parse("ffffffff-6666-ffff-6666-ffffffff6666"), BusId = Guid.Parse("66666666-6666-6666-6666-666666666666"), RouteId = Guid.Parse("60606060-6060-6060-6060-606060606060"), DepartureTime = new DateTime(2025, 10, 21, 11, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 14, 0, 0, DateTimeKind.Utc), Price = 1100m },
                new { Id = Guid.Parse("11111111-7777-1111-7777-111111117777"), BusId = Guid.Parse("77777777-7777-7777-7777-777777777777"), RouteId = Guid.Parse("70707070-7070-7070-7070-707070707070"), DepartureTime = new DateTime(2025, 10, 21, 12, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 15, 0, 0, DateTimeKind.Utc), Price = 900m },
                new { Id = Guid.Parse("22222222-8888-2222-8888-222222228888"), BusId = Guid.Parse("88888888-8888-8888-8888-888888888888"), RouteId = Guid.Parse("80808080-8080-8080-8080-808080808080"), DepartureTime = new DateTime(2025, 10, 21, 13, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 16, 0, 0, DateTimeKind.Utc), Price = 1000m },
                new { Id = Guid.Parse("33333333-9999-3333-9999-333333339999"), BusId = Guid.Parse("99999999-9999-9999-9999-999999999999"), RouteId = Guid.Parse("90909090-9090-9090-9090-909090909090"), DepartureTime = new DateTime(2025, 10, 21, 14, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 15, 0, 0, DateTimeKind.Utc), Price = 950m },
                new { Id = Guid.Parse("44444444-aaaa-4444-aaaa-44444444aaaa"), BusId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), RouteId = Guid.Parse("11111111-1111-1111-1111-111111111011"), DepartureTime = new DateTime(2025, 10, 21, 15, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2025, 10, 21, 18, 0, 0, DateTimeKind.Utc), Price = 1200m }
            );





        }
    }
}
