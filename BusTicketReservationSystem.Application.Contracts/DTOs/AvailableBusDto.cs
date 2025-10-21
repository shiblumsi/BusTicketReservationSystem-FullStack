using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Contracts.DTOs
{
    public class AvailableBusDto
    {
        public Guid BusId { get; set; }
        public string CompanyName { get; set; }
        public string BusName { get; set; }
        public DateTime JourneyDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int SeatsLeft { get; set; }
        public decimal Price { get; set; }
    }
}
