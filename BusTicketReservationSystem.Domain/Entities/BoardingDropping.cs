using BusTicketReservationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Domain.Entities
{
    public class BoardingDropping
    {
        public Guid Id { get; private set; }
        public string CityName { get; private set; }     
        public string PointName { get; private set; }    
        public PointType Type { get; private set; }     

        protected BoardingDropping() { }

        public BoardingDropping(string cityName, string pointName, PointType type)
        {
            Id = Guid.NewGuid();
            CityName = cityName;
            PointName = pointName;
            Type = type;
        }
    }
}
