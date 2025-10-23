using BusTicketReservationSystem.Application.Contracts.DTOs;
using BusTicketReservationSystem.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketReservationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet("{busScheduleId}/seats")]
        public async Task<IActionResult> GetSeatPlan(Guid busScheduleId)
        {
            var seatPlan = await _bookingService.GetSeatPlanAsync(busScheduleId);
            return Ok(seatPlan);
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookSeat([FromBody] List<BookSeatInputDto> inputs)
        {
            var result = await _bookingService.BookSeatAsync(inputs);
            return Ok(result);
        }

        [HttpGet("boarding-dropping")]
        public async Task<IActionResult> GetPoients([FromQuery]string city, [FromQuery]string type)
        {
            var result = await _bookingService.GetPointsByCityAsync(city, type);
            return Ok(result);
        }
    }
}
