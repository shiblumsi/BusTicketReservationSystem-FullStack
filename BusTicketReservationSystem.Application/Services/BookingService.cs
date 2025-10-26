using BusTicketReservationSystem.Application.Contracts.DTOs;
using BusTicketReservationSystem.Application.Contracts.Interfaces;
using BusTicketReservationSystem.Application.Contracts.Interfaces.Repositories;
using BusTicketReservationSystem.Domain.Entities;
using BusTicketReservationSystem.Domain.Enums;
using BusTicketReservationSystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBusScheduleRepository _scheduleRepo;
        private readonly ITicketRepository _ticketRepo;
        private readonly IPassengerRepository _passengerRepo;
        private readonly IBoardingDroppingRepository _boardingDroppingRepo;
        private readonly SeatDomainService _seatDomainService;
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(
            IBusScheduleRepository scheduleRepo,
            ITicketRepository ticketRepo,
            IPassengerRepository passengerRepo,
            IBoardingDroppingRepository boardingDroppingRepository,
            IUnitOfWork unitOfWork,
            SeatDomainService seatDomainService)
        {
            _scheduleRepo = scheduleRepo;
            _ticketRepo = ticketRepo;
            _passengerRepo = passengerRepo;
            _boardingDroppingRepo = boardingDroppingRepository;
            _seatDomainService = seatDomainService;
            _unitOfWork = unitOfWork;
        }

        public async Task<SeatPlanDto> GetSeatPlanAsync(Guid busScheduleId)
        {
            var schedule = await _scheduleRepo.GetByIdWithTicketsAsync(busScheduleId);
            if (schedule == null)
                throw new Exception("Bus schedule not found");

            var seats = Enumerable.Range(1, schedule.Bus.TotalSeats)
                .Select(i => new SeatDto
                {
                    SeatNumber = i,
                    Status = schedule.Tickets.FirstOrDefault(t => t.SeatNumber == i)?.Status ?? SeatStatus.Available
                })
                .ToList();

            return new SeatPlanDto
            {
                BusScheduleId = schedule.Id,
                Seats = seats
            };
        }

        public async Task<BookSeatResultDto> BookSeatAsync(List<BookSeatInputDto> inputs)
        {
            if (inputs == null || !inputs.Any())
                return new BookSeatResultDto { Success = false, Message = "No seat data provided" };

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var ticketIds = new List<Guid>();

                foreach (var input in inputs)
                {
                    var schedule = await _scheduleRepo.GetByIdWithTicketsAsync(input.BusScheduleId);
                    if (schedule == null)
                        throw new Exception("Bus schedule not found");

                    var existingTicket = schedule.Tickets.FirstOrDefault(t => t.SeatNumber == input.SeatNumber);

                    if (existingTicket != null)
                    {
                        if (existingTicket.Status == SeatStatus.Available || existingTicket.Status == SeatStatus.Cancelled)
                        {
                            _seatDomainService.ChangeSeatStatus(existingTicket, SeatStatus.Booked);
                            await _ticketRepo.UpdateAsync(existingTicket);
                            ticketIds.Add(existingTicket.Id);
                        }
                        else
                        {
                            throw new Exception($"Seat {input.SeatNumber} is already booked or sold");
                        }
                    }
                    else
                    {
                        var passenger = new Passenger(input.PassengerName, input.PassengerMobile);
                        await _passengerRepo.AddAsync(passenger);

                        var ticket = new Ticket(
                            schedule.Id,
                            passenger.Id,
                            input.SeatNumber,
                            input.BoardingPoint,
                            input.DroppingPoint
                        );

                        _seatDomainService.ChangeSeatStatus(ticket, SeatStatus.Booked);
                        await _ticketRepo.AddAsync(ticket);
                        ticketIds.Add(ticket.Id);
                    }
                }

                transaction.Commit();

                return new BookSeatResultDto
                {
                    Success = true,
                    Message = inputs.Count > 1 ? "All seats booked successfully!" : "Seat booked successfully!",
                    TicketIds = ticketIds
                };
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                return new BookSeatResultDto
                {
                    Success = false,
                    Message = $"Booking failed: {ex.Message}"
                };
            }
        }

        public async Task<List<BoardingDroppingDto>> GetPointsByCityAsync(string city, string type)
        {
            var points = await _boardingDroppingRepo.GetByCityAsync(city, type);

            return points.Select(p => new BoardingDroppingDto
            {
                PointName = p.PointName
            }).ToList();
        }

        public async Task<BookSeatResultDto> ConfirmBookingAsync(Guid ticketId)
        {
            try
            {
                var ticket = await _ticketRepo.GetByIdAsync(ticketId);
                if (ticket == null)
                    return new BookSeatResultDto { Success = false, Message = "Ticket not found" };

                if (ticket.Status != SeatStatus.Booked)
                    return new BookSeatResultDto { Success = false, Message = "Only booked seats can be confirmed" };

                _seatDomainService.ChangeSeatStatus(ticket, SeatStatus.Sold);
                await _ticketRepo.UpdateAsync(ticket);

                return new BookSeatResultDto
                {
                    Success = true,
                    Message = "Booking confirmed successfully"
                };
            }
            catch (Exception ex)
            {
                return new BookSeatResultDto
                {
                    Success = false,
                    Message = $"Confirm failed: {ex.Message}"
                };
            }
        }

        public async Task<BookSeatResultDto> CancelBookingAsync(Guid ticketId)
        {
            try
            {
                var ticket = await _ticketRepo.GetByIdAsync(ticketId);
                if (ticket == null)
                    return new BookSeatResultDto { Success = false, Message = "Ticket not found" };

                if (ticket.Status == SeatStatus.Cancelled)
                    return new BookSeatResultDto { Success = false, Message = "Ticket already cancelled" };

                _seatDomainService.ChangeSeatStatus(ticket, SeatStatus.Cancelled);
                await _ticketRepo.UpdateAsync(ticket);

                return new BookSeatResultDto
                {
                    Success = true,
                    Message = "Booking cancelled successfully"
                };
            }
            catch (Exception ex)
            {
                return new BookSeatResultDto
                {
                    Success = false,
                    Message = $"Cancel failed: {ex.Message}"
                };
            }
        }
    }
}
