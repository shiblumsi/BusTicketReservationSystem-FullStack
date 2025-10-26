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
            try
            {
                var seatPlan = await _bookingService.GetSeatPlanAsync(busScheduleId);

                var response = new ApiResponseDto<SeatPlanDto>
                {
                    Success = true,
                    Message = "Seat plan loaded successfully",
                    Data = seatPlan,
                    StatusCode = StatusCodes.Status200OK
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseDto<SeatPlanDto>
                {
                    Success = false,
                    Message = "Failed to load seat plan",
                    Errors = new[] { ex.Message },
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookSeat([FromBody] List<BookSeatInputDto> inputs)
        {
            try
            {
                var result = await _bookingService.BookSeatAsync(inputs);

                var response = new ApiResponseDto<BookSeatResultDto>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result,
                    StatusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseDto<BookSeatResultDto>
                {
                    Success = false,
                    Message = "Seat booking failed",
                    Errors = new[] { ex.Message },
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet("boarding-dropping")]
        public async Task<IActionResult> GetPoints([FromQuery] string city, [FromQuery] string type)
        {
            try
            {
                var points = await _bookingService.GetPointsByCityAsync(city, type);

                var response = new ApiResponseDto<List<BoardingDroppingDto>>
                {
                    Success = true,
                    Message = "Points loaded successfully",
                    Data = points,
                    StatusCode = StatusCodes.Status200OK
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseDto<List<BoardingDroppingDto>>
                {
                    Success = false,
                    Message = "Failed to load points",
                    Errors = new[] { ex.Message },
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmBookings([FromBody] List<Guid> ticketIds)
        {
            if (ticketIds == null || !ticketIds.Any())
                return BadRequest(new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "No ticket IDs provided",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            try
            {
                var results = new List<BookSeatResultDto>();
                foreach (var ticketId in ticketIds)
                {
                    var result = await _bookingService.ConfirmBookingAsync(ticketId);
                    results.Add(result);
                }

                var response = new ApiResponseDto<List<BookSeatResultDto>>
                {
                    Success = true,
                    Message = "Bookings confirmed successfully",
                    Data = results,
                    StatusCode = StatusCodes.Status200OK
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseDto<List<BookSeatResultDto>>
                {
                    Success = false,
                    Message = "Booking confirmation failed",
                    Errors = new[] { ex.Message },
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelBookings([FromBody] List<Guid> ticketIds)
        {
            if (ticketIds == null || !ticketIds.Any())
                return BadRequest(new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "No ticket IDs provided",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            try
            {
                var results = new List<BookSeatResultDto>();
                foreach (var ticketId in ticketIds)
                {
                    var result = await _bookingService.CancelBookingAsync(ticketId);
                    results.Add(result);
                }

                var response = new ApiResponseDto<List<BookSeatResultDto>>
                {
                    Success = true,
                    Message = "Bookings cancelled successfully",
                    Data = results,
                    StatusCode = StatusCodes.Status200OK
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseDto<List<BookSeatResultDto>>
                {
                    Success = false,
                    Message = "Cancel operation failed",
                    Errors = new[] { ex.Message },
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
