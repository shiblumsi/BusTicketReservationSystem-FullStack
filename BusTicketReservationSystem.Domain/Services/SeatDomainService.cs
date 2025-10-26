using BusTicketReservationSystem.Domain.Entities;
using BusTicketReservationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Domain.Services
{
    public class SeatDomainService
    {
        public void ChangeSeatStatus(Ticket ticket, SeatStatus newStatus)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));

            if (ticket.Status == newStatus)
                return; // Already same state

            switch (ticket.Status)
            {
                case SeatStatus.Available:
                    if (newStatus != SeatStatus.Booked && newStatus != SeatStatus.Sold)
                        throw new InvalidOperationException($"Cannot move from {ticket.Status} to {newStatus}");
                    break;

                case SeatStatus.Booked:
                    if (newStatus != SeatStatus.Sold && newStatus != SeatStatus.Cancelled)
                        throw new InvalidOperationException($"Cannot move from {ticket.Status} to {newStatus}");
                    break;

                case SeatStatus.Sold:
                    throw new InvalidOperationException("Cannot change status once sold");

                case SeatStatus.Cancelled:
                    if (newStatus != SeatStatus.Available && newStatus != SeatStatus.Booked)
                        throw new InvalidOperationException($"Cannot move from {ticket.Status} to {newStatus}");
                    break;
            }

            ticket.UpdateStatus(newStatus);
        }
    }
}
