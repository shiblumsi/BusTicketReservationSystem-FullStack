using BusTicketReservationSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Domain.Entities
{
    public class Bus : BaseEntity
    {
        public string Name { get; private set; }
        public string CompanyName { get; private set; }
        public int TotalSeats { get; private set; }
        public List<BusSchedule> Schedules { get; private set; } = new List<BusSchedule>();
       
        protected Bus() { }

        public Bus(string name, string companyName, int totalSeats)
        {
            Name = name;
            CompanyName = companyName;
            TotalSeats = totalSeats;
        }



    }
}
