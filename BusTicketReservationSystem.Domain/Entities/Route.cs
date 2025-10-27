using BusTicketReservationSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Domain.Entities
{
    public class Route : BaseEntity
    {
        public string FromCity { get; private set; }
        public string ToCity { get; private set; }
        public double DistanceKm { get; private set; }

        public List<BusSchedule> Schedules { get; private set; } = new List<BusSchedule>();

        protected Route() { }

        public Route(string fromCity, string toCity, double distanceKm)
        {
            FromCity = fromCity;
            ToCity = toCity;
            DistanceKm = distanceKm;
        }
    }
}
