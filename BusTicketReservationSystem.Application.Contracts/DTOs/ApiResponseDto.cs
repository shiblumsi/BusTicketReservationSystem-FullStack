using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Contracts.DTOs
{
    public class ApiResponseDto<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
