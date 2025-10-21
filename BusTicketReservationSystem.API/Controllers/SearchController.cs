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
        public async Task<IActionResult> Search([FromQuery] string from, [FromQuery] string to, [FromQuery] DateTime journeyDate)
        {
            journeyDate = journeyDate.Date;
            var result = await _searchService.SearchAvailableBusesAsync(from, to, journeyDate);
            return Ok(result);
        }

    }
}
