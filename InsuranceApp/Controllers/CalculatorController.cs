using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Controllers
{
    [Route("[controller]")]
    public class CalculatorController : Controller
    {
        [HttpGet("Premium")]
        public IActionResult Premium() => View();

        [HttpPost("Premium")]
        public IActionResult Premium(PremiumInputModel model)
        {
            decimal rate = 0.05m; // Example rate: 5%
            decimal premium = (model.SumAssured * rate * model.TermYears) / 100;
            ViewBag.Result = $"Estimated Premium: ₹{premium:0.00}";
            return View(model);
        }
    }
}
