using BusTicketReservationSystem.Application.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Contracts.Interfaces
{
    public interface IPaymentService
    {
        Task<string> InitiatePaymentAsync(List<Guid> ticketIds);
        Task<bool> HandlePaymentSuccessAsync(List<Guid> ticketIds);
    }
}
