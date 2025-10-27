using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTicketReservationSystem.API.Controllers;
using BusTicketReservationSystem.Application.Contracts.DTOs;
using BusTicketReservationSystem.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketReservationSystem.Tests
{
    public class SearchControllerTests
    {
        [Fact]
        public async Task Search_ReturnsAvailableBuses_WhenBusesExist()
        {
            // Arrange
            var mockService = new Mock<ISearchService>();
            var mockBuses = new List<AvailableBusDto>
            {
                new AvailableBusDto { BusId = Guid.NewGuid(), BusName = "Green Line", Price = 800 }
            };

            mockService.Setup(s => s.SearchAvailableBusesAsync("Dhaka", "Chittagong", It.IsAny<DateTime>()))
                       .ReturnsAsync(mockBuses);

            var controller = new SearchController(mockService.Object);

            // Act
            var result = await controller.Search("Dhaka", "Chittagong", DateTime.Now);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<List<AvailableBusDto>>>(okResult.Value);

            Assert.True(response.Success);
            Assert.Single(response.Data);
            Assert.Equal("Available buses found", response.Message);
        }
    }
}
