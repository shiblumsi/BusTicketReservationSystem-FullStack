using BusTicketReservationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; private set; }
        public Guid BusScheduleId { get; private set; }
        public Guid PassengerId { get; private set; }
        public int SeatNumber { get; private set; }
        public SeatStatus Status { get; private set; }

        public BusSchedule BusSchedule { get; private set; }
        public Passenger Passenger { get; private set; }

        protected Ticket() { }

        public Ticket(Guid busScheduleId, Guid passengerId, int seatNumber)
        {
            Id = Guid.NewGuid();
            BusScheduleId = busScheduleId;
            PassengerId = passengerId;
            SeatNumber = seatNumber;
            Status = SeatStatus.Booked;
        }

        public void MarkAsSold()
        {
            Status = SeatStatus.Sold;
        }

        public void CancelBooking()
        {
            Status = SeatStatus.Available;
        }
    }
}
