using BusTicketReservationSystem.Application.Contracts.DTOs;
using BusTicketReservationSystem.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketReservationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }


        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string departureCity, [FromQuery] string arrivalCity, [FromQuery] DateTime journeyDate)
        {
            try
            {
                journeyDate = journeyDate.Date;
                var buses = await _searchService.SearchAvailableBusesAsync(departureCity, arrivalCity, journeyDate);

                var response = new ApiResponseDto<List<AvailableBusDto>>
                {
                    Success = true,
                    Message = buses.Any() ? "Available buses found" : "No buses available",
                    StatusCode = StatusCodes.Status200OK,
                    Data = buses
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseDto<List<AvailableBusDto>>
                {
                    Success = false,
                    Message = "Failed to load buses",
                    Errors = new[] { ex.Message },
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

    }
}
