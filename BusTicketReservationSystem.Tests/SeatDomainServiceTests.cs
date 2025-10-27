using BusTicketReservationSystem.Domain.Entities;
using BusTicketReservationSystem.Domain.Enums;
using BusTicketReservationSystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Tests
{
    public class SeatDomainServiceTests
    {
        private readonly SeatDomainService _service = new SeatDomainService();

        [Fact]
        public void ChangeSeatStatus_AvailableToBooked_UpdatesStatus()
        {
            var ticket = new Ticket(Guid.NewGuid(), Guid.NewGuid(), 1, "A", "B");
            ticket.UpdateStatus(SeatStatus.Available);

            _service.ChangeSeatStatus(ticket, SeatStatus.Booked);

            Assert.Equal(SeatStatus.Booked, ticket.Status);
        }

        [Fact]
        public void ChangeSeatStatus_Sold_ThrowsException()
        {
            var ticket = new Ticket(Guid.NewGuid(), Guid.NewGuid(), 1, "A", "B");
            ticket.UpdateStatus(SeatStatus.Sold);

            Assert.Throws<InvalidOperationException>(() =>
                _service.ChangeSeatStatus(ticket, SeatStatus.Cancelled)
            );
        }

        [Fact]
        public void ChangeSeatStatus_CancelledToAvailable_UpdatesStatus()
        {
            var ticket = new Ticket(Guid.NewGuid(), Guid.NewGuid(), 1, "A", "B");
            ticket.UpdateStatus(SeatStatus.Cancelled);

            _service.ChangeSeatStatus(ticket, SeatStatus.Available);

            Assert.Equal(SeatStatus.Available, ticket.Status);
        }
    }
}
