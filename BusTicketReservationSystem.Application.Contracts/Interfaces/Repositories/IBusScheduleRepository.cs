using BusTicketReservationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Contracts.Interfaces.Repositories
{
    public interface IBusScheduleRepository
    {
        Task<List<BusSchedule>> GetAvailableSchedulesAsync(string departureCity, string arrivalCity, DateTime journeyDate);
        Task<BusSchedule> GetByIdWithTicketsAsync(Guid id);
    }
}
