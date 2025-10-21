using BusTicketReservationSystem.Application.Contracts.DTOs;
using BusTicketReservationSystem.Application.Contracts.Interfaces;
using BusTicketReservationSystem.Application.Contracts.Interfaces.Repositories;
using BusTicketReservationSystem.Domain.Entities;
using BusTicketReservationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBusScheduleRepository _scheduleRepo;
        private readonly ITicketRepository _ticketRepo;
        private readonly IPassengerRepository _passengerRepo;


        public BookingService(IBusScheduleRepository scheduleRepo, ITicketRepository ticketRepo, IPassengerRepository passengerRepo)
        {
            _scheduleRepo = scheduleRepo;
            _passengerRepo = passengerRepo;
            _ticketRepo = ticketRepo;
        }


        public async Task<SeatPlanDto> GetSeatPlanAsync(Guid busScheduleId)
        {
            var schedule = await _scheduleRepo.GetByIdWithTicketsAsync(busScheduleId);
            if (schedule == null) throw new Exception("Bus schedule not found");

            var seats = Enumerable.Range(1, schedule.Bus.TotalSeats).Select(i => new SeatDto
            {
                SeatNumber = i,
                Status = schedule.Tickets.FirstOrDefault(t => t.SeatNumber == i)?.Status ?? Domain.Enums.SeatStatus.Available
            }).ToList();
            return new SeatPlanDto { BusScheduleId = schedule.Id, Seats = seats };
        }

        public async Task<BookSeatResultDto> BookSeatAsync(BookSeatInputDto input)
        {
            var schedule = await _scheduleRepo.GetByIdWithTicketsAsync(input.BusScheduleId);
            if (schedule == null) return new BookSeatResultDto { Success = false, Message = "Bus schedule not found" };

            var seatStatus = schedule.Tickets.FirstOrDefault(t => t.SeatNumber == input.SeatNumber)?.Status;
            if (seatStatus != null && seatStatus != SeatStatus.Available)
                return new BookSeatResultDto { Success = false, Message = "Seat already booked" };
           
            var passenger = new Passenger(input.PassengerName, input.PassengerMobile);
            var ticket = new Ticket(schedule.Id, passenger.Id, input.SeatNumber);

            await _passengerRepo.AddAsync(passenger);
            await _ticketRepo.AddAsync(ticket);
            return new BookSeatResultDto { Success = true, Message = "Seat booked successfully" };

        }
    }

}
