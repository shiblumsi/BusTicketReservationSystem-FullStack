using BusTicketReservationSystem.Application.Contracts.Interfaces.Repositories;
using BusTicketReservationSystem.Domain.Entities;
using BusTicketReservationSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Infrastructure.Repositories
{
    public class BusScheduleRepository : IBusScheduleRepository
    {
        private readonly AppDbContext _context;
        public BusScheduleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<BusSchedule>> GetAvailableSchedulesAsync(string from, string to, DateTime journeyDate)
        {
            return await _context.BusSchedules
                .Include(s => s.Bus)
                .Include(s => s.Route)
                .Include(s => s.Tickets)
                .Where(s =>
                    s.Route.FromCity.ToLower().Trim() == from.ToLower().Trim() &&
                    s.Route.ToCity.ToLower().Trim() == to.ToLower().Trim() &&
                    s.JourneyDate == journeyDate.Date
                )
                .ToListAsync();
        }

        public async Task<BusSchedule> GetByIdWithTicketsAsync(Guid id)
        {
            return await _context.BusSchedules
                .Include(s => s.Bus)
                .Include(s => s.Tickets)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

    }
}
