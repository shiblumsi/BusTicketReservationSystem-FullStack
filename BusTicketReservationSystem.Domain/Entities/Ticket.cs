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

        public string BoardingPoint { get; private set; }
        public string DroppingPoint { get; private set; }

        public BusSchedule BusSchedule { get; private set; }
        public Passenger Passenger { get; private set; }

        //public DateTime UpdatedAt { get; private set; }

        protected Ticket() { }

        public Ticket(Guid busScheduleId, Guid passengerId, int seatNumber, string boardingPoint, string droppingPoint)
        {
            Id = Guid.NewGuid();
            BusScheduleId = busScheduleId;
            PassengerId = passengerId;
            SeatNumber = seatNumber;
            BoardingPoint = boardingPoint;
            DroppingPoint = droppingPoint;
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

        public void UpdateStatus(SeatStatus newStatus)
        {
            Status = newStatus;
            //UpdatedAt = DateTime.UtcNow;
        }
    }
}
