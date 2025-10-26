using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Contracts.DTOs
{
    public class PaymentRequestDto
    {
        public List<Guid> TicketIds { get; set; }
        public decimal Amount { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }
}
