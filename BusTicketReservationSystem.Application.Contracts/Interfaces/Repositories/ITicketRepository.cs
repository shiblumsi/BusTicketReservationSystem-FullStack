using BusTicketReservationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Contracts.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task AddAsync(Ticket ticket);
        Task<Ticket?> GetByIdAsync(Guid id);
        Task UpdateAsync(Ticket ticket);
    }
}
