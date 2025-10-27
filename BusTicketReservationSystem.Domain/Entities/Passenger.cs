using BusTicketReservationSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Domain.Entities
{
    public class Passenger : BaseEntity
    {
        public string Name { get; private set; }
        public string Mobile { get; private set; }

        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();

        protected Passenger() { }

        public Passenger(string name, string mobile)
        {
            Name = name;
            Mobile = mobile;
        }
    }
}
