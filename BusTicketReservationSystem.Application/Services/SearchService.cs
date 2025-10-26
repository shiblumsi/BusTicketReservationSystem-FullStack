using BusTicketReservationSystem.Application.Contracts.DTOs;
using BusTicketReservationSystem.Application.Contracts.Interfaces;
using BusTicketReservationSystem.Application.Contracts.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly IBusScheduleRepository _busScheduleRepository;
        public SearchService(IBusScheduleRepository busScheduleRepository)
        {
            _busScheduleRepository = busScheduleRepository;
        }
        public async Task<List<AvailableBusDto>> SearchAvailableBusesAsync(string from, string to, DateTime journeyDate)
        {
            var schedules = await _busScheduleRepository.GetAvailableSchedulesAsync(from, to, journeyDate);
            if (schedules == null || !schedules.Any())
                throw new Exception("No available buses found for the selected route and date.");


            var result = schedules.Select(s => new AvailableBusDto
            {
                ScheduleId = s.Id,
                BusId = s.BusId,
                CompanyName = s.Bus.CompanyName,
                BusName = s.Bus.Name,
                TotalSeat = s.Bus.TotalSeats,
                StartTime = s.DepartureTime,
                ArrivalTime = s.ArrivalTime,
                Price = s.Price,
                JourneyDate = s.JourneyDate,
                SeatsLeft = s.SeatsLeft()
            }).ToList();

            return result;
        }
    }
}
