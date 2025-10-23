using BusTicketReservationSystem.Application.Contracts.Interfaces.Repositories;
using BusTicketReservationSystem.Domain.Entities;
using BusTicketReservationSystem.Domain.Enums;
using BusTicketReservationSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Infrastructure.Repositories
{
    public class BoardingDroppingRepository : IBoardingDroppingRepository
    {
        private readonly AppDbContext _context;
        public BoardingDroppingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BoardingDropping>> GetByCityAsync(string city, string type)
        {
            if (!Enum.TryParse<PointType>(type?.Trim(), true, out var pointType))
                throw new ArgumentException($"Invalid point type: {type}");

            return await _context.BoardingDroppings
                .Where(b => b.CityName.ToLower() == city.ToLower() &&
                           (b.Type == pointType || b.Type == PointType.Both))
                .ToListAsync();
        }
    }
}
