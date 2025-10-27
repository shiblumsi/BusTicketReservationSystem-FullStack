using BusTicketReservationSystem.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketReservationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        // Step 1: Initiate Payment
        [HttpPost("initiate")]
        public async Task<IActionResult> InitiatePayment([FromBody] List<Guid> ticketIds)
        {
            if (ticketIds == null || ticketIds.Count == 0)
                return BadRequest("No tickets provided.");

            try
            {
                var redirectUrl = await _paymentService.InitiatePaymentAsync(ticketIds);
                return Ok(new { RedirectUrl = redirectUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // Step 2: Success Callback
        [HttpPost("success")]
        public async Task<IActionResult> PaymentSuccess([FromQuery] string ticketIds)
        {
            if (string.IsNullOrEmpty(ticketIds))
                return BadRequest("No ticket IDs provided.");

            var ticketIdList = new List<Guid>();
            foreach (var id in ticketIds.Split(','))
            {
                if (Guid.TryParse(id, out var guid))
                    ticketIdList.Add(guid);
            }

            if (ticketIdList.Count == 0)
                return BadRequest("Invalid ticket IDs.");

            await _paymentService.HandlePaymentSuccessAsync(ticketIdList);

            var redirectToFE = "http://localhost:4200/payment-success";
            return Redirect(redirectToFE);
        }
    }
}
