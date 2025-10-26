using BusTicketReservationSystem.Application.Contracts.DTOs;
using BusTicketReservationSystem.Application.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BusTicketReservationSystem.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBookingService _bookingService;

        private readonly string _storeId = "sof6659cd57240c6";
        private readonly string _storePass = "sof6659cd57240c6@ssl";
        private readonly string _sslUrl = "https://sandbox.sslcommerz.com/gwprocess/v3/api.php";

        public PaymentService(IBookingService bookingService)
        {
            _bookingService = bookingService;
          
        }

        public async Task<string> InitiatePaymentAsync(List<Guid> ticketIds)
        {
            if (ticketIds == null || ticketIds.Count == 0)
                throw new Exception("No tickets provided.");

            decimal totalAmount = 100m * ticketIds.Count;
            string tranId = Guid.NewGuid().ToString();

            var postData = new Dictionary<string, string>
            {
                {"store_id", _storeId},
                {"store_passwd", _storePass},
                {"total_amount", totalAmount.ToString("F2", CultureInfo.InvariantCulture)},
                {"currency", "BDT"},
                {"tran_id", tranId},

                // Required URLs
                {"success_url", $"https://localhost:7113/api/payment/success?ticketIds={string.Join(",", ticketIds)}"},
                {"fail_url", $"https://localhost:7113/api/payment/fail?ticketIds={string.Join(",", ticketIds)}"},
                {"cancel_url", $"https://localhost:7113/api/payment/cancel?ticketIds={string.Join(",", ticketIds)}"},

                {"cus_name", "Demo User"},
                {"cus_email", "demo@test.com"},
                {"cus_phone", "01700000000"},
                {"cus_add1", "Dhaka"},
                {"cus_city", "Dhaka"},
                {"cus_country", "Bangladesh"},
                {"shipping_method", "NO"},
                {"product_name", "Bus Ticket"},
                {"product_category", "Travel"},
                {"product_profile", "general"},
            };

            using var client = new HttpClient();
            var response = await client.PostAsync(_sslUrl, new FormUrlEncodedContent(postData));
            var body = await response.Content.ReadAsStringAsync();

            Console.WriteLine("SSLCommerz Response Body: " + body);

            using var doc = JsonDocument.Parse(body);
            var redirectUrl = doc.RootElement.GetProperty("GatewayPageURL").GetString();
            Console.WriteLine("SSLCommerz Redirect URL: " + redirectUrl);

            return redirectUrl;
        }


        public async Task<bool> HandlePaymentSuccessAsync(List<Guid> ticketIds)
        {
            foreach (var ticketId in ticketIds)
            {
                await _bookingService.ConfirmBookingAsync(ticketId);
            }

            return true;
        }
    } 
}
