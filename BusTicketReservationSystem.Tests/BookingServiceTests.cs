using BusTicketReservationSystem.Application.Contracts.DTOs;
using BusTicketReservationSystem.Application.Contracts.Interfaces.Repositories;
using BusTicketReservationSystem.Application.Services;
using BusTicketReservationSystem.Domain.Entities;
using BusTicketReservationSystem.Domain.Enums;
using BusTicketReservationSystem.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Tests
{
    public class BookingServiceTests
    {
        private readonly Mock<IBusScheduleRepository> _scheduleRepo = new();
        private readonly Mock<ITicketRepository> _ticketRepo = new();
        private readonly Mock<IPassengerRepository> _passengerRepo = new();
        private readonly Mock<IBoardingDroppingRepository> _boardingRepo = new();
        private readonly Mock<IUnitOfWork> _unitOfWork = new();
        private readonly SeatDomainService _seatDomainService = new();

        private BookingService CreateService() => new BookingService(
            _scheduleRepo.Object,
            _ticketRepo.Object,
            _passengerRepo.Object,
            _boardingRepo.Object,
            _unitOfWork.Object,
            _seatDomainService
        );

        private BusSchedule CreateScheduleWithBus()
        {
            var bus = new Bus("Green Line", "Company", 40);
            var schedule = new BusSchedule(bus.Id, Guid.NewGuid(), DateTime.Today, DateTime.Now, DateTime.Now.AddHours(5), 500);
            typeof(BusSchedule).GetProperty(nameof(BusSchedule.Bus))!.SetValue(schedule, bus);
            return schedule;
        }

        private void SetupTransactionMock()
        {
            var mockTransaction = new Mock<IDbTransaction>();
            mockTransaction.Setup(t => t.Commit());
            mockTransaction.Setup(t => t.Rollback());
            _unitOfWork.Setup(u => u.BeginTransaction()).Returns(mockTransaction.Object);
        }

        [Fact]
        public async Task BookSeatAsync_ShouldBookAvailableSeat()
        {
            // Arrange
            SetupTransactionMock();
            var schedule = CreateScheduleWithBus();
            _scheduleRepo.Setup(r => r.GetByIdWithTicketsAsync(It.IsAny<Guid>())).ReturnsAsync(schedule);
            _ticketRepo.Setup(t => t.AddAsync(It.IsAny<Ticket>())).Returns(Task.CompletedTask);
            _passengerRepo.Setup(p => p.AddAsync(It.IsAny<Passenger>())).Returns(Task.CompletedTask);

            var service = CreateService();
            var input = new List<BookSeatInputDto>
            {
                new BookSeatInputDto
                {
                    BusScheduleId = schedule.Id,
                    SeatNumber = 1,
                    PassengerName = "Test",
                    PassengerMobile = "0123456789",
                    BoardingPoint = "A",
                    DroppingPoint = "B"
                }
            };

            // Act
            var result = await service.BookSeatAsync(input);

            // Assert
            Assert.True(result.Success);
            Assert.Single(result.TicketIds);
        }

        [Fact]
        public async Task BookSeatAsync_BooksMultipleSeatsAtOnce_Success()
        {
            // Arrange
            SetupTransactionMock();
            var schedule = CreateScheduleWithBus(); // Bus with 40 seats
            _scheduleRepo.Setup(r => r.GetByIdWithTicketsAsync(It.IsAny<Guid>())).ReturnsAsync(schedule);
            _ticketRepo.Setup(t => t.AddAsync(It.IsAny<Ticket>())).Returns(Task.CompletedTask);
            _passengerRepo.Setup(p => p.AddAsync(It.IsAny<Passenger>())).Returns(Task.CompletedTask);

            var service = CreateService();

            var inputs = new List<BookSeatInputDto>
            {
                new BookSeatInputDto
                {
                    BusScheduleId = schedule.Id,
                    SeatNumber = 1,
                    PassengerName = "Alice",
                    PassengerMobile = "0123456789",
                    BoardingPoint = "A",
                    DroppingPoint = "B"
                },
                new BookSeatInputDto
                {
                    BusScheduleId = schedule.Id,
                    SeatNumber = 2,
                    PassengerName = "Bob",
                    PassengerMobile = "0987654321",
                    BoardingPoint = "A",
                    DroppingPoint = "B"
                }
            };

            // Act
            var result = await service.BookSeatAsync(inputs);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(2, result.TicketIds.Count);
        }

        [Fact]
        public async Task BookSeatAsync_ShouldFail_WhenSeatAlreadyBooked()
        {
            // Arrange
            SetupTransactionMock();
            var schedule = CreateScheduleWithBus();
            var existingTicket = new Ticket(schedule.Id, Guid.NewGuid(), 1, "A", "B");
            schedule.Tickets.Add(existingTicket);
            _scheduleRepo.Setup(r => r.GetByIdWithTicketsAsync(It.IsAny<Guid>())).ReturnsAsync(schedule);
            _ticketRepo.Setup(t => t.UpdateAsync(It.IsAny<Ticket>())).Returns(Task.CompletedTask);

            var service = CreateService();
            var input = new List<BookSeatInputDto>
            {
                new BookSeatInputDto
                {
                    BusScheduleId = schedule.Id,
                    SeatNumber = 1,
                    PassengerName = "Test2",
                    PassengerMobile = "0123456789",
                    BoardingPoint = "A",
                    DroppingPoint = "B"
                }
            };

            // Act
            var result = await service.BookSeatAsync(input);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("already booked", result.Message);
        }

        [Fact]
        public async Task CancelBookingAsync_ShouldCancelBookedTicket()
        {
            // Arrange
            var ticket = new Ticket(Guid.NewGuid(), Guid.NewGuid(), 1, "A", "B");
            ticket.UpdateStatus(SeatStatus.Booked);
            _ticketRepo.Setup(t => t.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(ticket);
            _ticketRepo.Setup(t => t.UpdateAsync(ticket)).Returns(Task.CompletedTask);

            var service = CreateService();

            // Act
            var result = await service.CancelBookingAsync(ticket.Id);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(SeatStatus.Cancelled, ticket.Status);
        }

        [Fact]
        public async Task ConfirmBookingAsync_ShouldMarkBookedTicketAsSold()
        {
            // Arrange
            var ticket = new Ticket(Guid.NewGuid(), Guid.NewGuid(), 1, "A", "B");
            ticket.UpdateStatus(SeatStatus.Booked);
            _ticketRepo.Setup(t => t.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(ticket);
            _ticketRepo.Setup(t => t.UpdateAsync(ticket)).Returns(Task.CompletedTask);

            var service = CreateService();

            // Act
            var result = await service.ConfirmBookingAsync(ticket.Id);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(SeatStatus.Sold, ticket.Status);
        }
    }
}
