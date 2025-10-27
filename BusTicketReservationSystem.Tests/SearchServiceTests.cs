using BusTicketReservationSystem.Application.Contracts.Interfaces.Repositories;
using BusTicketReservationSystem.Application.Services;
using BusTicketReservationSystem.Domain.Entities;
using Moq;
using BusTicketReservationSystem.Application.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Tests
{
    public class SearchServiceTests
    {
        [Fact]
        public async Task SearchAvailableBusesAsync_ReturnsBusList_WhenSchedulesExist()
        {
            // Arrange
            var mockRepo = new Mock<IBusScheduleRepository>();

            var bus = new Bus("Green Line", "Green Line Company", 40);
            var schedule = new BusSchedule(
                busId: bus.Id,
                routeId: Guid.NewGuid(),
                journeyDate: DateTime.Today,
                departure: DateTime.Today.AddHours(8),
                arrival: DateTime.Today.AddHours(12),
                price: 600
            );

           
            typeof(BusSchedule).GetProperty(nameof(BusSchedule.Bus))!
                .SetValue(schedule, bus);

            var mockSchedules = new List<BusSchedule> { schedule };

            mockRepo.Setup(r => r.GetAvailableSchedulesAsync("Dhaka", "Chittagong", It.IsAny<DateTime>()))
                    .ReturnsAsync(mockSchedules);

            var service = new SearchService(mockRepo.Object);

            // Act
            var result = await service.SearchAvailableBusesAsync("Dhaka", "Chittagong", DateTime.Today);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Green Line", result[0].BusName);
            Assert.Equal("Green Line Company", result[0].CompanyName);
            Assert.Equal(600, result[0].Price);
        }

        [Fact]
        public async Task SearchAvailableBusesAsync_ThrowsException_WhenNoBusesFound()
        {
            // Arrange
            var mockRepo = new Mock<IBusScheduleRepository>();
            mockRepo.Setup(r => r.GetAvailableSchedulesAsync("Dhaka", "Chittagong", It.IsAny<DateTime>()))
                    .ReturnsAsync(new List<BusSchedule>());

            var service = new SearchService(mockRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() =>
                service.SearchAvailableBusesAsync("Dhaka", "Chittagong", DateTime.Today)
            );
        }
    }
}