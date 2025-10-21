using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Domain.Entities
{
    public class BusSchedule
    {
        public Guid Id { get; private set; }
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
            Id = Guid.NewGuid();
            BusId = busId;
            RouteId = routeId;
            JourneyDate = journeyDate;
            DepartureTime = departure;
            ArrivalTime = arrival;
            Price = price;
        }

        public int SeatsLeft()
        {
            return Bus.TotalSeats - Tickets.Count;
        }
    }
}
