using InsuranceApp.Models;
using InsuranceApp.Repository;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _repo;
        private readonly EmailService _email;

        // Constructor
        public PaymentController(IPaymentRepository repo, EmailService email)
        {
            _repo = repo;
            _email = email;
        }

        // Post method to process payment
        [HttpPost("Pay")]
        public async Task<IActionResult> Pay(Payment model)
        {
            // Call the ProcessPayment method and await the result
            var success = await _repo.ProcessPayment(model.CustomerId, model.PolicyId, model.Amount);

            if (success)
            {
                // Send confirmation email if payment was successful
                _email.SendConfirmation("customer@example.com", "Payment Success", "Your payment has been processed.");
            }

            // Redirect to the Dashboard if payment was successful
            return RedirectToAction("Dashboard", "Customer");
        }
    }
}
