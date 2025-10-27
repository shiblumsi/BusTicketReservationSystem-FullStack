using BusTicketReservationSystem.API.Controllers;
using BusTicketReservationSystem.Application.Contracts.DTOs;
using BusTicketReservationSystem.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Tests
{
    public class BookingControllerTests
    {
        private readonly Mock<IBookingService> _bookingService = new();
        private readonly BookingController _controller;

        public BookingControllerTests()
        {
            _controller = new BookingController(_bookingService.Object);
        }

        [Fact]
        public async Task GetSeatPlan_ReturnsOk_WithSeatPlan()
        {
            // Arrange
            var seatPlan = new SeatPlanDto
            {
                BusScheduleId = Guid.NewGuid(),
                Seats = new List<SeatDto>
                {
                    new SeatDto { SeatNumber = 1, Status = Domain.Enums.SeatStatus.Available }
                }
            };
            _bookingService.Setup(s => s.GetSeatPlanAsync(It.IsAny<Guid>())).ReturnsAsync(seatPlan);

            // Act
            var result = await _controller.GetSeatPlan(Guid.NewGuid());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<SeatPlanDto>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Single(response.Data.Seats);
        }

        [Fact]
        public async Task BookSeat_ReturnsOk_WhenBookingSucceeds()
        {
            // Arrange
            var resultDto = new BookSeatResultDto { Success = true, Message = "Booked", TicketIds = new List<Guid> { Guid.NewGuid() } };
            _bookingService.Setup(s => s.BookSeatAsync(It.IsAny<List<BookSeatInputDto>>())).ReturnsAsync(resultDto);

            var input = new List<BookSeatInputDto>
            {
                new BookSeatInputDto
                {
                    BusScheduleId = Guid.NewGuid(),
                    SeatNumber = 1,
                    PassengerName = "Test",
                    PassengerMobile = "0123456789",
                    BoardingPoint = "A",
                    DroppingPoint = "B"
                }
            };

            // Act
            var result = await _controller.BookSeat(input);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<BookSeatResultDto>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Single(response.Data.TicketIds);
        }

        [Fact]
        public async Task CancelBookings_ReturnsOk_WhenCancellationSucceeds()
        {
            // Arrange
            var ticketIds = new List<Guid> { Guid.NewGuid() };
            var resultDto = new BookSeatResultDto { Success = true, Message = "Cancelled" };
            _bookingService.Setup(s => s.CancelBookingAsync(It.IsAny<Guid>())).ReturnsAsync(resultDto);

            // Act
            var result = await _controller.CancelBookings(ticketIds);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<List<BookSeatResultDto>>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Equal("Cancelled", response.Data[0].Message);
        }

        [Fact]
        public async Task ConfirmBookings_ReturnsOk_WhenConfirmationSucceeds()
        {
            // Arrange
            var ticketIds = new List<Guid> { Guid.NewGuid() };
            var resultDto = new BookSeatResultDto { Success = true, Message = "Confirmed" };
            _bookingService.Setup(s => s.ConfirmBookingAsync(It.IsAny<Guid>())).ReturnsAsync(resultDto);

            // Act
            var result = await _controller.ConfirmBookings(ticketIds);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<List<BookSeatResultDto>>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Equal("Confirmed", response.Data[0].Message);
        }

        [Fact]
        public async Task GetPoints_ReturnsOk_WithBoardingDroppingPoints()
        {
            // Arrange
            var points = new List<BoardingDroppingDto> { new BoardingDroppingDto { PointName = "A" } };
            _bookingService.Setup(s => s.GetPointsByCityAsync("Dhaka", "boarding")).ReturnsAsync(points);

            // Act
            var result = await _controller.GetPoints("Dhaka", "boarding");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<List<BoardingDroppingDto>>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Single(response.Data);
        }

        [Fact]
        public async Task ConfirmBookings_ReturnsBadRequest_WhenNoTicketIds()
        {
            // Act
            var result = await _controller.ConfirmBookings(new List<Guid>());

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto<object>>(badRequest.Value);
            Assert.False(response.Success);
        }
    }
}
