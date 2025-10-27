using BusTicketReservationSystem.Domain.Common;
using BusTicketReservationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public Guid BusScheduleId { get; private set; }
        public Guid PassengerId { get; private set; }
        public int SeatNumber { get; private set; }
        public SeatStatus Status { get; private set; }

        public string BoardingPoint { get; private set; }
        public string DroppingPoint { get; private set; }

        public BusSchedule BusSchedule { get; private set; }
        public Passenger Passenger { get; private set; }


        protected Ticket() { }

        public Ticket(Guid busScheduleId, Guid passengerId, int seatNumber, string boardingPoint, string droppingPoint)
        {
            BusScheduleId = busScheduleId;
            PassengerId = passengerId;
            SeatNumber = seatNumber;
            BoardingPoint = boardingPoint;
            DroppingPoint = droppingPoint;
            Status = SeatStatus.Booked;
        }


        public void UpdateStatus(SeatStatus newStatus)
        {
            Status = newStatus;
            SetUpdated();
        }
    }
}
