using BusTicketReservationSystem.Domain.Common;
using BusTicketReservationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Domain.Entities
{
    public class BusSchedule : BaseEntity
    {
        public Guid BusId { get; private set; }
        public Guid RouteId { get; private set; }
        public DateTime JourneyDate { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public DateTime ArrivalTime { get; private set; }
        public decimal Price { get; private set; }

        public Bus Bus { get; private set; }
        public Route Route { get; private set; }
        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();

        protected BusSchedule() { }

        public BusSchedule(Guid busId, Guid routeId, DateTime journeyDate, DateTime departure, DateTime arrival, decimal price)
        {
            BusId = busId;
            RouteId = routeId;
            JourneyDate = journeyDate;
            DepartureTime = departure;
            ArrivalTime = arrival;
            Price = price;
        }

        public int SeatsLeft()
        {
            int bookedSeats = Tickets.Count(t => t.Status == SeatStatus.Booked || t.Status == SeatStatus.Sold);
            return Bus.TotalSeats - bookedSeats;
        }
    }
}
